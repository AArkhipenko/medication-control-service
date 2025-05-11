using AArkhipenko.Core;
using AArkhipenko.Keycloak.Security;
using AArkhipenko.Logging;
using AArkhipenko.Swagger;
using AArkhipenko.Swagger.Models;
using MedicationControl.Service.Application;
using MedicationControl.Service.Infrastructure;
using Microsoft.OpenApi.Models;

namespace MedicationControl.Service.API
{
	/// <summary>
	/// Входная точка запуска софта. Содержит основные настройки
	/// </summary>
	public class Program
	{
		private readonly static OpenApiInfo[] _versions = new[]
{
			new OpenApiInfo
			{
				Version = "v10",
				Title = "MedicationControl.Service API v1.0"
			}
		};

		/// <summary>
		/// Входная точка приложения
		/// </summary>
		/// <param name="args">список аргументов при запуске приложения</param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
#if DEBUG
			builder.Configuration.AddYamlFile("DebugConfig.yml", false);
#endif

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
			// AArkhipenko.Swagger
			builder.Services.AddCustomSwagger(_versions, new[]
			{
				new SecurityModel(KeycloakSecurityScheme.DefaultKey, KeycloakSecurityScheme.Default)
			});

			// Методы расширения проектов
			builder.Services.AddMediatrExtension();
			builder.Services.AddInfrastructure(builder.Configuration);

			var app = builder.Build();

			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			app.UseRequestChainMiddleware();
			app.UseExceptionMiddleware();
			app.UseCustomHealthCheck();
			// AArkhipenko.Logging
			app.UseLoggingMiddleware();
			// AArkhipenko.Swagger
			app.UseCustomSwagger(_versions);

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