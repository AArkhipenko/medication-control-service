using AArkhipenko.Core.Logging;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.DTO;
using MedicationControl.Service.Application.PersonMedicament.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.PersonMedicament.Handlers
{
	/// <summary>
	/// Выполнение <see cref="GetPersonMedicamentQuery"/>
	/// </summary>
	internal class GetPersonMedicamentHandler : LoggerWrapper, IRequestHandler<GetPersonMedicamentQuery, PersonMedicamentDTO>
	{
		private readonly IPersonMedicamentRepository _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="GetPersonMedicamentHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public GetPersonMedicamentHandler(
			IPersonMedicamentRepository repository,
			ILogger<GetPersonMedicamentHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/// <inheritdoc/>
		public async Task<PersonMedicamentDTO> Handle(GetPersonMedicamentQuery request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await this._repository.GetAsync(request.PersonMedicamentId, cancellationToken);
				if (member.UserId != request.UserId)
				{
					throw new UnauthorizedAccessException("Попытка получения доступа к данным другого пользователя");
				}

				return new PersonMedicamentDTO
				{
					PersonMedicamentId = member.Id,
					MedicamentTypeId = member.MedicamentTypeId,
					StartDate = member.StartDate,
					EndDate = member.EndDate
				};
			}
		}
	}
}
