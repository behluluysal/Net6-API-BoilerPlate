#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000/
ENV ASPNETCORE_ENVIRONMENT="development"
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Net6-API-BoilerPlate/Net6-API-BoilerPlate.csproj", "Net6-API-BoilerPlate/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["DataStore.EF/DataStore.EF.csproj", "DataStore.EF/"]
RUN dotnet restore "Core/Core.csproj"
RUN dotnet restore "DataStore.EF/DataStore.EF.csproj"
RUN dotnet restore "Net6-API-BoilerPlate/Net6-API-BoilerPlate.csproj"
COPY . .
WORKDIR "/src/Core"
RUN dotnet build "Core.csproj" -c Release -o /app/build
WORKDIR "/src/DataStore.EF"
RUN dotnet build "DataStore.EF.csproj" -c Release -o /app/build
WORKDIR "/src/Net6-API-BoilerPlate"
RUN dotnet build "Net6-API-BoilerPlate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net6-API-BoilerPlate.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net6-API-BoilerPlate.dll"]