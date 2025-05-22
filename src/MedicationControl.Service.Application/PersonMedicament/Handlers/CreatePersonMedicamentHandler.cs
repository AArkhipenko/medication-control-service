using AArkhipenko.Core.Logging;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Reflection;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.PersonMedicament.Handlers
{
	/// <summary>
	/// Выполнение <see cref="CreatePersonMedicamentCommand"/>
	/// </summary>
	internal class CreatePersonMedicamentHandler : LoggerWrapper, IRequestHandler<CreatePersonMedicamentCommand, int>
    {
		private readonly IPersonMedicamentRepository _repository;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreatePersonMedicamentHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public CreatePersonMedicamentHandler(
			IPersonMedicamentRepository repository,
			ILogger<CreatePersonMedicamentHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		/// <inheritdoc/>
		public Task<int> Handle(CreatePersonMedicamentCommand request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var model = new DomainExt.PersonMedicament()
				{
					UserId = request.UserId,
					MedicamentTypeId = request.Request.MedicamentTypeId,
					StartDate = request.Request.StartDate,
					EndDate = request.Request.EndDate
				};

				return this._repository.CreateAsync(model, cancellationToken);
			}
		}
	}
}
