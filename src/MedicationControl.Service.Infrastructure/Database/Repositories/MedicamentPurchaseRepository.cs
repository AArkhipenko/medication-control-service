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
	/// Реализация <see cref="IMedicamentPurchaseRepository"/>
	/// </summary>
	internal class MedicamentPurchaseRepository : GeneralRepository<TableExt.MedicamentPurchase>, IMedicamentPurchaseRepository
	{
		private readonly ControlContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="MedicamentPurchaseRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="ControlContext"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public MedicamentPurchaseRepository(
			ControlContext context,
			IMapper mapper,
			ILogger<MedicamentPurchaseRepository> logger)
			: base(context, logger)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public async Task<int> CreateAsync(DomainExt.MedicamentPurchase model, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = this._mapper.Map<TableExt.MedicamentPurchase>(model);

				await this._context.MedicamentPurchases.AddAsync(member, cancellationToken);
				await this._context.SaveChangesAsync(cancellationToken);

				return member.Id;
			}
		}

		/// <inheritdoc/>
		public async Task<DomainExt.MedicamentPurchase> GetAsync(int medicamentPurchaseId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await this.GetEntityAsync(medicamentPurchaseId, cancellationToken);

				var model = this._mapper.Map<DomainExt.MedicamentPurchase>(member);
				return model;
			}
		}

		/// <inheritdoc/>
		public async Task UpdateAsync(DomainExt.MedicamentPurchase model, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = this._mapper.Map<TableExt.MedicamentPurchase>(model);

				this._context.MedicamentPurchases.Update(member);
				await this._context.SaveChangesAsync(cancellationToken);
			}
		}

		/// <inheritdoc/>
		public async Task DeleteAsync(int medicamentPurchaseId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await base.GetEntityAsync(medicamentPurchaseId, cancellationToken);

				this._context.MedicamentPurchases.Remove(member);
				await this._context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
