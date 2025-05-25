namespace MedicationControl.Service.Domain.Models
{
	/// <summary>
	/// Раписание приема лекарств
	/// </summary>
    public class MedicationSchedule
    {
		/// <summary>
		/// ИД расписания
		/// </summary>
		public int Id { get; set; }

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
