FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "PageCom.api.App/PageCom.api.App.csproj"
WORKDIR "/src/PageCom.api.App"
RUN dotnet build "PageCom.api.App.csproj" -c Release -o /app/build


FROM build AS publish
WORKDIR "/src/PageCom.api.App"
RUN dotnet publish "PageCom.api.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PageCom.api.App.dll"]
