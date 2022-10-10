FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5200

ENV ASPNETCORE_URLS=http://+:5200

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PageCom.api.App/PageCom.api.App.csproj", "PageCom.api.App/"]
COPY ["PageCom.Api.Application/PageCom.Api.Application.csproj", "PageCom.Api.Application/"]
COPY ["PageCome.Api.Demain/PageCome.Api.Demain.csproj", "PageCome.Api.Demain/"]
COPY ["PageCom.api.infastructure/PageCom.api.infastructure.csproj", "PageCom.api.infastructure/"]
COPY ["pageCom.api.Data/pageCom.api.Data.csproj", "pageCom.api.Data/"]
RUN dotnet restore "PageCom.api.App/PageCom.api.App.csproj"
COPY . .
WORKDIR "/src/PageCom.api.App"
RUN dotnet build "PageCom.api.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PageCom.api.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PageCom.api.App.dll"]
