using MediatR;
using MedicationControl.Service.Application.Dictionary.DTO;

namespace MedicationControl.Service.Application.Dictionary.Queries;

/// <summary>
/// Запрос на получение списка лекарственных средств
/// </summary>
public class GetMedicamentTypeListQuery: IRequest<IEnumerable<Element>>
{
}