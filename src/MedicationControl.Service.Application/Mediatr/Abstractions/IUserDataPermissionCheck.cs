namespace MedicationControl.Service.Application.Mediatr.Abstractions;

/// <summary>
/// Интерфейс запроса, в котором требуется проверка прав доступа пользователя к данным
/// </summary>
public interface IUserDataPermissionCheck
{
    /// <summary>
    /// ИД пользователя во внешней системе
    /// </summary>
    string ExternalUserId { get; }

    /// <summary>
    /// ИД связи пользователя с лекарственным средством
    /// </summary>
    int PersonMedicamentId { get; }
}