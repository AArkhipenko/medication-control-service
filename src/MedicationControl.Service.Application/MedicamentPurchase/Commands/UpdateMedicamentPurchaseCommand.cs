using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;

namespace MedicationControl.Service.Application.MedicamentPurchase.Commands
{
	/// <summary>
	/// Запрос на изменение закупки лекарств
	/// </summary>
    public class UpdateMedicamentPurchaseCommand : UserBasedCommand, IRequest
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateMedicamentPurchaseCommand"/> class.
		/// </summary>
		/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public UpdateMedicamentPurchaseCommand(string externalUserId, MedicamentPurchaseDTO request)
			:base (externalUserId)
		{
			this.Request = request;
		}

		/// <summary>
		/// Модель закупки лекарств
		/// </summary>
		public MedicamentPurchaseDTO Request { get; }
	}
}
