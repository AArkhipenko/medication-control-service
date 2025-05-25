using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MedicationControl.Service.Infrastructure.Database.Tables
{
	/// <summary>
	/// Модель записи таблицы control.medicament_purchases
	/// </summary>
	internal class MedicamentPurchase
	{
		/// <summary>
		/// ИД
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ИД связи пользователя с лекарством (control.person_medicaments)
		/// </summary>
		public int PersonMedicamentId { get; set; }

		/// <summary>
		/// Количество лекарств для закупки
		/// </summary>
		public int PurchaseAmount { get; set; }

		/// <summary>
		/// Оставшееся количество лекарства
		/// </summary>
		public int? RemainingAmount { get; set; }

		/// <summary>
		/// Дата закупки
		/// </summary>
		public DateOnly Date { get; set; }

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="ModelBuilder"/></param>
		public static void Configure(ModelBuilder builder)
			=> Configure(builder.Entity<MedicamentPurchase>());

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		private static void Configure(EntityTypeBuilder<MedicamentPurchase> builder)
		{
			builder.ToTable("medicament_purchases", "control")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<int>(p => p.PersonMedicamentId)
				.HasColumnName("person_medicament_id")
				.IsRequired();

			builder
				.Property<int>(p => p.PurchaseAmount)
				.HasColumnName("purchase_amount")
				.IsRequired();

			builder
				.Property<int?>(p => p.RemainingAmount)
				.HasColumnName("remaining_amount");

			builder
				.Property<DateOnly>(p => p.Date)
				.HasColumnName("date")
				.IsRequired();
		}
	}
}
