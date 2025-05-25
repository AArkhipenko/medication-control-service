using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Queries
{
	/// <summary>
	/// Запрос на получение списка раписаний приема лекарств
	/// </summary>
    internal class GetMedicationScheduleListQuery : UserBasedCommand, IRequest<IEnumerable<MedicationScheduleDTO>>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="GetMedicationScheduleListQuery"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
		public GetMedicationScheduleListQuery(int userId, int personMedicamentId)
			: base(userId)
		{
			this.PersonMedicamentId = personMedicamentId;
		}

		/// <summary>
		/// ИД связи пользователя и лекарства
		/// </summary>
		public int PersonMedicamentId { get; set; }
	}
}
