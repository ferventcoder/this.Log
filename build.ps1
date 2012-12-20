$localDir = $(Split-Path -parent $MyInvocation.MyCommand.Definition)

[string]$version = Get-Content "$localDir\VERSION"
Write-Host "Current version set at $version"

$sharedAssembly = Join-Path $localDir 'SharedAssembly.cs'
Write-Host "Updating version in `'$sharedAssembly`'"
$sharedAssemblyContents = Get-Content $sharedAssembly
$sharedAssemblyReplace = @()
foreach ($line in $sharedAssemblyContents) { 
  $assemblyVersionPattern = 'AssemblyVersion\(\"\d+\.\d+\.\d+\.\d+\"\)';
  $assemblyVersionReplace = "AssemblyVersion(`"$version`")"
  $line = [regex]::replace($line, $assemblyVersionPattern, "$assemblyVersionReplace")
  $assemblyFileVersionPattern = 'AssemblyFileVersion\(\"\d+\.\d+\.\d+\.\d+\"\)';
  $assemblyFileVersionReplace = "AssemblyFileVersion(`"$version`")"
  $line = [regex]::replace($line, $assemblyFileVersionPattern, "$assemblyFileVersionReplace")
  $sharedAssemblyReplace += [Array]$line
} 
$sharedAssemblyReplace | Out-File $sharedAssembly -encoding UTF8 -force

Write-Host "Updating version in nuspecs"
dir -r -include *.nuspec -exclude **\.git\** | %{ 
  [xml]$nuspec = Get-Content $_.FullName
  if ($nuspec.package.metadata.version -ne '$version$') {
    Write-Host "Updating version to `'$version`' for `'$($_.FullName)' from `'$($nuspec.package.metadata.version)`'";
    $nuspec.package.metadata.version = $version
  }
  
  $dependencies = $nuspec.package.metadata.dependencies
  if ($dependencies -ne $null) {
    $nuspec.package.metadata.dependencies.dependency | %{ 
      if ($_.id.Contains('this.Log')) 
      { 
          Write-Host "Setting dependency `'$($_.id)`' to version `'$version`'"
          $_.SetAttribute('version',$version);
      }
    }
  }
  
  $nuspec.Save($_.FullName)
}

$nugetExe = Join-Path $localDir 'lib\nuget\nuget.exe'
Write-Host "Using `'$nugetExe`' to restore packages and build projects"
dir -r -include packages.config -exclude **\.git\** | %{ 
  Write-Host "Restoring packages for `'$_.FullName'";
  & $nugetExe install $_.FullName -OutputDirectory packages
}

$MsBuild="$($env:WINDIR)\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
& $MsBuild $localDir\LoggingExtensions.sln /property:Configuration=Release


$outputDir = join-path $localDir 'bin'
if (!(test-path $outputDir)){
  md $outputDir | out-null
}

dir -r -include *.csproj,*.vbproj -exclude **\.git\**,**\*.Tests\** | %{  
  if ($_.FullName.ToLower().EndsWith(".sample.csproj") -or $_.FullName.ToLower().EndsWith(".sample.vbproj")) {
    $nuspecFile = join-path $_.Directory.Name $_.Name.Replace('csproj','nuspec').Replace('vbproj','nuspec').Replace('LoggingExtensions.','this.Log-')
    Write-Host "Building and packaging a nuget package for `'$nuspecFile'";
    & $nugetExe pack $nuspecFile -OutputDirectory "$outputDir"
  } else {
    Write-Host "Building and packaging a nuget package for `'$_.FullName'";
    & $nugetExe pack $_.FullName -Prop Configuration=Release -Symbols -OutputDirectory "$outputDir"
  }
}