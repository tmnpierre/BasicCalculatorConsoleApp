FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BasicCalculatorConsole.csproj", "./"]
RUN dotnet restore "BasicCalculatorConsole.csproj"
COPY . .
RUN dotnet build "BasicCalculatorConsole.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicCalculatorConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicCalculatorConsole.dll"]
