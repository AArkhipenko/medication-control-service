using AArkhipenko.Core.Logging;
using MediatR;
using MedicationControl.Service.Application.Dictionary.DTO;
using MedicationControl.Service.Application.Dictionary.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.Dictionary.Handlers;

/// <summary>
/// Выполнение запроса <see cref="GetDayTimeTypeListQuery"/>
/// </summary>
internal class GetDayTimeTypeListHandler : LoggerWrapper, IRequestHandler<GetDayTimeTypeListQuery, IEnumerable<Element>>
{
    private readonly IDictionaryRepository _dictionaryRepository;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="GetDayTimeTypeListHandler"/> class.
    /// </summary>
    /// <param name="dictionaryRepository"><see cref="IDictionaryRepository"/></param>
    /// <param name="logger"><see cref="ILogger"/></param>
    public GetDayTimeTypeListHandler(
        IDictionaryRepository dictionaryRepository,
        ILogger<GetDayTimeTypeListHandler> logger)
        : base(logger)
    {
        _dictionaryRepository = dictionaryRepository ?? throw new ArgumentNullException(nameof(dictionaryRepository));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Element>> Handle(GetDayTimeTypeListQuery request, CancellationToken cancellationToken)
    {
        using (_ = BeginLoggingScope())
        {
            var elements = await _dictionaryRepository.GetDayTimeTypeList(cancellationToken);
            
            return elements.Select(x => new Element
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                FullName = x.FullName
            });
        }
    }
}