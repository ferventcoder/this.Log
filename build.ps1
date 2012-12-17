$localDir = $(Split-Path -parent $MyInvocation.MyCommand.Definition)

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

dir -r -include *.csproj -exclude **\.git\**,**\*.Tests\** | %{  
  if ($_.FullName.ToLower().EndsWith(".sample.csproj") -or $_.FullName.ToLower().EndsWith(".sample.vbproj")) {
    $nuspec = join-path $_.Directory.Name $_.Name.Replace('csproj','nuspec').Replace('LoggingExtensions.','this.Log-')
    Write-Host "Building and packaging a nuget package for `'$nuspec'";
    & $nugetExe pack $nuspec -OutputDirectory "$outputDir"
  } else {
    Write-Host "Building and packaging a nuget package for `'$_.FullName'";
    & $nugetExe pack $_.FullName -Prop Configuration=Release -Symbols -OutputDirectory "$outputDir"
  }
}