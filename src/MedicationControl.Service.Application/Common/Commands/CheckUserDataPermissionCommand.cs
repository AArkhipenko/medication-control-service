using MediatR;

namespace MedicationControl.Service.Application.Common.Commands;

/// <summary>
/// Запрос на проверку прав пользователя на доступ к данным
/// </summary>
internal sealed class CheckUserDataPermissionCommand : UserBasedCommand, IRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CheckUserDataPermissionCommand"/> class.
    /// </summary>
    /// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
    /// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
    public CheckUserDataPermissionCommand(
        string externalUserId,
        int personMedicamentId)
        : base(externalUserId)
    {
        this.PersonMedicamentId = personMedicamentId;
    }

    /// <summary>
    /// ИД связи пользователя с лекарственным средством
    /// </summary>
    public int PersonMedicamentId { get; }
}