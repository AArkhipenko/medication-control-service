using AutoMapper;

using DomainExt = MedicationControl.Service.Domain.Models;
using PersonMedicamentExt = MedicationControl.Service.Application.PersonMedicament.DTO;
using MedicationScheduleExt = MedicationControl.Service.Application.MedicationSchedule.DTO;

namespace MedicationControl.Service.Application.Helper
{
	/// <summary>
	/// Автомаппер DTO на доменную модель
	/// </summary>
	internal class DomainDtoProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DomainDtoProfile"/> class.
		/// </summary>
		public DomainDtoProfile()
		{
			// Лекарства, назначенные пользователю
			CreateMap<DomainExt.PersonMedicament, PersonMedicamentExt.PersonMedicamentDto>()
				.ForMember(dto => dto.PersonMedicamentId, dto => dto.MapFrom(x => x.Id));

			// Расписание приема лекарств
			CreateMap<DomainExt.MedicationSchedule, MedicationScheduleExt.MedicationScheduleDto>()
				.ForMember(dto => dto.MedicationScheduleId, dto => dto.MapFrom(x => x.Id));
		}
	}
}
