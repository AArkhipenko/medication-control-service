using AutoMapper;

using DomainExt = MedicationControl.Service.Domain.Models;
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
			// Расписание приема лекарств
			CreateMap<DomainExt.MedicationSchedule, MedicationScheduleExt.MedicationScheduleDTO>()
				.ForMember(dto => dto.MedicationScheduleId, dto => dto.MapFrom(x => x.Id));
		}
	}
}
