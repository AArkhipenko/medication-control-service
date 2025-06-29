using AArkhipenko.Core.Logging;
using AutoMapper;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Application.PersonMedicament.Queries;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Reflection;

using DomainExt = MedicationControl.Service.Domain.Models;

namespace MedicationControl.Service.Application.PersonMedicament.Handlers
{
	/// <summary>
	/// Выполнение <see cref="UpdatePersonMedicamentCommand"/>
	/// </summary>
	internal class UpdatePersonMedicamentHandler : LoggerWrapper, IRequestHandler<UpdatePersonMedicamentCommand>
    {
		private readonly IPersonMedicamentRepository _repository;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="UpdatePersonMedicamentHandler"/> class.
		/// </summary>
		/// <param name="repository"><see cref="IPersonMedicamentRepository"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public UpdatePersonMedicamentHandler(
			IPersonMedicamentRepository repository,
			IMapper mapper,
			IMediator mediator,
			ILogger<UpdatePersonMedicamentHandler> logger)
			: base(logger)
		{
			this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <inheritdoc/>
		public async Task Handle(UpdatePersonMedicamentCommand request, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var model = this._mapper.Map<DomainExt.PersonMedicament>(request);

				var member = await this._mediator.Send(new GetPersonMedicamentQuery(request.UserId, model.Id));
				if(member.MedicamentTypeId != model.MedicamentTypeId)
				{
					throw new UnauthorizedAccessException("Изменение лекарственного средства недопустимо");
				}

				await this._repository.UpdateAsync(model, cancellationToken);
			}
		}
	}
}
