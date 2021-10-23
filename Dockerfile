#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY *.sln .

COPY ["WitchSaga.Application/WitchSaga.Application.csproj", "WitchSaga.Application/"]
COPY ["WitchSaga.Common/WitchSaga.Common.csproj", "WitchSaga.Common/"]
COPY ["WitchSaga.WebApi/WitchSaga.WebApi.csproj", "WitchSaga.WebApi/"]
RUN dotnet restore "WitchSaga.WebApi/WitchSaga.WebApi.csproj"
COPY . .
WORKDIR "/src/WitchSaga.WebApi"
RUN dotnet build "WitchSaga.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WitchSaga.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WitchSaga.WebApi.dll"]