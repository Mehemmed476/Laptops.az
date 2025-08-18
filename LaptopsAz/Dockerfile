# Stage 1: Build Aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyalarını ana dizine göre, LaptopsAzSolution/ altından kopyala
COPY ["LaptopsAzSolution/LaptopsAz.PL/LaptopsAz.PL.csproj", "LaptopsAz.PL/"]
COPY ["LaptopsAzSolution/LaptopsAz.BL/LaptopsAz.BL.csproj", "LaptopsAz.BL/"]
COPY ["LaptopsAzSolution/LaptopsAz.DL/LaptopsAz.DL.csproj", "LaptopsAz.DL/"]
COPY ["LaptopsAzSolution/LaptopsAz.Core/LaptopsAz.Core.csproj", "LaptopsAz.Core/"]
COPY ["LaptopsAzSolution/LaptopsAz.sln", "."]

RUN dotnet restore "LaptopsAz.sln"

# Tüm proje kodlarını kopyala (ana dizindeki LaptopsAzSolution klasörünü kopyala)
COPY ["LaptopsAzSolution/", "."]
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