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
	/// Выполнение запроса <see cref="UpdateMedicationScheduleCommand"/>
	/// </summary>
	internal class UpdateMedicationScheduleHandler : LoggerWrapper, IRequestHandler<UpdateMedicationScheduleCommand>
	{
		private readonly IMedicationScheduleRepository _repository;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="UpdateMedicationScheduleHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IMedicationScheduleRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public UpdateMedicationScheduleHandler(
			IMedicationScheduleRepository repository,
			IMapper mapper,
			IMediator mediator,
			ILogger<UpdateMedicationScheduleHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <inheritdoc/>
		public async Task Handle(UpdateMedicationScheduleCommand request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var member = await this._mediator.Send(
					new GetMedicationScheduleQuery(request.UserId, request.Request.MedicationScheduleId),
					cancellationToken);

				var model = this._mapper.Map<DomainExt.MedicationSchedule>(request);

				// недопустимо изменять связь пользователя с лекарством
				if (member.PersonMedicamentId != model.PersonMedicamentId)
				{
					throw new BadRequestException("Недопустимо изменять связь пользователя с лекарством в расписании");
				}

				await this._repository.UpdateAsync(model, cancellationToken);
			}
		}
	}
}
