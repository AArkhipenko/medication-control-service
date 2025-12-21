using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicationSchedule.DTO;
using MedicationControl.Service.Application.MedicationSchedule.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.MedicationSchedule.Handlers;

/// <summary>
/// Выполнение <see cref="GetMedicationScheduleListQuery"/>.
/// </summary>
internal sealed class GetMedicationScheduleListHandler : LoggerWrapper,
    IRequestHandler<GetMedicationScheduleListQuery, IEnumerable<MedicationScheduleDto>>
{
    private readonly IMedicationScheduleRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetMedicationScheduleListHandler"/> class.
    /// </summary>
    /// <param name="repository"><see cref="IMedicationScheduleRepository"/>.</param>
    /// <param name="mapper"><see cref="IMapper"/>.</param>
    /// <param name="logger"><see cref="ILogger"/>.</param>
    /// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
    public GetMedicationScheduleListHandler(
        IMedicationScheduleRepository repository,
        IMapper mapper,
        ILogger<GetMedicationScheduleListHandler> logger)
        : base(logger)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<MedicationScheduleDto>> Handle(GetMedicationScheduleListQuery request,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        using (_ = base.BeginLoggingScope())
        {
            var list = await this._repository.GetListByPersonMedicamentAsync(
                request.PersonMedicamentId,
                cancellationToken);
            return list.Select(x => this._mapper.Map<MedicationScheduleDto>(x));
        }
    }
}