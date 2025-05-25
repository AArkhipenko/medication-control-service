using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;

namespace MedicationControl.Service.Application.MedicamentPurchase.Commands
{
	/// <summary>
	/// Запрос на создание закупки лекарств
	/// </summary>
    public class CreateMedicamentPurchaseCommand : UserBasedCommand, IRequest<int>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="CreateMedicamentPurchaseCommand"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public CreateMedicamentPurchaseCommand(int userId, CreateMedicamentPurchaseDTO request)
			:base (userId)
		{
			this.Request = request;
		}

		/// <summary>
		/// Запрос на создание закупки лекарств
		/// </summary>
		public CreateMedicamentPurchaseDTO Request { get; }
	}
}
