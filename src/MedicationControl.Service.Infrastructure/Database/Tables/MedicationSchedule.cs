using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicationControl.Service.Infrastructure.Database.Tables
{
	/// <summary>
	/// Модель записи таблицы control.medication_schedules
	/// </summary>
	internal class MedicationSchedule
	{
		/// <summary>
		/// ИД
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ИД связи пользователя с лекарством (control.person_medicaments)
		/// </summary>
		public int PersoMedicamentId { get; set; }

		/// <summary>
		/// ИД времени суток (public.medicament_types)
		/// </summary>
		public int? DayTimeTypeId { get; set; }

		/// <summary>
		/// Время принятия лекарства
		/// </summary>
		public TimeOnly? Time { get; set; }

		/// <summary>
		/// Количество лекарства для приема единовременно
		/// </summary>
		public double Amount { get; set; }

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="ModelBuilder"/></param>
		public static void Configure(ModelBuilder builder)
			=> Configure(builder.Entity<MedicationSchedule>());

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		private static void Configure(EntityTypeBuilder<MedicationSchedule> builder)
		{
			builder.ToTable("medication_schedules", "control")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<int>(p => p.PersoMedicamentId)
				.HasColumnName("person_medicament_id")
				.IsRequired();

			builder
				.Property<int?>(p => p.DayTimeTypeId)
				.HasColumnName("day_time_type_id");

			builder
				.Property<TimeOnly?>(p => p.Time)
				.HasColumnName("time");

			builder
				.Property<double>(p => p.Amount)
				.HasColumnName("amount")
				.IsRequired();
		}
	}
}
