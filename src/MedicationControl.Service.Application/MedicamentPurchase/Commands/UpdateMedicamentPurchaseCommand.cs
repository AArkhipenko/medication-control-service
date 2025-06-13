using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;

namespace MedicationControl.Service.Application.MedicamentPurchase.Commands
{
	/// <summary>
	/// Запрос на изменение закупки лекарств
	/// </summary>
    public class UpdateMedicamentPurchaseCommand : UserBasedCommand, IRequest<Unit>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateMedicamentPurchaseCommand"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public UpdateMedicamentPurchaseCommand(int userId, MedicamentPurchaseDTO request)
			:base (userId)
		{
			this.Request = request;
		}

		/// <summary>
		/// Модель закупки лекарств
		/// </summary>
		public MedicamentPurchaseDTO Request { get; }
	}
}
