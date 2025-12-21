using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.Mediatr.Abstractions;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Commands;

/// <summary>
/// Запрос на изменение расписания приема лекарств.
/// </summary>
public sealed class UpdateMedicationScheduleCommand : UserBasedCommand, IRequest, IUserDataPermissionCheck
{
	/// <summary>
	/// Initializes a new instance of the <see cref="UpdateMedicationScheduleCommand"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
	public UpdateMedicationScheduleCommand(string externalUserId, MedicationScheduleDto request)
		: base(externalUserId)
	{
		this.Request = request;
	} 

	/// <summary>
	/// Запрос на создание расписания приема лекарства.
	/// </summary>
	public MedicationScheduleDto Request { get; }

	/// <inheritdoc/>
	public int PersonMedicamentId => Request.PersonMedicamentId;
}
