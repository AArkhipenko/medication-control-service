using MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Domain.Repositories
{
	/// <summary>
	/// Репозиторий для работы с лекарственными средствами, назначенными пользователю
	/// </summary>
    public interface IPersonMedicamentRepository
    {
		/// <summary>
		/// Создание записи
		/// </summary>
		/// <param name="model"><inheritdoc cref="PersonMedicament" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		Task<int> CreateAsync(PersonMedicament model, CancellationToken cancellationToken);

		/// <summary>
		/// Получение записи
		/// </summary>
		/// <param name="personMedicamentId">ИД записи</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns><inheritdoc cref="PersonMedicament" path="/summary"/></returns>
		Task<PersonMedicament> GetAsync(int personMedicamentId, CancellationToken cancellationToken);
	}
}
