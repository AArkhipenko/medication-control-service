using MediatR;
using MedicationControl.Service.Application.Common;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Commands
{
	/// <summary>
	/// Запрос на изменение расписания приема лекарств
	/// </summary>
	/// <remarks>
	/// Здесь реализована проверка на то, что не происходит изменение связи пользователя и лекарства
	/// </remarks>
    public class UpdateMedicationScheduleCommand : UserBasedCommand, IRequest
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateMedicationScheduleCommand"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public UpdateMedicationScheduleCommand(int userId, MedicationScheduleDTO request)
			: base(userId)
		{
			this.Request = request;
		} 

		/// <summary>
		/// Запрос на создание расписания приема лекарства
		/// </summary>
		public MedicationScheduleDTO Request { get; }
	}
}
