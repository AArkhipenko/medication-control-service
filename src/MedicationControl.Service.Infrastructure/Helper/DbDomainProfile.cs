using AutoMapper;

using DomainExt = MedicationControl.Service.Domain.Models;
using TableExt = MedicationControl.Service.Infrastructure.Database.Tables;

namespace MedicationControl.Service.Infrastructure.Helper
{
	/// <summary>
	/// Автомаппер доменной модели на модель таблицы БД
	/// </summary>
    internal class DbDomainProfile : Profile
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="DbDomainProfile"/> class.
		/// </summary>
		public DbDomainProfile()
		{
			// Связь лекарства с пользователем
			CreateMap<DomainExt.PersonMedicament, TableExt.PersonMedicament>();
			CreateMap<TableExt.PersonMedicament, DomainExt.PersonMedicament>();

			// Расписание приема лекарств
			CreateMap<DomainExt.MedicationSchedule, TableExt.MedicationSchedule>();
			CreateMap<TableExt.MedicationSchedule, DomainExt.MedicationSchedule>();
		}
    }
}
