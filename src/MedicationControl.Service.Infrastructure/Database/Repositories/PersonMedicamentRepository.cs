using AArkhipenko.Core.Logging;
using AutoMapper;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;
using TableExt = MedicationControl.Service.Infrastructure.Database.Tables;

namespace MedicationControl.Service.Infrastructure.Database.Repositories
{
	/// <summary>
	/// Реализация <see cref="IPersonMedicamentRepository"/>
	/// </summary>
	internal class PersonMedicamentRepository : LoggerWrapper, IPersonMedicamentRepository
	{
		private readonly ControlContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="PersonMedicamentRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="ControlContext"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public PersonMedicamentRepository(
			ControlContext context,
			IMapper mapper,
			ILogger<PersonMedicamentRepository> logger)
			: base(logger)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public async Task<int> CreateAsync(DomainExt.PersonMedicament model, CancellationToken cancellationToken)
		{
			using(_ = base.BeginLoggingScope())
			{
				var obj = this._mapper.Map<TableExt.PersonMedicament>(model);

				await this._context.PersonMedicaments.AddAsync(obj, cancellationToken);
				await this._context.SaveChangesAsync(cancellationToken);

				return obj.Id;
			}
		}
	}
}
