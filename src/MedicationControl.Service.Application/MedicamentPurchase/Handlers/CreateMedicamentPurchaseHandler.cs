using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.Commands;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.MedicamentPurchase.Handlers;

/// <summary>
/// Выполнение <see cref="CreateMedicamentPurchaseCommand"/>.
/// </summary>
internal sealed class CreateMedicamentPurchaseHandler : LoggerWrapper, IRequestHandler<CreateMedicamentPurchaseCommand, int>
{
	private readonly IMedicamentPurchaseRepository _repository;
	private readonly IMapper _mapper;

	/// <summary>
	/// Initializes a new instance of the <see cref="CreateMedicamentPurchaseHandler"/> class.
	/// </summary>
	/// <param name="repository"><see cref="IMedicamentPurchaseRepository"/>.</param>
	/// <param name="mapper"><see cref="IMapper"/>.</param>
	/// <param name="logger"><see cref="ILogger"/>.</param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public CreateMedicamentPurchaseHandler(
		IMedicamentPurchaseRepository repository,
		IMapper mapper,
		ILogger<CreateMedicamentPurchaseHandler> logger)
		: base(logger)
	{
		this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	/// <inheritdoc/>
	public async Task<int> Handle(CreateMedicamentPurchaseCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		using (_ = base.BeginLoggingScope())
		{
			var model = this._mapper.Map<DomainExt.MedicamentPurchase>(request);

			return await this._repository.CreateAsync(model, cancellationToken);
		}
	}
}
