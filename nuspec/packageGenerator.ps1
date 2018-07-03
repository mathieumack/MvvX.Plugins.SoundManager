$location  = $env:APPVEYOR_BUILD_FOLDER

$locationNuspec = $location + "\nuspec"
$locationNuspec
    
Set-Location -Path $locationNuspec

"Packaging to nuget..."
"Build folder : " + $location

write-host "Update the nuget.exe file" -foreground "DarkGray"
.\NuGet update -self

$strPath = $location + '\MvvX.Plugins.SoundManager\MvvX.Plugins.SoundManager\bin\Release\MvvX.Plugins.SoundManager.dll'

$VersionInfos = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($strPath)
$ProductVersion = $VersionInfos.ProductVersion
"Product version : " + $ProductVersion

"Update nuspec versions ..."
    
$nuSpecFile =  $locationNuspec + '\MvvX.Plugins.SoundManager.nuspec'
(Get-Content $nuSpecFile) | 
Foreach-Object {$_ -replace "(<version>([0-9.]+)<\/version>)", "<version>$ProductVersion</version>" } | 
Set-Content $nuSpecFile

"Generate nuget packages ..."
.\NuGet.exe pack MvvX.Plugins.SoundManager.nuspec

$apiKey = $env:NuGetApiKey
    
"Publish packages ..."	
.\NuGet push MvvX.Plugins.SoundManager.$ProductVersion.nupkg -Source https://www.nuget.org/api/v2/package -ApiKey $apiKey