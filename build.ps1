$localDir = $(Split-Path -parent $MyInvocation.MyCommand.Definition)

$nugetExe = Join-Path $localDir 'lib\nuget\nuget.exe'

