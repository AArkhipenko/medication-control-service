using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.Mediatr.Abstractions;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Queries;

/// <summary>
/// Запрос на получение информации о связи пользователя с лекарственным средством.
/// </summary>
internal sealed class GetPersonMedicamentQuery : UserBasedCommand, IRequest<PersonMedicamentDto>, IUserDataPermissionCheck
{
	/// <summary>
	/// Initializes a new instance of the <see cref="GetPersonMedicamentQuery"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
	public GetPersonMedicamentQuery(
		string externalUserId,
		int personMedicamentId)
		: base(externalUserId)
	{
		this.PersonMedicamentId = personMedicamentId;
	}

	/// <inheritdoc/>
	public int PersonMedicamentId { get; }
}
