using MedicationControl.Service.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationControl.Service.Infrastructure.Database
{
	/// <summary>
	/// Контекст БД контроля приема лекарственных средств
	/// </summary>
	internal class ControlContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ControlContext"/> class.
		/// </summary>
		/// <param name="option"><see cref="DbContextOptions"/></param>
		public ControlContext(DbContextOptions option)
			: base(option)
		{
		}

		/// <summary>
		/// Связь пользователя с лекарственным средством (лекарственные средства, назначенные пользователю)
		/// </summary>
		public DbSet<PersonMedicament> PersonMedicaments { get; set; }

		/// <summary>
		/// Расписание приема лекарства
		/// </summary>
		public DbSet<MedicationSchedule> MedicationSchedules { get; set; }

		/// <summary>
		/// Закупка лекарств
		/// </summary>
		public DbSet<MedicamentPurchase> MedicamentPurchases { get; set; }

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			PersonMedicament.Configure(modelBuilder);
			MedicationSchedule.Configure(modelBuilder);
			MedicamentPurchase.Configure(modelBuilder);
		}
	}
}
