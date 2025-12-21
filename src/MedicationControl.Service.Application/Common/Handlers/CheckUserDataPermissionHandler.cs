using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.Common.Handlers;

/// <summary>
/// Выполнение <see cref="CheckUserDataPermissionCommand"/>.
/// </summary>
internal sealed class CheckUserDataPermissionHandler : IRequestHandler<CheckUserDataPermissionCommand>
{
    private readonly IPersonMedicamentRepository _repository;
    private readonly ILogger<CheckUserDataPermissionHandler> _logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="CheckUserDataPermissionHandler"/> class.
	/// </summary>
	/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
    /// <param name="logger"><see cref="ILogger{CheckUserDataPermissionHandler}"/></param>
    /// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public CheckUserDataPermissionHandler(
        IPersonMedicamentRepository repository,
        ILogger<CheckUserDataPermissionHandler> logger)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._logger = logger  ?? throw new ArgumentNullException(nameof(logger));
    }
    
    /// <inheritdoc/>
    public async Task Handle(CheckUserDataPermissionCommand request, CancellationToken cancellationToken)
    {
        this._logger.LogInformation("Проверка прав доступа к данным для пользователя с ИД={externalUserId}", request.ExternalUserId);
        cancellationToken.ThrowIfCancellationRequested();

        var member = await this._repository.GetAsync(request.PersonMedicamentId, cancellationToken);
        if (member.ExternalUserId != request.ExternalUserId)
        {
            this._logger.LogError(
                "Пользователь с ИД={requestExternalUserId} пытается получить доступ к данным пользовател с ИД={memberExternalUserId}.",
                request.ExternalUserId,
                request.ExternalUserId);
            throw new UnauthorizedAccessException("Попытка получения доступа к данным другого пользователя.");
        }
    }
}