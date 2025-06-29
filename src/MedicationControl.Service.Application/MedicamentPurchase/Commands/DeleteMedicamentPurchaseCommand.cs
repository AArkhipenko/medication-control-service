using MediatR;
using MedicationControl.Service.Application.Common;

namespace MedicationControl.Service.Application.MedicamentPurchase.Commands
{
	/// <summary>
	/// Запрос на удаление закупки лекарств
	/// </summary>
    public class DeleteMedicamentPurchaseCommand : UserBasedCommand, IRequest
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteMedicamentPurchaseCommand"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="medicamentPurchaseId"><inheritdoc cref="MedicamentPurchaseId" path="/summary"/></param>
		public DeleteMedicamentPurchaseCommand(int userId, int medicamentPurchaseId)
			:base (userId)
		{
			this.MedicamentPurchaseId = medicamentPurchaseId;
		}

		/// <summary>
		/// ИД закупки лекарств
		/// </summary>
		public int MedicamentPurchaseId { get; }
	}
}
