$localDir = $(Split-Path -parent $MyInvocation.MyCommand.Definition)

[string]$version = Get-Content "$localDir\VERSION"

$nugetExe = Join-Path $localDir 'lib\nuget\nuget.exe'
Write-Host "Using `'$nugetExe`' to push packages"

& $nugetExe push "bin\this.Log.$($version).nupkg"
& $nugetExe push "bin\this.Log-log4net.$($version).nupkg"
& $nugetExe push "bin\this.Log-log4net.Sample.$($version).nupkg"
& $nugetExe push "bin\this.Log-log4net.VB.Sample.$($version).nupkg"
& $nugetExe push "bin\this.Log-NLog.$($version).nupkg"
& $nugetExe push "bin\this.Log-NLog.Sample.$($version).nupkg"
& $nugetExe push "bin\this.Log-NLog.VB.Sample.$($version).nupkg"
& $nugetExe push "bin\this.Log-Moq.$($version).nupkg"
& $nugetExe push "bin\this.Log-RhinoMocks.$($version).nupkg"