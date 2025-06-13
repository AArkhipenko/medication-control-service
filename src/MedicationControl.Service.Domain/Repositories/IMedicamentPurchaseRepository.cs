using MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Domain.Repositories
{
	/// <summary>
	/// Интерфейс для работы с закупками лекарств
	/// </summary>
    public interface IMedicamentPurchaseRepository
	{
		/// <summary>
		/// Создание закупки лекарств
		/// </summary>
		/// <param name="model"><inheritdoc cref="MedicamentPurchase" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		Task<int> CreateAsync(
			MedicamentPurchase model,
			CancellationToken cancellationToken);

		/// <summary>
		/// Запрос на получение закупки лекарства по ИД
		/// </summary>
		/// <param name="medicamentPurchaseId">ИД закупки</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns><inheritdoc cref="MedicamentPurchase" path="/summary"/></returns>
		Task<MedicamentPurchase> GetAsync(
			int medicamentPurchaseId,
			CancellationToken cancellationToken);
	}
}
