using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.Mediatr.Abstractions;

namespace MedicationControl.Service.Application.PersonMedicament.Commands;

/// <summary>
/// Запрос на удаление связи пользователя и лекарственного средства.
/// </summary>
public sealed class DeletePersonMedicamentCommand : UserBasedCommand, IRequest, IUserDataPermissionCheck
{
	/// <summary>
	/// Initializes a new instance of the <see cref="DeletePersonMedicamentCommand"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
	public DeletePersonMedicamentCommand(
		string externalUserId,
		int personMedicamentId):
		base(externalUserId)
	{
		this.PersonMedicamentId = personMedicamentId;
	}

	/// <inheritdoc/>
	public int PersonMedicamentId { get; }
}
