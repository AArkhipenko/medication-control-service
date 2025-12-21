using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;
using MedicationControl.Service.Application.MedicamentPurchase.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.MedicamentPurchase.Handlers;

/// <summary>
/// Выполнение запроса <see cref="GetMedicamentPurchaseQuery"/>.
/// </summary>
internal sealed class GetMedicamentPurchaseListHandler : LoggerWrapper,
    IRequestHandler<GetMedicamentPurchaseListQuery, IEnumerable<MedicamentPurchaseDto>>
{
    private readonly IMedicamentPurchaseRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetMedicamentPurchaseListHandler"/> class.
    /// </summary>
    /// <param name="repository"><see cref="IMedicamentPurchaseRepository"/>.</param>
    /// <param name="mapper"><see cref="IMapper"/>.</param>
    /// <param name="logger"><see cref="ILogger"/>.</param>
    /// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
    public GetMedicamentPurchaseListHandler(
        IMedicamentPurchaseRepository repository,
        IMapper mapper,
        ILogger<GetMedicamentPurchaseListHandler> logger)
        : base(logger)
    {
        this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<MedicamentPurchaseDto>> Handle(GetMedicamentPurchaseListQuery request,
        CancellationToken cancellationToken)
    {
        using (_ = base.BeginLoggingScope())
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            var members = await this._repository.GetListByUserAsync(request.ExternalUserId, cancellationToken);

            return members.Select((x => _mapper.Map<MedicamentPurchaseDto>(x)));
        }
    }
}