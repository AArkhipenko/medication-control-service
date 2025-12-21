namespace MedicationControl.Service.Application.PersonMedicament.DTO;

/// <summary>
/// Контракт данных для создания связи пользователя с лекарством.
/// </summary>
public record CreatePersonMedicamentDto
{
	/// <summary>
	/// ИД лекарственного средства.
	/// </summary>
	public required int MedicamentTypeId { get; init; }

	/// <summary>
	/// Дата начала приема лекарственного средства.
	/// </summary>
	public required DateOnly StartDate { get; init; }

	/// <summary>
	/// Дата завершения приема лекарственного средства.
	/// </summary>
	public DateOnly? EndDate { get; init; }
}
