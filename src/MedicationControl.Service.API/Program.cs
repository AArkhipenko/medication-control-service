using AArkhipenko.Core;
using AArkhipenko.Logging;
using MedicationControl.Service.API.Extensions;
using MedicationControl.Service.API.Settings;
using MedicationControl.Service.Application;

namespace MedicationControl.Service.API
{
	/// <summary>
	/// Входная точка запуска софта. Содержит основные настройки
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Входная точка приложения
		/// </summary>
		/// <param name="args">список аргументов при запуске приложения</param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			builder.Services.AddCustomHealthCheck();
			builder.Services.AddVersioning();
			// AArkhipenko.Logging
			if (builder.Environment.IsDevelopment())
			{
				builder.Logging.AddConsoleLogging();
			}
			else
			{
				builder.Logging.AddFileLogging();
			}

			// Методы расширения проектов
			builder.Services.AddMediatrExtension();
			// Добавление работы со Swagger
			builder.Services.AddSwaggerExtension();
			// Добавление возможности работы с JWT
			builder.Services.AddAuthJwt(builder.Configuration);

			var app = builder.Build();

			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			app.UseRequestChainMiddleware();
			app.UseExceptionMiddleware();
			app.UseCustomHealthCheck();
			// AArkhipenko.Logging
			app.UseLoggingMiddleware();

			// Использование Swagger
			app.UseSwaggerExtension(builder.Environment.IsDevelopment());
			// Configure the HTTP request pipeline
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			// АПИ контроля жизнеспособности приложения
			app.MapControllers();

			app.Run();
		}
	}
}