FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VirtualStore.Api/VirtualStore.Api.csproj", "VirtualStore.Api/"]
RUN dotnet restore "VirtualStore.Api/VirtualStore.Api.csproj"
COPY . .
WORKDIR "/src/VirtualStore.Api"
RUN dotnet build "VirtualStore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VirtualStore.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VirtualStore.Api.dll"]
