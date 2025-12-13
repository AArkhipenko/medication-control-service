namespace MedicationControl.Service.Application.MedicamentPurchase.DTO
{
	/// <summary>
	/// Модель закупки лекарства
	/// </summary>
	public class MedicamentPurchaseDTO : CreateMedicamentPurchaseDTO
	{
		/// <summary>
		/// ИД закупки лекарства
		/// </summary>
		public int MedicamentPurchaseId { get; set; }
	}
}
