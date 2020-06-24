FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 91

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TestCookie.csproj", "TestCookie.csproj"]
RUN dotnet restore "TestCookie.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "TestCookie.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestCookie.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestCookie.dll"]