using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Queries
{
	/// <summary>
	/// Запрос на получение полного списка лекарств, назначенных пользователю
	/// </summary>
	public class GetPersonMedicamentListQuery : UserBasedCommand, IRequest<IEnumerable<PersonMedicamentDTO>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetPersonMedicamentListQuery"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		public GetPersonMedicamentListQuery(int userId)
			: base(userId)
		{
		}
	}
}
