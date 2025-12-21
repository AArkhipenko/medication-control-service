using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.MedicationSchedule.DTO;
using MedicationControl.Service.Application.MedicationSchedule.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.MedicationSchedule.Handlers;

/// <summary>
/// Выполнение <see cref="GetMedicationScheduleListQuery"/>.
/// </summary>
internal sealed class GetMedicationScheduleHandler : LoggerWrapper, IRequestHandler<GetMedicationScheduleQuery, MedicationScheduleDto>
{
	private readonly IMedicationScheduleRepository _repository;
	private readonly IMapper _mapper;
	private readonly IMediator _mediator;

	/// <summary>
	/// Initializes a new instance of the <see cref="GetMedicationScheduleHandler"/> class.
	/// </summary>
	/// <param name="repository"><see cref="IMedicationScheduleRepository"/>.</param>
	/// <param name="mapper"><see cref="IMapper"/>.</param>
	/// <param name="mediator"><see cref="IMediator"/>.</param>
	/// <param name="logger"><see cref="ILogger"/>.</param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public GetMedicationScheduleHandler(
		IMedicationScheduleRepository repository,
		IMapper mapper,
		IMediator mediator,
		ILogger<GetMedicationScheduleHandler> logger)
		: base (logger)
	{
		this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	/// <inheritdoc/>
	public async Task<MedicationScheduleDto> Handle(GetMedicationScheduleQuery request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		using (_ = base.BeginLoggingScope())
		{
			var model = await this._repository.GetAsync(
				request.MedicationScheduleId,
				cancellationToken);

			// Проверка прав доступа к данным
			await this._mediator.Send(
				new CheckUserDataPermissionCommand(request.ExternalUserId, model.PersonMedicamentId),
				cancellationToken);

			return this._mapper.Map<MedicationScheduleDto>(model);
		}
	}
}