namespace MedicationControl.Service.Application.PersonMedicament.DTO
{
	/// <summary>
	/// Контракт данных для изменения связи пользователя с лекарством
	/// </summary>
    public class PersonMedicamentDTO : CreatePersonMedicamentDTO
	{
		/// <summary>
		/// ИД связи пользователя и лекарственного средства
		/// </summary>
		public int PersonMedicamentId { get; set; }
	}
}
