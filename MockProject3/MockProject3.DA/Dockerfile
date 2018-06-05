# start with microsoft's asp.net core 2.0 build image
FROM microsoft/aspnetcore-build:2.0

# "Change directory" in the container to here
WORKDIR /app
# copy everything from the project folder into the container
COPY . .

# package restore (looks at .csproj for nuget packages)
RUN dotnet restore
RUN dotnet build
# RUN dotnet test
# sonarqube
RUN dotnet publish -o ./out

# start the container by running "dotnet DockerizedMvc2.Api.dll"
WORKDIR /app/out
ENTRYPOINT [ "dotnet", "MockProject3.DA.dll"]