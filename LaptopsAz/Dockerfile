# Stage 1: Build Aşaması - Projeyi derlemek için .NET 8 SDK kullanıyoruz.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyalarını kopyala (.csproj) ve bağımlılıkları yükle (dotnet restore).
# Sadece .csproj dosyalarını önce kopyalamak, NuGet paketlerini cache'lememizi sağlar.
# Kod değişmediği sürece bu adımlar tekrar çalışmaz ve build hızlanır.
COPY ["LaptopsAz.PL/LaptopsAz.PL.csproj", "LaptopsAz.PL/"]
COPY ["LaptopsAz.BL/LaptopsAz.BL.csproj", "LaptopsAz.BL/"]
COPY ["LaptopsAz.DL/LaptopsAz.DL.csproj", "LaptopsAz.DL/"]
COPY ["LaptopsAz.Core/LaptopsAz.Core.csproj", "LaptopsAz.Core/"]
# Çözüm dosyasını (solution file) da kopyalayalım
COPY ["LaptopsAz.sln", "."]

RUN dotnet restore "LaptopsAz.sln"

# Tüm proje kodlarını kopyala
COPY . .
WORKDIR "/src/LaptopsAz.PL"
RUN dotnet build "LaptopsAz.PL.csproj" -c Release -o /app/build

# Stage 2: Publish Aşaması - Derlenmiş projeyi yayınla
FROM build AS publish
RUN dotnet publish "LaptopsAz.PL.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Final Aşaması - Sadece uygulamanın çalışması için gerekli ortamı kur
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Uygulamanın hangi porttan yayın yapacağını belirtiyoruz.
EXPOSE 8080

# Konteyner çalıştığında çalıştırılacak olan komut
ENTRYPOINT ["dotnet", "LaptopsAz.PL.dll"]