using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.Mediatr.Abstractions;
using MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.MedicationSchedule.Queries;

/// <summary>
/// Запрос на получение списка раписаний приема лекарств.
/// </summary>
internal sealed class GetMedicationScheduleListQuery : UserBasedCommand, IRequest<IEnumerable<MedicationScheduleDto>>,
    IUserDataPermissionCheck
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetMedicationScheduleListQuery"/> class.
    /// </summary>
    /// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
    /// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
    public GetMedicationScheduleListQuery(string externalUserId, int personMedicamentId)
        : base(externalUserId)
    {
        this.PersonMedicamentId = personMedicamentId;
    }

    /// <inheritdoc/>
    public int PersonMedicamentId { get; }
}