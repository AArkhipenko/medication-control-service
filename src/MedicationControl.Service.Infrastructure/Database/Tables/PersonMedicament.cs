using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicationControl.Service.Infrastructure.Database.Tables
{
	/// <summary>
	/// Модель записи таблицы control.person_medicaments
	/// </summary>
	internal class PersonMedicament
    {
		/// <summary>
		/// ИД
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalUserId { get; set; }

		/// <summary>
		/// ИД лекарственного средства (public.medicament_types)
		/// </summary>
		public int MedicamentTypeId { get; set; }

		/// <summary>
		/// Дата начала приема лекарственного средства
		/// </summary>
		public DateOnly StartDate { get; set; }

		/// <summary>
		/// Дата завершения приема лекарственного средства
		/// </summary>
		public DateOnly? EndDate { get; set; }

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="ModelBuilder"/></param>
		public static void Configure(ModelBuilder builder)
			=> Configure(builder.Entity<PersonMedicament>());

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		private static void Configure(EntityTypeBuilder<PersonMedicament> builder)
		{
			builder.ToTable("person_medicaments", "control")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<string>(p => p.ExternalUserId)
				.HasColumnName("user_external_id")
				.IsRequired();

			builder
				.Property<int>(p => p.MedicamentTypeId)
				.HasColumnName("medicament_type_id")
				.IsRequired();

			builder
				.Property<DateOnly>(p => p.StartDate)
				.HasColumnName("start_date")
				.IsRequired();

			builder
				.Property<DateOnly?>(p => p.EndDate)
				.HasColumnName("end_date");
		}
	}
}
