FROM microsoft/dotnet:3.0-sdk AS build
#ENV ASPNETCORE_ENVIRONMENT=Development
#ENV ASPNETCORE_URLS=http://:80/;https://:443/
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish  -c Release -o out
RUN ls -alrth .
# RUN dotnet --version
# RUN dotnet --list-sdks
# RUN dotnet --list-runtimes 

## test application -- see: dotnet-docker-unit-testing.md
# FROM build AS test
# WORKDIR /app/tests
# COPY tests/. .
# ENTRYPOINT ["dotnet", "test", "--logger:trx"]

# Build runtime image
#FROM microsoft/dotnet:3.0-aspnetcore-runtime AS runtime
#WORKDIR /app
#COPY --from=build /app/out ./
RUN ls -alrt out
# RUN dotnet dev-certs https --check -v
#EXPOSE 80
#EXPOSE 443
ENTRYPOINT ["dotnet", "out/dockercompose.dll"]
#ENTRYPOINT ["dockercompose"]