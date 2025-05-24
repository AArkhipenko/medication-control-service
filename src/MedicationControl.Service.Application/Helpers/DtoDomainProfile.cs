using AutoMapper;

using DomainExt = MedicationControl.Service.Domain.Models;
using PersonMedicamentExt = MedicationControl.Service.Application.PersonMedicament.Commands;

namespace MedicationControl.Service.Application.Helper
{
	/// <summary>
	/// Автомаппер DTO на доменную модель
	/// </summary>
	internal class DtoDomainProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DtoDomainProfile"/> class.
		/// </summary>
		public DtoDomainProfile()
		{
			CreateMap<PersonMedicamentExt.UpdatePersonMedicamentCommand, DomainExt.PersonMedicament>()
				.ForMember(domain => domain.Id, dto => dto.MapFrom(x => x.Request.PersonMedicamentId))
				.ForMember(domain => domain.UserId, dto => dto.MapFrom(x => x.UserId))
				.ForMember(domain => domain.MedicamentTypeId, dto => dto.MapFrom(x => x.Request.MedicamentTypeId))
				.ForMember(domain => domain.StartDate, dto => dto.MapFrom(x => x.Request.StartDate))
				.ForMember(domain => domain.EndDate, dto => dto.MapFrom(x => x.Request.EndDate));

			CreateMap<PersonMedicamentExt.CreatePersonMedicamentCommand, DomainExt.PersonMedicament>()
				.ForMember(domain => domain.UserId, dto => dto.MapFrom(x => x.UserId))
				.ForMember(domain => domain.MedicamentTypeId, dto => dto.MapFrom(x => x.Request.MedicamentTypeId))
				.ForMember(domain => domain.StartDate, dto => dto.MapFrom(x => x.Request.StartDate))
				.ForMember(domain => domain.EndDate, dto => dto.MapFrom(x => x.Request.EndDate));
		}
	}
}
