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
		/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
		/// <param name="medicamentPurchaseId"><inheritdoc cref="MedicamentPurchaseId" path="/summary"/></param>
		public DeleteMedicamentPurchaseCommand(string externalUserId, int medicamentPurchaseId)
			:base (externalUserId)
		{
			this.MedicamentPurchaseId = medicamentPurchaseId;
		}

		/// <summary>
		/// ИД закупки лекарств
		/// </summary>
		public int MedicamentPurchaseId { get; }
	}
}
