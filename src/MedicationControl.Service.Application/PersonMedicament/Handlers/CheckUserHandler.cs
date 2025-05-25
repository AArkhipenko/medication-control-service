using AArkhipenko.Core.Logging;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.PersonMedicament.Handlers
{
	/// <summary>
	/// Выполнение <see cref="CheckUserCommand"/>
	/// </summary>
	internal class CheckUserHandler : LoggerWrapper, IRequestHandler<CheckUserCommand>
	{
		private readonly IPersonMedicamentRepository _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckUserHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public CheckUserHandler(
			IPersonMedicamentRepository repository,
			ILogger<GetPersonMedicamentHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/// <inheritdoc/>
		public async Task Handle(CheckUserCommand request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var member = await this._repository.GetAsync(request.PersonMedicamentId, cancellationToken);
				if (member.UserId != request.UserId)
				{
					throw new UnauthorizedAccessException("Попытка получения доступа к данным другого пользователя");
				}
			}
		}
	}
}
