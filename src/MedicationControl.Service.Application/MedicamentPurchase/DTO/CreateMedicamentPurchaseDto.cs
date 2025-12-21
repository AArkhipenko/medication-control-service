namespace MedicationControl.Service.Application.MedicamentPurchase.DTO;

/// <summary>
/// Модель для создания закупки лекарства.
/// </summary>
public record CreateMedicamentPurchaseDto
{
	/// <summary>
	/// ИД связи пользователя с лекарством.
	/// </summary>
	public required int PersonMedicamentId { get; init; }

	/// <summary>
	/// Количество лекарств для закупки.
	/// </summary>
	public required int PurchaseAmount { get; init; }

	/// <summary>
	/// Оставшееся количество лекарства.
	/// </summary>
	public int? RemainingAmount { get; init; }

	/// <summary>
	/// Дата закупки.
	/// </summary>
	public required DateOnly Date { get; init; }
}
