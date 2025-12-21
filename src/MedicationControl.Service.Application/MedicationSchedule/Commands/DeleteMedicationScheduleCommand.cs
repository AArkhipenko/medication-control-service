using MediatR;
using MedicationControl.Service.Application.Common.Commands;

namespace MedicationControl.Service.Application.MedicationSchedule.Commands;

/// <summary>
/// Запрос на удаление расписания приема лекарств.
/// </summary>
public sealed class DeleteMedicationScheduleCommand : UserBasedCommand, IRequest
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
	/// ИД записи для удаления.
	/// </summary>
	public int MedicationScheduleId { get; }
}
