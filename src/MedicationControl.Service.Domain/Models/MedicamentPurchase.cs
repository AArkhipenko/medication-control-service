namespace MedicationControl.Service.Domain.Models
{
	/// <summary>
	/// Модель закупки лекарства
	/// </summary>
    public class MedicamentPurchase
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
	}
}
