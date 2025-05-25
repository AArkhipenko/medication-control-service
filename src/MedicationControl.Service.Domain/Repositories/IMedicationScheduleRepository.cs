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
	}
}
