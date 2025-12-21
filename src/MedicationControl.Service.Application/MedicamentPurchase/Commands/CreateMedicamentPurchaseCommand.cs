using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;

namespace MedicationControl.Service.Application.MedicamentPurchase.Commands;

/// <summary>
/// Запрос на создание закупки лекарств
/// </summary>
public sealed class CreateMedicamentPurchaseCommand : UserBasedCommand, IRequest<int>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CreateMedicamentPurchaseCommand"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
	public CreateMedicamentPurchaseCommand(string externalUserId, CreateMedicamentPurchaseDto request)
		:base (externalUserId)
	{
		this.Request = request;
	}

	/// <summary>
	/// Запрос на создание закупки лекарств
	/// </summary>
	public CreateMedicamentPurchaseDto Request { get; }
}
