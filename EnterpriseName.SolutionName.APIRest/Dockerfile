FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EnterpriseName.SolutionName.APIRest/EnterpriseName.SolutionName.APIRest.csproj", "EnterpriseName.SolutionName.APIRest/"]
COPY ["EnterpriseName.SolutionName.BLL/EnterpriseName.SolutionName.BLL.csproj", "EnterpriseName.SolutionName.BLL/"]
COPY ["EnterpriseName.SolutionName.Models/EnterpriseName.SolutionName.Models.csproj", "EnterpriseName.SolutionName.Models/"]
COPY ["EnterpriseName.SolutionName.Helpers/EnterpriseName.SolutionName.Helpers.csproj", "EnterpriseName.SolutionName.Helpers/"]
COPY ["EnterpriseName.SolutionName.Resources/EnterpriseName.SolutionName.Resources.csproj", "EnterpriseName.SolutionName.Resources/"]
COPY ["EnterpriseName.SolutionName.DLL/EnterpriseName.SolutionName.DLL.csproj", "EnterpriseName.SolutionName.DLL/"]
RUN dotnet restore "./EnterpriseName.SolutionName.APIRest/./EnterpriseName.SolutionName.APIRest.csproj"
COPY . .
WORKDIR "/src/EnterpriseName.SolutionName.APIRest"
RUN dotnet build "./EnterpriseName.SolutionName.APIRest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EnterpriseName.SolutionName.APIRest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnterpriseName.SolutionName.APIRest.dll"]