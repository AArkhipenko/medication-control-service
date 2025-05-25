using AArkhipenko.Core.Exceptions;
using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.Commands;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.MedicamentPurchase.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="CreateMedicamentPurchaseCommand"/>
	/// </summary>
	internal class CreateMedicamentPurchaseHandler : LoggerWrapper, IRequestHandler<CreateMedicamentPurchaseCommand, int>
	{
		private readonly IMedicamentPurchaseRepository _repository;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateMedicamentPurchaseHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IMedicamentPurchaseRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан входной параметр</exception>
		public CreateMedicamentPurchaseHandler(
			IMedicamentPurchaseRepository repository,
			IMapper mapper,
			IMediator mediator,
			ILogger<CreateMedicamentPurchaseHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <inheritdoc/>
		public async Task<int> Handle(CreateMedicamentPurchaseCommand request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				await this._mediator.Send(
					new CheckUserCommand(request.UserId, request.Request.PersonMedicamentId),
					cancellationToken);

				var model = this._mapper.Map<DomainExt.MedicamentPurchase>(request);

				return await this._repository.CreateAsync(model, cancellationToken);
			}
		}
	}
}
