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
    public class CreateMedicationScheduleCommand : UserBasedCommand, IRequest<int>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="CreateMedicationScheduleCommand"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserBasedCommand.UserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public CreateMedicationScheduleCommand(int userId, CreateMedicationScheduleDTO request)
			: base(userId)
		{
			this.Request = request;
		} 

		/// <summary>
		/// Запрос на создание расписания приема лекарства
		/// </summary>
		public CreateMedicationScheduleDTO Request { get; }
	}
}
