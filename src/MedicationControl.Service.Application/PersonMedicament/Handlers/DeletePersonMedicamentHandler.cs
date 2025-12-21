using AArkhipenko.Core.Logging;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.PersonMedicament.Handlers;

/// <summary>
/// Выполнение <see cref="UpdatePersonMedicamentCommand"/>.
/// </summary>
internal sealed class DeletePersonMedicamentHandler : LoggerWrapper, IRequestHandler<DeletePersonMedicamentCommand>
{
	private readonly IPersonMedicamentRepository _repository;

	/// <summary>
	/// Initializes a new instance of the <see cref="DeletePersonMedicamentHandler"/> class.
	/// </summary>
	/// <param name="repository"><see cref="IPersonMedicamentRepository"/>.</param>
	/// <param name="logger"><see cref="ILogger"/>.</param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public DeletePersonMedicamentHandler(
		IPersonMedicamentRepository repository,
		ILogger<DeletePersonMedicamentHandler> logger)
		: base(logger)
	{
		this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

	/// <inheritdoc/>
	public async Task Handle(DeletePersonMedicamentCommand request, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		using (_ = base.BeginLoggingScope())
		{
			await this._repository.DeleteAsync(request.PersonMedicamentId, cancellationToken);
		}
	}
}
