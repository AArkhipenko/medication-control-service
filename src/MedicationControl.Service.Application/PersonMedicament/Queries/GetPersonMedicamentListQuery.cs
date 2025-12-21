using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Queries;

/// <summary>
/// Запрос на получение полного списка лекарств, назначенных пользователю.
/// </summary>
public sealed class GetPersonMedicamentListQuery : UserBasedCommand, IRequest<IEnumerable<PersonMedicamentDto>>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GetPersonMedicamentListQuery"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	public GetPersonMedicamentListQuery(string externalUserId)
		: base(externalUserId)
	{
	}
}
