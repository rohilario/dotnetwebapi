FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["dotnetwebapi.csproj", "./"]
RUN dotnet restore "dotnetwebapi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "dotnetwebapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnetwebapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetwebapi.dll"]