using AArkhipenko.Core.Exceptions;
using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicationSchedule.Commands;
using MedicationControl.Service.Application.MedicationSchedule.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.MedicationSchedule.Handlers;

/// <summary>
/// Выполнение <see cref="CreateMedicationScheduleCommand"/>.
/// </summary>
internal sealed class CreateMedicationScheduleHandler : LoggerWrapper, IRequestHandler<CreateMedicationScheduleCommand, int>
{
	private readonly IMedicationScheduleRepository _repository;
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="CreateMedicationScheduleHandler"/> class.
	/// </summary>
	/// <param name="repository"><see cref="IMedicationScheduleRepository"/>.</param>
	/// <param name="mapper"><see cref="IMapper"/>.</param>
	/// <param name="mediator"><see cref="IMediator"/>.</param>
	/// <param name="logger"><see cref="ILogger"/>.</param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public CreateMedicationScheduleHandler(
		IMedicationScheduleRepository repository,
		IMapper mapper,
		IMediator mediator,
		ILogger<CreateMedicationScheduleHandler> logger)
		: base(logger)
	{
		this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	/// <inheritdoc/>
	public async Task<int> Handle(CreateMedicationScheduleCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		using (_ = base.BeginLoggingScope())
		{
			var list = await this._mediator.Send(
				new GetMedicationScheduleListQuery(request.ExternalUserId, request.Request.PersonMedicamentId),
				cancellationToken);

			var model = this._mapper.Map<DomainExt.MedicationSchedule>(request);

			// недопустимо создавать запись с похожими параметрами
			if (list.Any(x => x.PersonMedicamentId == model.PersonMedicamentId &&
				(model.DayTimeTypeId.HasValue ? x.DayTimeTypeId == model.DayTimeTypeId :
					x.Time == model.Time)))
			{
				Logger.LogError(
					"""
	                Уже имеется расписание с ИД лекарства = {personMedicamentId} 
	                и временем приема лекарства = {dayTime}.
	                """,
					model.PersonMedicamentId,
					model.DayTimeTypeId.HasValue ?  model.DayTimeTypeId.Value : model.Time);
				throw new BadRequestException("Уже имеется похожее расписание.");
			}

			return await this._repository.CreateAsync(model, cancellationToken);
		}
	}
}
