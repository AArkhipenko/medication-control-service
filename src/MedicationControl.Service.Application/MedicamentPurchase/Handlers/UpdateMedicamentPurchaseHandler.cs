using AArkhipenko.Core.Exceptions;
using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.Commands;
using MedicationControl.Service.Application.MedicamentPurchase.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.MedicamentPurchase.Handlers;

/// <summary>
/// Выполнение запроса <see cref="UpdateMedicamentPurchaseCommand"/>.
/// </summary>
internal sealed class UpdateMedicamentPurchaseHandler : LoggerWrapper, IRequestHandler<UpdateMedicamentPurchaseCommand>
{
	private readonly IMedicamentPurchaseRepository _repository;
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="UpdateMedicamentPurchaseHandler"/> class.
	/// </summary>
	/// <param name="repository"><see cref="IMedicamentPurchaseRepository"/>.</param>
	/// <param name="mapper"><see cref="IMapper"/>.</param>
	/// <param name="mediator"><see cref="IMediator"/>.</param>
	/// <param name="logger"><see cref="ILogger"/>.</param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public UpdateMedicamentPurchaseHandler(
		IMedicamentPurchaseRepository repository,
		IMapper mapper,
		IMediator mediator,
		ILogger<UpdateMedicamentPurchaseHandler> logger)
		: base(logger)
	{
		this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	/// <inheritdoc/>
	public async Task Handle(UpdateMedicamentPurchaseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		using (_ = base.BeginLoggingScope())
		{
			var member = await this._mediator.Send(
				new GetMedicamentPurchaseQuery(request.ExternalUserId, request.Request.MedicamentPurchaseId));

			// недопустимо изменять связь пользователя с лекарством
			if (request.PersonMedicamentId != member.PersonMedicamentId)
			{
				Logger.LogError(
					"""
					Попытка изменения связи пользователя с лекарством в закупке. 
					ИД пользователя: {requestExternalUserId}. 
					ИД связи: {memberPersonMedicamentId}. 
					ИД новой связи: {requestPersonMedicamentId}.
					""",
					request.ExternalUserId,
					member.PersonMedicamentId,
					request.PersonMedicamentId);
				throw new BadRequestException("Недопустимо изменять связь пользователя с лекарством в закупке");
			}

			var model = this._mapper.Map<DomainExt.MedicamentPurchase>(request);
			await this._repository.UpdateAsync(model, cancellationToken);
		}
	}
}
