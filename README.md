# To run this application:

$ __cd PropertyApp__

$ __docker-compose up__

### Migrate database (only run when using for the first time!):

$ __docker exec -w /app/aspnet -it property-migration /root/.dotnet/tools/dotnet-ef database update__

When this is done, run the maui app!

(__dotnet build -t:Run -f net7.0-android /p:AndroidSdkDirectory=/home/brechtl/Android/Sdk/__) unix only command

# Screenshots:

![alt text](https://github.com/brechtlauwers/PropertyApp/blob/main/Screenshots/Main%20page%20view.png)
![alt text](https://github.com/brechtlauwers/PropertyApp/blob/main/Screenshots/Property%20detail%20view.png)
![alt text](https://github.com/brechtlauwers/PropertyApp/blob/main/Screenshots/Add%20property%20view%201.png)
![alt text](https://github.com/brechtlauwers/PropertyApp/blob/main/Screenshots/Add%20property%20view%202.png)
