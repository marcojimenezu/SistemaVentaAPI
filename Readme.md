## Development tools

### EF Core
Install ef core to use migrations feature
```
dotnet tool install --global dotnet-ef
```
or update your current version
```
dotnet tool update --global dotnet-ef
```
Add a migration
```
dotnet ef migrations add <MIGRATION NAME> --project ./SistemaVenta.DAL/SistemaVenta.DAL.csproj --startup-project ./SistemaVenta.API/SistemaVenta.API.csproj
```
Update database
```
dotnet ef database update --project ./SistemaVenta.DAL/SistemaVenta.DAL.csproj --startup-project ./SistemaVenta.API/SistemaVenta.API.csproj
```
### Docker


### Docker compose

https://learn.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-7.0&tabs=visual-studio%2Clinux-ubuntu#ssl-linux

```
docker compose build
docker compose up
```