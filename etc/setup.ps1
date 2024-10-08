$ErrorActionPreference = "Stop"

$nodeExist = [bool] (Get-Command -ErrorAction Ignore -Type Application node)
$dockerExist = [bool] (Get-Command -ErrorAction Ignore -Type Application docker)

if(!$nodeExist){
    Write-Host("`nPlease install nodejs`n")
    exit
}

if(!$dockerExist){
    Write-Host("`nPlease install docker`n")
    exit
}

$docker = docker ps 2>&1

Write-Host("`nInstalling Dotnet ef tool`n")
dotnet tool install --global dotnet-ef --version 6.0.1

Write-Host("`nInstalling Abp Studio Cli`n")
dotnet tool install -g Volo.Abp.Studio.Cli

Write-Host("`nUpdating Abp Studio Cli`n")
dotnet tool update -g Volo.Abp.Studio.Cli

Write-Host("`nInstalling Yarn`n")
npm install --global yarn

Write-Host("`nInstalling Tye`n")
dotnet tool install -g Microsoft.Tye --version "0.11.0-alpha.22111.1"

Write-Host("`nInstalling packages`n")
abp install-libs --working-directory "./apps/Thatch.AuthServer"

Write-Host("`nBuilding Solution`n")
dotnet build /graphBuild

Invoke-Expression "./thatch.ps1 infra up"

Invoke-Expression "./thatch.ps1 migrate"

Write-Host("`nCongrats! Project setup is complete. Try command '.\thatch.ps1 run'`n")