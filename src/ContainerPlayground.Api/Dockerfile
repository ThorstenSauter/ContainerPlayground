FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ContainerPlayground.Api/ContainerPlayground.Api.csproj", "ContainerPlayground.Api/"]
RUN dotnet restore "src/ContainerPlayground.Api/ContainerPlayground.Api.csproj"
COPY . .
WORKDIR "/src/ContainerPlayground.Api"
RUN dotnet build "ContainerPlayground.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContainerPlayground.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContainerPlayground.Api.dll"]
