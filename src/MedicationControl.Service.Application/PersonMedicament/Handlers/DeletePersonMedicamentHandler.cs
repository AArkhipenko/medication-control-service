using AArkhipenko.Core.Logging;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Application.PersonMedicament.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Reflection;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.PersonMedicament.Handlers
{
	/// <summary>
	/// Выполнение <see cref="UpdatePersonMedicamentCommand"/>
	/// </summary>
	internal class DeletePersonMedicamentHandler : LoggerWrapper, IRequestHandler<DeletePersonMedicamentCommand>
    {
		private readonly IPersonMedicamentRepository _repository;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="DeletePersonMedicamentHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public DeletePersonMedicamentHandler(
			IPersonMedicamentRepository repository,
			IMediator mediator,
			ILogger<DeletePersonMedicamentHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <inheritdoc/>
		public async Task Handle(DeletePersonMedicamentCommand request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var member = await this._mediator.Send(new GetPersonMedicamentQuery(request.UserId, request.PersonMedicamentId));

				await this._repository.DeleteAsync(request.PersonMedicamentId, cancellationToken);
			}
		}
	}
}
