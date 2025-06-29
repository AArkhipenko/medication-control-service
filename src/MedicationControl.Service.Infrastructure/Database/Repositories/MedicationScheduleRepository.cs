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
	/// Реализация <see cref="IMedicationScheduleRepository"/>
	/// </summary>
	internal class MedicationScheduleRepository : GeneralRepository<TableExt.MedicationSchedule>, IMedicationScheduleRepository
	{
		private readonly ControlContext _context;
		private readonly IMapper _mapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="MedicationScheduleRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="ControlContext"/></param>
		/// <param name="mapper"><see cref="IMapper"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
		public MedicationScheduleRepository(
			ControlContext context,
			IMapper mapper,
			ILogger<MedicationScheduleRepository> logger)
			: base(context, logger)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
			this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<DomainExt.MedicationSchedule>> GetListByPersonMedicamentAsync(int personMedicamentId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var list = await this._context.MedicationSchedules
					.Where(x => x.PersoMedicamentId == personMedicamentId)
					.ToListAsync();

				return list.Select(x => this._mapper.Map<DomainExt.MedicationSchedule>(x));
			}
		}

		/// <inheritdoc/>
		public async Task<int> CreateAsync(DomainExt.MedicationSchedule model, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = this._mapper.Map<TableExt.MedicationSchedule>(model);

				await this._context.MedicationSchedules.AddAsync(member, cancellationToken);
				await this._context.SaveChangesAsync(cancellationToken);

				return member.Id;
			}
		}

		/// <inheritdoc/>
		public async Task<DomainExt.MedicationSchedule> GetAsync(int medicationScheduleId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await base.GetEntityAsync(medicationScheduleId, cancellationToken);

				var model = this._mapper.Map<DomainExt.MedicationSchedule>(member);
				return model;
			}
		}

		/// <inheritdoc/>
		public async Task UpdateAsync(DomainExt.MedicationSchedule model, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = this._mapper.Map<TableExt.MedicationSchedule>(model);

				this._context.MedicationSchedules.Update(member);
				await this._context.SaveChangesAsync(cancellationToken);
			}
		}

		/// <inheritdoc/>
		public async Task DeleteAsync(int medicationScheduleId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			using (_ = base.BeginLoggingScope())
			{
				var member = await base.GetEntityAsync(medicationScheduleId, cancellationToken);

				this._context.MedicationSchedules.Remove(member);
				await this._context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}
