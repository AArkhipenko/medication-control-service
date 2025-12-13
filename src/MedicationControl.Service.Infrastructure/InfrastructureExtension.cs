using AArkhipenko.Keycloak;
using AArkhipenko.UserHelper;
using MedicationControl.Service.Domain.Repositories;
using MedicationControl.Service.Infrastructure.Database;
using MedicationControl.Service.Infrastructure.Database.Repositories;
using MedicationControl.Service.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedicationControl.Service.Infrastructure
{
	/// <summary>
	/// Методы расширешения уровня Infrastructure
	/// </summary>
	public static class InfrastructureExtension
	{
		/// <summary>
		/// Добавление всех расширений с уровня Infrastructure
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="configuration"><see cref="IConfiguration"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
			=> services
				.AddDbContext(configuration)
				.AddRepositories()
				.AddKeycloakAuth(configuration)
				.AddUserHelper(configuration)
				.AddAutoMapper();

		/// <summary>
		/// Добавление контекста БД
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString(Consts.ConnectionString) ??
				throw new ApplicationException($"Не задана строка подключения к БД контроля приема лекарственных средств. " +
					$"Раздел ConnectionStrings:{Consts.ConnectionString}.");

			services.AddDbContext<ControlContext>((options) =>
			{
				options.UseNpgsql(connectionString);
			});

			return services;
		}

		/// <summary>
		/// Добавление репозиториев
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddRepositories(this IServiceCollection services)
			=> services
				.AddScoped<IDictionaryRepository, DictionaryRepository>()
				.AddScoped<IPersonMedicamentRepository, PersonMedicamentRepository>()
				.AddScoped<IMedicationScheduleRepository, MedicationScheduleRepository>()
				.AddScoped<IMedicamentPurchaseRepository, MedicamentPurchaseRepository>();

		/// <summary>
		/// Добавление автомапперов
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddAutoMapper(this IServiceCollection services)
			=> services
				.AddAutoMapper(typeof(DbDomainProfile));
	}
}
