using AArkhipenko.Core.Logging;
using AutoMapper;
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
		private readonly IMapper _mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreatePersonMedicamentHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public CreatePersonMedicamentHandler(
			IPersonMedicamentRepository repository,
			IMapper mapper,
			ILogger<CreatePersonMedicamentHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public Task<int> Handle(CreatePersonMedicamentCommand request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var model = this._mapper.Map<DomainExt.PersonMedicament>(request);

				return this._repository.CreateAsync(model, cancellationToken);
			}
		}
	}
}
