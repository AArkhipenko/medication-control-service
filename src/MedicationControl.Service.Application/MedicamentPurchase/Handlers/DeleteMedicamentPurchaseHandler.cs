using AArkhipenko.Core.Logging;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.Commands;
using MedicationControl.Service.Application.MedicamentPurchase.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.MedicamentPurchase.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="DeleteMedicamentPurchaseCommand"/>
	/// </summary>
	internal class DeleteMedicamentPurchaseHandler : LoggerWrapper, IRequestHandler<DeleteMedicamentPurchaseCommand>
	{
		private readonly IMedicamentPurchaseRepository _repository;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteMedicamentPurchaseHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IMedicamentPurchaseRepository"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан входной параметр</exception>
		public DeleteMedicamentPurchaseHandler(
			IMedicamentPurchaseRepository repository,
			IMediator mediator,
			ILogger<DeleteMedicamentPurchaseHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <inheritdoc/>
		public async Task Handle(DeleteMedicamentPurchaseCommand request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var model = await this._mediator.Send(
					new GetMedicamentPurchaseQuery(request.UserId, request.MedicamentPurchaseId));

				await this._repository.DeleteAsync(request.MedicamentPurchaseId, cancellationToken);
			}
		}
	}
}
