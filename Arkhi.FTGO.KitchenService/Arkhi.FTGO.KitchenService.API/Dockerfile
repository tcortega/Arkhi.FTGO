FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App

ENTRYPOINT ["dotnet", "Arkhi.FTGO.KitchenService.API.dll"]
