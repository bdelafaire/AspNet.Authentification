FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["AspNet.Authentification.Cookie/AspNet.Authentification.Cookie.csproj", "AspNet.Authentification.Cookie/"]
RUN dotnet restore "AspNet.Authentification.Cookie/AspNet.Authentification.Cookie.csproj"
COPY . .
WORKDIR "/src/AspNet.Authentification.Cookie"
RUN dotnet build "AspNet.Authentification.Cookie.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNet.Authentification.Cookie.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNet.Authentification.Cookie.dll"]