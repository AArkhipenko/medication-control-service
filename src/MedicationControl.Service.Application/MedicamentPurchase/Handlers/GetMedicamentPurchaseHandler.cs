using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.MedicamentPurchase.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainModel = MedicationControl.Service.Domain.Models.MedicamentPurchase;

namespace MedicationControl.Service.Application.MedicamentPurchase.Handlers;

/// <summary>
/// Выполнение запроса <see cref="GetMedicamentPurchaseQuery"/>.
/// </summary>
internal sealed class GetMedicamentPurchaseHandler : LoggerWrapper, IRequestHandler<GetMedicamentPurchaseQuery, DomainModel>
{
	private readonly IMedicamentPurchaseRepository _repository;
	private readonly IMediator _mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="GetMedicamentPurchaseHandler"/> class.
	/// </summary>
	/// <param name="repository"><see cref="IMedicamentPurchaseRepository"/>.</param>
	/// <param name="mapper"><see cref="IMapper"/>.</param>
	/// <param name="mediator"><see cref="IMediator"/>.</param>
	/// <param name="logger"><see cref="ILogger"/>.</param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public GetMedicamentPurchaseHandler(
		IMedicamentPurchaseRepository repository,
		IMapper mapper,
		IMediator mediator,
		ILogger<CreateMedicamentPurchaseHandler> logger)
		: base(logger)
	{
		this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	/// <inheritdoc/>
	public async Task<DomainModel> Handle(GetMedicamentPurchaseQuery request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		using (_ = base.BeginLoggingScope())
		{
			var model = await this._repository.GetAsync(request.MedicamentPurchaseId, cancellationToken);

			// Проверка прав доступа к данным
			await this._mediator.Send(
				new CheckUserDataPermissionCommand(request.ExternalUserId, model.PersonMedicamentId),
				cancellationToken);

			return model;
		}
	}
}
