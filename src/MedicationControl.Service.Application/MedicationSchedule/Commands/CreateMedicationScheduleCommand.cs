using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.Mediatr.Abstractions;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Commands;

/// <summary>
/// Запрос на создание расписания приема лекарств.
/// </summary>
/// <remarks>
/// Здесь реализована логика проверки добавления дублирующей записи, проверка по:
///		- лекарство для пользователя
///		- время приема лекарства
/// </remarks>
public sealed class CreateMedicationScheduleCommand : UserBasedCommand, IRequest<int>, IUserDataPermissionCheck
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CreateMedicationScheduleCommand"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
	public CreateMedicationScheduleCommand(string externalUserId, CreateMedicationScheduleDto request)
		: base(externalUserId)
	{
		this.Request = request;
	} 

	/// <summary>
	/// Запрос на создание расписания приема лекарства.
	/// </summary>
	public CreateMedicationScheduleDto Request { get; }

	/// <inheritdoc/>
	public int PersonMedicamentId => Request.PersonMedicamentId;
}
