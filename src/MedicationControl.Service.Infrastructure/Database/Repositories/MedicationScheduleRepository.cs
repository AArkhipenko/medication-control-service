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
			using (_ = base.BeginLoggingScope())
			{
				var list = await this._context.MedicationSchedules
					.Where(x => x.PersoMedicamentId == personMedicamentId)
					.ToListAsync();

				return list.Select(x => this._mapper.Map<DomainExt.MedicationSchedule>(x));
			}
		}
	}
}
