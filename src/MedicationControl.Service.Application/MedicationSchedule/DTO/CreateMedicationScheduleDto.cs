namespace MedicationControl.Service.Application.MedicationSchedule.DTO;

/// <summary>
/// Модель для создания расписания приема лекарства.
/// </summary>
/// <remarks>
/// Либо задается свойство <see cref="DayTimeTypeId"/>, либо <see cref="Time"/>.
/// Если заданы оба свойства, тогда остается <see cref="DayTimeTypeId"/>.
/// </remarks>
public record CreateMedicationScheduleDto
{
	/// <summary>
	/// ИД лекарства, которое назначено пользователю.
	/// </summary>
	public required int PersonMedicamentId { get; init; }

	/// <summary>
	/// Время суток для приема лекарства.
	/// </summary>
	public int? DayTimeTypeId { get; init; }

	/// <summary>
	/// Время для приема лекарства.
	/// </summary>
	public TimeOnly? Time { get; init; }

	/// <summary>
	/// Количество лекарства для приема единовременно.
	/// </summary>
	public required double Amount { get; init; }
}
