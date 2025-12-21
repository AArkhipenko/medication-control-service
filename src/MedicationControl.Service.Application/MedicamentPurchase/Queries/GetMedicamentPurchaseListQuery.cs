using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;

namespace MedicationControl.Service.Application.MedicamentPurchase.Queries;

/// <summary>
/// Запрос на получение списка закупок лекарств
/// </summary>
public sealed class GetMedicamentPurchaseListQuery : UserBasedCommand, IRequest<IEnumerable<MedicamentPurchaseDto>>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GetMedicamentPurchaseListQuery"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	public GetMedicamentPurchaseListQuery(string externalUserId)
		: base(externalUserId)
	{
	}
}
