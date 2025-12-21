namespace MedicationControl.Service.Application.MedicationSchedule.DTO;

/// <summary>
/// Модель расписания приема лекарства.
/// </summary>
public sealed record MedicationScheduleDto : CreateMedicationScheduleDto
{
	/// <summary>
	/// ИД лекарства, которое назначено пользователю.
	/// </summary>
	public required int MedicationScheduleId { get; init; }
}
