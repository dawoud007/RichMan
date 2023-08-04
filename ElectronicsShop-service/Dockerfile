# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /RichMan

EXPOSE 443
EXPOSE 80

COPY *.csproj .

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final-env
WORKDIR /RichMan

COPY --from=build-env /RichMan/out/ ./
EXPOSE 5000

# Explicitly set the destination path to "/app"
ENTRYPOINT ["dotnet", "ElectronicsShop-service.dll"]
 