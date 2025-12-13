namespace MedicationControl.Service.Domain.Models
{
	/// <summary>
	/// Лекарственное средство, назначенное пользователю
	/// </summary>
	public class PersonMedicament
    {
		/// <summary>
		/// ИД
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalUserId { get; set; }

		/// <summary>
		/// ИД лекарственного средства
		/// </summary>
		public int MedicamentTypeId { get; set; }

		/// <summary>
		/// Дата начала приема лекарственного средства
		/// </summary>
		public DateOnly StartDate { get; set; }

		/// <summary>
		/// Дата завершения приема лекарственного средства
		/// </summary>
		public DateOnly? EndDate { get; set; }
	}
}
