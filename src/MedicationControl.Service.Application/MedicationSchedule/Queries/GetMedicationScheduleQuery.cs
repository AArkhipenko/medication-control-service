using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Queries
{
	/// <summary>
	/// Запрос на получение раписания приема лекарств
	/// </summary>
    internal class GetMedicationScheduleQuery : UserBasedCommand, IRequest<MedicationScheduleDTO>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="GetMedicationScheduleQuery"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="medicationScheduleId"><inheritdoc cref="MedicationScheduleId" path="/summary"/></param>
		public GetMedicationScheduleQuery(int userId, int medicationScheduleId)
			: base(userId)
		{
			this.MedicationScheduleId = medicationScheduleId;
		}

		/// <summary>
		/// ИД связи пользователя и лекарства
		/// </summary>
		public int MedicationScheduleId { get; set; }
	}
}
