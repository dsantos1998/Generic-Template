FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DSM.MJMLEditor.APIRest/DSM.MJMLEditor.APIRest.csproj", "DSM.MJMLEditor.APIRest/"]
COPY ["DSM.MJMLEditor.BLL/DSM.MJMLEditor.BLL.csproj", "DSM.MJMLEditor.BLL/"]
COPY ["DSM.MJMLEditor.Models/DSM.MJMLEditor.Models.csproj", "DSM.MJMLEditor.Models/"]
COPY ["DSM.MJMLEditor.Helpers/DSM.MJMLEditor.Helpers.csproj", "DSM.MJMLEditor.Helpers/"]
COPY ["DSM.MJMLEditor.Resources/DSM.MJMLEditor.Resources.csproj", "DSM.MJMLEditor.Resources/"]
COPY ["DSM.MJMLEditor.DLL/DSM.MJMLEditor.DLL.csproj", "DSM.MJMLEditor.DLL/"]
RUN dotnet restore "./DSM.MJMLEditor.APIRest/./DSM.MJMLEditor.APIRest.csproj"
COPY . .
WORKDIR "/src/DSM.MJMLEditor.APIRest"
RUN dotnet build "./DSM.MJMLEditor.APIRest.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DSM.MJMLEditor.APIRest.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSM.MJMLEditor.APIRest.dll"]