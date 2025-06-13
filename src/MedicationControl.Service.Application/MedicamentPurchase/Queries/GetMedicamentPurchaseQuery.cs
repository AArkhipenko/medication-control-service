using MediatR;
using MedicationControl.Service.Application.Common;
using DomainModel = MedicationControl.Service.Domain.Models.MedicamentPurchase;

namespace MedicationControl.Service.Application.MedicamentPurchase.Queries
{
	/// <summary>
	/// Запрос на получение зкупки лекарств
	/// </summary>
    internal class GetMedicamentPurchaseQuery : UserBasedCommand, IRequest<DomainModel>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="GetMedicamentPurchaseQuery"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="medicamentPurchaseId"><inheritdoc cref="MedicamentPurchaseId" path="/summary"/></param>
		public GetMedicamentPurchaseQuery(int userId, int medicamentPurchaseId)
			: base(userId)
		{
			this.MedicamentPurchaseId = medicamentPurchaseId;
		}

		/// <summary>
		/// ИД закупки лекарств
		/// </summary>
		public int MedicamentPurchaseId { get; }
	}
}
