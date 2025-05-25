using MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Domain.Repositories
{
	/// <summary>
	/// Репозиторий для работы с расписанием приема лекарств
	/// </summary>
    public interface IMedicationScheduleRepository
    {
		/// <summary>
		/// Получение списка расписаний приема лекарств для связи пользователя с лекарством
		/// </summary>
		/// <param name="personMedicamentId">ИД связи пользователя с лекарством</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Список расписаний приема лекарств для связи пользователя с лекарством</returns>
		Task<IEnumerable<MedicationSchedule>> GetListByPersonMedicamentAsync(
			int personMedicamentId,
			CancellationToken cancellationToken);

		/// <summary>
		/// Создание расписания приема лекарств
		/// </summary>
		/// <param name="model"><inheritdoc cref="MedicationSchedule" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		Task<int> CreateAsync(
			MedicationSchedule model,
			CancellationToken cancellationToken);

		/// <summary>
		/// Получение записи
		/// </summary>
		/// <param name="medicationScheduleId">ИД записи</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns><inheritdoc cref="MedicationSchedule" path="/summary"/></returns>
		Task<MedicationSchedule> GetAsync(
			int medicationScheduleId,
			CancellationToken cancellationToken);

		/// <summary>
		/// Изменения расписания приема лекарств
		/// </summary>
		/// <param name="model"><inheritdoc cref="MedicationSchedule" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		Task UpdateAsync(
			MedicationSchedule model,
			CancellationToken cancellationToken);
	}
}
