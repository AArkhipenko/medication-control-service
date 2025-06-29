using AArkhipenko.Core.Exceptions;
using AArkhipenko.Core.Logging;
using AutoMapper;
using AutoMapper.Execution;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.Commands;
using MedicationControl.Service.Application.MedicamentPurchase.Queries;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.MedicamentPurchase.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="UpdateMedicamentPurchaseCommand"/>
	/// </summary>
	internal class UpdateMedicamentPurchaseHandler : LoggerWrapper, IRequestHandler<UpdateMedicamentPurchaseCommand>
	{
		private readonly IMedicamentPurchaseRepository _repository;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateMedicamentPurchaseHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IMedicamentPurchaseRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан входной параметр</exception>
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
				var model = await this._mediator.Send(
					new GetMedicamentPurchaseQuery(request.UserId, request.Request.MedicamentPurchaseId));

				// недопустимо изменять связь пользователя с лекарством
				if (request.Request.PersonMedicamentId != model.PersonMedicamentId)
				{
					throw new BadRequestException("Недопустимо изменять связь пользователя с лекарством в расписании");
				}

				var updateModel = this._mapper.Map<DomainExt.MedicamentPurchase>(request);
				await this._repository.UpdateAsync(model, cancellationToken);
			}
		}
	}
}
