using MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Domain.Repositories;

/// <summary>
/// Репозитория для работы с элементами справочников
/// </summary>
public interface IDictionaryRepository
{
    /// <summary>
    /// Получение списка лекарственных средств
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Список лекарственных средств</returns>
    Task<IEnumerable<DictionaryElement>> GetMedicamentTypeList(CancellationToken cancellationToken);

    /// <summary>
    /// Получение списка пользовательского представления времени суток
    /// </summary>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns>Список пользовательского представления времени суток</returns>
    Task<List<DictionaryElement>> GetDayTimeTypeList(CancellationToken cancellationToken);
}