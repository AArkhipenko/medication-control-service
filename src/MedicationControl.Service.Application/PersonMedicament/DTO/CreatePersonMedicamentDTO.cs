namespace MedicationControl.Service.Application.PersonMedicament.DTO
{
	/// <summary>
	/// Контракт данных для создания связи пользователя с лекарством
	/// </summary>
    public class CreatePersonMedicamentDTO
	{
		/// <summary>
		/// ИД лекарственного средства (public.medicament_types)
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
