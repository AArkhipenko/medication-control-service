using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.DTO;
using MedicationControl.Service.Application.PersonMedicament.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Application.PersonMedicament.Handlers
{
	/// <summary>
	/// Выполнение <see cref="GetPersonMedicamentListQuery"/>
	/// </summary>
	internal class GetPersonMedicamentListHandler : LoggerWrapper, IRequestHandler<GetPersonMedicamentListQuery, IEnumerable<PersonMedicamentDTO>>
	{
		private readonly IPersonMedicamentRepository _repository;
		private readonly IMapper _mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="GetPersonMedicamentListHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public GetPersonMedicamentListHandler(
			IPersonMedicamentRepository repository,
			IMapper mapper,
			ILogger<GetPersonMedicamentListHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<PersonMedicamentDTO>> Handle(GetPersonMedicamentListQuery request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var list = await this._repository.GetListByUserAsync(request.ExternalUserId, cancellationToken);

				return list.Select(x => this._mapper.Map<PersonMedicamentDTO>(x));
			}
		}
	}
}
