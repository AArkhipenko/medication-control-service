using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.Mediatr.Abstractions;

namespace MedicationControl.Service.Application.Mediatr.Behaviors;

/// <summary>
/// Middleware проверки прав пользователя.
/// </summary>
/// <typeparam name="TRequest">Тип запроса.</typeparam>
/// <typeparam name="TResponse">Тип ответа.</typeparam>
internal sealed class UserPermissionCheckBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IUserDataPermissionCheck
    where TResponse : class
{
	private readonly IMediator _mediator;
	
	/// <summary>
	/// Initializes a new instance of the <see cref="UserPermissionCheckBehavior{TRequest, TResponse}"/> class.
	/// </summary>
	/// <param name="mediator"><see cref="IMediator"/>.</param>
	public UserPermissionCheckBehavior(
		IMediator mediator)
    {
        this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    
    /// <inheritdoc/>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var checkRequest = new CheckUserDataPermissionCommand(request.ExternalUserId, request.PersonMedicamentId);
        await this._mediator.Send(checkRequest, cancellationToken);

        return await next();
    }
}