using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Commands
{
	/// <summary>
	/// Запрос на создание расписания приема лекарств
	/// </summary>
	/// <remarks>
	/// Здесь реализована логика проверки добавления дублирующей записи, проверка по:
	///		- лекарство для пользователя
	///		- время приема лекарства
	/// </remarks>
    public class DeleteMedicationScheduleCommand : UserBasedCommand, IRequest
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteMedicationScheduleCommand"/> class.
		/// </summary>
		/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
		/// <param name="medicationScheduleId"><inheritdoc cref="MedicationScheduleId" path="/summary"/></param>
		public DeleteMedicationScheduleCommand(string externalUserId, int medicationScheduleId)
			: base(externalUserId)
		{
			this.MedicationScheduleId = medicationScheduleId;
		} 

		/// <summary>
		/// ИД записи для удаления
		/// </summary>
		public int MedicationScheduleId { get; }
	}
}
