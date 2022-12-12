$ cd PropertyApp
$ docker-compose up

Migrate database:
$ docker exec -w /app/aspnet -it property-migration /root/.dotnet/tools/dotnet-ef database update

When this is done, run the maui app!

(dotnet build -t:Run -f net7.0-android /p:AndroidSdkDirectory=/home/brechtl/Android/Sdk/)
