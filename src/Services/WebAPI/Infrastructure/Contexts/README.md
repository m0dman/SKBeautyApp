# Useful EFCore DB Command
Below are a list of of useful commands that can be used to support the extending and management of a DB when using EFCore as a context.

## Create Migration
cmd is `dotnet-ef migrations add <ModelName> --startup-project ..\API\API.csproj --context SKBeautyContext`

## Update to revert Migration
To revert previous migration from db cmd is `dotnet-ef database update <Previous migration name> --startup-project ..\API\API.csproj --context SKBeautyContext -v`

## Remove Migration
To remove previous migration cmd is `dotnet-ef migrations remove --startup-project ..\API\API.csproj --context SKBeautyContext`