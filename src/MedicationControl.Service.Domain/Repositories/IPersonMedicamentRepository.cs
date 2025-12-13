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

		/// <summary>
		/// Изменение записи
		/// </summary>
		/// <param name="model"><inheritdoc cref="PersonMedicament" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		Task UpdateAsync(PersonMedicament model, CancellationToken cancellationToken);

		/// <summary>
		/// Изменение записи
		/// </summary>
		/// <param name="personMedicamentId">ИД связи пользователя с лекарственным средством</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		Task DeleteAsync(int personMedicamentId, CancellationToken cancellationToken);

		/// <summary>
		/// Получение списка записей, связанных с пользователем
		/// </summary>
		/// <param name="externalUserId">ИД пользователя</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Список <see cref="PersonMedicament"/></returns>
		Task<IEnumerable<PersonMedicament>> GetListByUserAsync(string externalUserId, CancellationToken cancellationToken);
	}
}
