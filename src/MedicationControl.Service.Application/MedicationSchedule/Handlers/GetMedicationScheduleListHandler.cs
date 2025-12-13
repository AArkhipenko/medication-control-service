using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicationSchedule.DTO;
using MedicationControl.Service.Application.MedicationSchedule.Queries;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Application.PersonMedicament.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.MedicationSchedule.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="GetMedicationScheduleListQuery"/>
	/// </summary>
	internal class GetMedicationScheduleListHandler : LoggerWrapper, IRequestHandler<GetMedicationScheduleListQuery, IEnumerable<MedicationScheduleDTO>>
	{
		private readonly IMedicationScheduleRepository _repository;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="GetMedicationScheduleListHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IMedicationScheduleRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан входной параметр</exception>
		public GetMedicationScheduleListHandler(
			IMedicationScheduleRepository repository,
			IMapper mapper,
			IMediator mediator,
			ILogger<GetMedicationScheduleListHandler> logger)
			: base (logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<MedicationScheduleDTO>> Handle(GetMedicationScheduleListQuery request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				await this._mediator.Send(
					new CheckUserCommand(request.ExternalUserId, request.PersonMedicamentId),
					cancellationToken);

				var list = await this._repository.GetListByPersonMedicamentAsync(
					request.PersonMedicamentId,
					cancellationToken);
				return list.Select(x => this._mapper.Map<MedicationScheduleDTO>(x));
			}
		}
	}
}
