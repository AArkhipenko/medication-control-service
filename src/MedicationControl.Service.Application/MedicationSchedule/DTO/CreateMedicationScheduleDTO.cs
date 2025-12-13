namespace MedicationControl.Service.Application.MedicationSchedule.DTO
{
	/// <summary>
	/// Модель для создания расписания приема лекарства
	/// </summary>
	/// <remarks>
	/// Либо задается свойство <see cref="DayTimeTypeId"/>, либо <see cref="Time"/>
	/// Если заданы оба свойства, тогда остается <see cref="DayTimeTypeId"/>
	/// </remarks>
	public class CreateMedicationScheduleDTO
    {
		/// <summary>
		/// ИД лекарства, которое назначено пользователю
		/// </summary>
		public int PersonMedicamentId { get; set; }

		/// <summary>
		/// Время суток для приема лекарства
		/// </summary>
		public int? DayTimeTypeId { get; set; }

		/// <summary>
		/// Время для приема лекарства
		/// </summary>
		public TimeOnly? Time { get; set; }

		/// <summary>
		/// Количество лекарства для приема единовременно
		/// </summary>
		public double Amount { get; set; }
    }
}
