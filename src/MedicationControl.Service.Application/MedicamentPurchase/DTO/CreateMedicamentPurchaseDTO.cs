namespace MedicationControl.Service.Application.MedicamentPurchase.DTO
{
	/// <summary>
	/// Модель для создания закупки лекарства
	/// </summary>
	public class CreateMedicamentPurchaseDTO
	{
		/// <summary>
		/// ИД связи пользователя с лекарством
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
