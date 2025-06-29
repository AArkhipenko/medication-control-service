using AArkhipenko.Core.Exceptions;
using AArkhipenko.Core.Logging;
using AutoMapper;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using DomainExt = MedicationControl.Service.Domain.Models;
using TableExt = MedicationControl.Service.Infrastructure.Database.Tables;

namespace MedicationControl.Service.Infrastructure.Database.Repositories
{
	/// <summary>
	/// Реализация <see cref="IPersonMedicamentRepository"/>
	/// </summary>
	internal class PersonMedicamentRepository : GeneralRepository<TableExt.PersonMedicament>, IPersonMedicamentRepository
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
			: base(context, logger)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public async Task<int> CreateAsync(DomainExt.PersonMedicament model, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = this._mapper.Map<TableExt.PersonMedicament>(model);

				await this._context.PersonMedicaments.AddAsync(member, cancellationToken);
				await this._context.SaveChangesAsync(cancellationToken);

				return member.Id;
			}
		}

		/// <inheritdoc/>
		public async Task<DomainExt.PersonMedicament> GetAsync(int personMedicamentId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await base.GetEntityAsync(personMedicamentId, cancellationToken);

				var model = this._mapper.Map<DomainExt.PersonMedicament>(member);
				return model;
			}
		}

		/// <inheritdoc/>
		public async Task UpdateAsync(DomainExt.PersonMedicament model, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = this._mapper.Map<TableExt.PersonMedicament>(model);

				this._context.PersonMedicaments.Update(member);
				await this._context.SaveChangesAsync(cancellationToken);
			}
		}

		/// <inheritdoc/>
		public async Task DeleteAsync(int personMedicamentId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await base.GetEntityAsync(personMedicamentId, cancellationToken);

				this._context.PersonMedicaments.Remove(member);
				await this._context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
