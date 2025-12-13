using MediatR;
using MedicationControl.Service.Application.Dictionary.DTO;

namespace MedicationControl.Service.Application.Dictionary.Queries;

/// <summary>
/// Запрос на получение списка пользовательского представления времени суток
/// </summary>
public class GetDayTimeTypeListQuery : IRequest<IEnumerable<Element>>
{
}