using AArkhipenko.Core.Exceptions;
using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicationSchedule.Commands;
using MedicationControl.Service.Application.MedicationSchedule.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.MedicationSchedule.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="DeleteMedicationScheduleCommand"/>
	/// </summary>
	internal class DeleteMedicationScheduleHandler : LoggerWrapper, IRequestHandler<DeleteMedicationScheduleCommand>
	{
		private readonly IMedicationScheduleRepository _repository;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="DeleteMedicationScheduleHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IMedicationScheduleRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public DeleteMedicationScheduleHandler(
			IMedicationScheduleRepository repository,
			IMapper mapper,
			IMediator mediator,
			ILogger<DeleteMedicationScheduleHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <inheritdoc/>
		public async Task Handle(DeleteMedicationScheduleCommand request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await this._mediator.Send(
					new GetMedicationScheduleQuery(request.ExternalUserId, request.MedicationScheduleId),
					cancellationToken);

				await this._repository.DeleteAsync(request.MedicationScheduleId, cancellationToken);
			}
		}
	}
}
