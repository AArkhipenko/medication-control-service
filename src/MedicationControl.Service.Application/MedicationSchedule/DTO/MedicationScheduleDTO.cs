namespace MedicationControl.Service.Application.MedicationSchedule.DTO
{
	/// <summary>
	/// Модель расписания приема лекарства
	/// </summary>
	public class MedicationScheduleDTO : CreateMedicationScheduleDTO
	{
		/// <summary>
		/// ИД лекарства, которое назначено пользователю
		/// </summary>
		public int MedicationScheduleId { get; set; }
    }
}
