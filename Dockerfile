# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /source/aspnetapp

# copy csproj and restore as distinct layers
COPY *.csproj .
# copy everything else and build app
COPY . .
# restore the dependencies if any
RUN dotnet restore

# publish the web app into /app with no restore (since just did it)
RUN dotnet publish --output "/app" --configuration release --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./

# ATTENTION => change this dll to match the name of the csproj file of your web app
ENTRYPOINT ["dotnet", "launchPad.dll"]