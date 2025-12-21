using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Queries;

/// <summary>
/// Запрос на получение расписания приема лекарств.
/// </summary>
internal sealed class GetMedicationScheduleQuery : UserBasedCommand, IRequest<MedicationScheduleDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetMedicationScheduleQuery"/> class.
    /// </summary>
    /// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
    /// <param name="medicationScheduleId"><inheritdoc cref="MedicationScheduleId" path="/summary"/></param>
    public GetMedicationScheduleQuery(string externalUserId, int medicationScheduleId)
        : base(externalUserId)
    {
        this.MedicationScheduleId = medicationScheduleId;
    }

    /// <summary>
    /// ИД связи пользователя и лекарства.
    /// </summary>
    public int MedicationScheduleId { get; }
}