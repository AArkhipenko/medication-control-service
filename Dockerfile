# Образ для сборки
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
# Копирование сборки
COPY ./src/MedicationControl.Service.API/bin/Release/net*/ ./
# Запуск приложения
ENTRYPOINT ["dotnet", "MedicationControl.Service.API.dll"]