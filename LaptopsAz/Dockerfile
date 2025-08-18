# Stage 1: Build Aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyalarını ana dizine göre, LaptopsAzRepo/ altından kopyala
COPY ["LaptopsAzRepo/LaptopsAz.PL/LaptopsAz.PL.csproj", "LaptopsAz.PL/"]
COPY ["LaptopsAzRepo/LaptopsAz.BL/LaptopsAz.BL.csproj", "LaptopsAz.BL/"]
COPY ["LaptopsAzRepo/LaptopsAz.DL/LaptopsAz.DL.csproj", "LaptopsAz.DL/"]
COPY ["LaptopsAzRepo/LaptopsAz.Core/LaptopsAz.Core.csproj", "LaptopsAz.Core/"]
COPY ["LaptopsAzRepo/LaptopsAz.sln", "."]

RUN dotnet restore "LaptopsAz.sln"

# Tüm proje kodlarını kopyala (ana dizindeki LaptopsAzRepo klasörünü kopyala)
COPY ["LaptopsAzRepo/", "."]
WORKDIR "/src/LaptopsAz.PL"
RUN dotnet build "LaptopsAz.PL.csproj" -c Release -o /app/build

# Stage 2: Publish Aşaması
FROM build AS publish
RUN dotnet publish "LaptopsAz.PL.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final Aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "LaptopsAz.PL.dll"]