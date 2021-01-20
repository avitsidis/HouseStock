# HouseStock.DataAccess.Tools

This project is a dummy project to allow dotnet ef migration commands to be executed (runtime is needed)

## Connection string

connection string should be overrided to execute migration on the desired database

Powershell: `$env:CUSTOMCONNSTR_stock = "Server=mysqlserver;Database=stock-dev;user=user-migration;password=user-migration-password;";`

## Add a migration

cd .\HouseStock.DataAccess\
dotnet ef migrations add MIGRATION_NAME --startup-project ..\HouseStock.DataAccess.Tools\HouseStock.DataAccess.Tools.csproj

## Remove migrations

cd .\HouseStock.DataAccess\
dotnet ef migrations remove --startup-project ..\HouseStock.DataAccess.Tools\HouseStock.DataAccess.Tools.csproj

## update database

cd .\HouseStock.DataAccess\
dotnet ef database update --startup-project ..\HouseStock.DataAccess.Tools\HouseStock.DataAccess.Tools.csproj

## update database to migration

cd .\HouseStock.DataAccess\
dotnet ef database update MIGRATION_NAME --startup-project ..\HouseStock.DataAccess.Tools\HouseStock.DataAccess.Tools.csproj

## remove database objects

cd .\HouseStock.DataAccess\
dotnet ef database update 0 --startup-project ..\HouseStock.DataAccess.Tools\HouseStock.DataAccess.Tools.csproj
