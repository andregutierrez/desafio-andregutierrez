#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV DEFAULT_CONNECTION=NAO-DEFINIDO

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AndreGutierrez.API/AndreGutierrez.API.csproj", "src/AndreGutierrez.API/"]
COPY ["src/AndreGutierrez.Application/AndreGutierrez.Application.csproj", "src/AndreGutierrez.Application/"]
COPY ["src/AndreGutierrez.Infra.CrossCutting.IoC/AndreGutierrez.Infra.CrossCutting.IoC.csproj", "src/AndreGutierrez.Infra.CrossCutting.IoC/"]
COPY ["src/AndreGutierrez.Infra.Data/AndreGutierrez.Infra.Data.csproj", "src/AndreGutierrez.Infra.Data/"]
COPY ["src/AndreGutierrez.Domain/AndreGutierrez.Domain.csproj", "src/AndreGutierrez.Domain/"]
RUN dotnet restore "src/AndreGutierrez.API/AndreGutierrez.API.csproj"
COPY . .
WORKDIR "/src/src/AndreGutierrez.API"
RUN dotnet build "AndreGutierrez.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AndreGutierrez.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AndreGutierrez.API.dll"]
