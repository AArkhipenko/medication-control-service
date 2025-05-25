using AutoMapper;

using DomainExt = MedicationControl.Service.Domain.Models;
using PersonMedicamentExt = MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationScheduleExt = MedicationControl.Service.Application.MedicationSchedule.Commands;
using MedicamentPurchaseExt = MedicationControl.Service.Application.MedicamentPurchase.Commands;

namespace MedicationControl.Service.Application.Helper
{
	/// <summary>
	/// Автомаппер запросов на доменную модель
	/// </summary>
	internal class CommandDomainProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CommandDomainProfile"/> class.
		/// </summary>
		public CommandDomainProfile()
		{
			// Лекарства назначенные пользователю
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

			// Расписание приема лекарств
			CreateMap<MedicationScheduleExt.CreateMedicationScheduleCommand, DomainExt.MedicationSchedule>()
				.ForMember(domain => domain.PersonMedicamentId, dto => dto.MapFrom(x => x.Request.PersonMedicamentId))
				.ForMember(domain => domain.DayTimeTypeId, dto => dto.MapFrom(x => x.Request.DayTimeTypeId))
				.ForMember(domain => domain.Time, dto => dto.MapFrom(x => x.Request.DayTimeTypeId.HasValue ? null : x.Request.Time))
				.ForMember(domain => domain.Amount, dto => dto.MapFrom(x => x.Request.Amount));

			CreateMap<MedicationScheduleExt.UpdateMedicationScheduleCommand, DomainExt.MedicationSchedule>()
				.ForMember(domain => domain.Id, dto => dto.MapFrom(x => x.Request.MedicationScheduleId))
				.ForMember(domain => domain.PersonMedicamentId, dto => dto.MapFrom(x => x.Request.PersonMedicamentId))
				.ForMember(domain => domain.DayTimeTypeId, dto => dto.MapFrom(x => x.Request.DayTimeTypeId))
				.ForMember(domain => domain.Time, dto => dto.MapFrom(x => x.Request.DayTimeTypeId.HasValue ? null : x.Request.Time))
				.ForMember(domain => domain.Amount, dto => dto.MapFrom(x => x.Request.Amount));

			// Закупки лекарств
			CreateMap<MedicamentPurchaseExt.CreateMedicamentPurchaseCommand, DomainExt.MedicamentPurchase>()
				.ForMember(domain => domain.PersonMedicamentId, dto => dto.MapFrom(x => x.Request.PersonMedicamentId))
				.ForMember(domain => domain.PurchaseAmount, dto => dto.MapFrom(x => x.Request.PurchaseAmount))
				.ForMember(domain => domain.RemainingAmount, dto => dto.MapFrom(x => x.Request.RemainingAmount))
				.ForMember(domain => domain.Date, dto => dto.MapFrom(x => x.Request.Date));
		}
	}
}
