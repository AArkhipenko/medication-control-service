namespace MedicationControl.Service.Application.MedicamentPurchase.DTO;

/// <summary>
/// Модель закупки лекарства.
/// </summary>
public sealed record MedicamentPurchaseDto : CreateMedicamentPurchaseDto
{
	/// <summary>
	/// ИД закупки лекарства.
	/// </summary>
	public required int MedicamentPurchaseId { get; init; }
}

