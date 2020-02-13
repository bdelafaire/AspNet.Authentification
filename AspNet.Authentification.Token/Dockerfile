FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["AspNet.Authentification.Token/AspNet.Authentification.Token.csproj", "AspNet.Authentification.Token/"]
RUN dotnet restore "AspNet.Authentification.Token/AspNet.Authentification.Token.csproj"
COPY . .
WORKDIR "/src/AspNet.Authentification.Token"
RUN dotnet build "AspNet.Authentification.Token.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNet.Authentification.Token.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNet.Authentification.Token.dll"]