namespace MedicationControl.Service.Application.PersonMedicament.DTO;

/// <summary>
/// Контракт данных для изменения связи пользователя с лекарством.
/// </summary>
public sealed record PersonMedicamentDto : CreatePersonMedicamentDto
{
	/// <summary>
	/// ИД связи пользователя и лекарственного средства.
	/// </summary>
	public required int PersonMedicamentId { get; init; }
}
