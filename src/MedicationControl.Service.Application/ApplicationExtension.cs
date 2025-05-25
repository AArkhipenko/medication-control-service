using MedicationControl.Service.Application.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicationControl.Service.Application
{
	/// <summary>
	/// Методы расширешения уроdня Application
	/// </summary>
	public static class ApplicationExtension
	{
		/// <summary>
		/// Добавление всех расширений с уровня Application
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddApplication(this IServiceCollection services)
			=> services
			.AddMediatr()
			.AddAutoMapper();

		/// <summary>
		/// Добавление поддержки Mediatr для текущего проекта
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddMediatr(this IServiceCollection services)
		{
			_ = services.AddMediatR(conf =>
				conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			return services;
		}

		/// <summary>
		/// Добавление автомапперов
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddAutoMapper(this IServiceCollection services)
			=> services
			.AddAutoMapper(typeof(CommandDomainProfile))
			.AddAutoMapper(typeof(DomainDtoProfile));
	}
}
