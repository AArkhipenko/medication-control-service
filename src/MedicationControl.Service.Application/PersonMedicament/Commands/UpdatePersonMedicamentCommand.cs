using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.Mediatr.Abstractions;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Commands;

/// <summary>
/// Запрос на изменение связи пользователя и лекарственного средства.
/// </summary>
public sealed class UpdatePersonMedicamentCommand : UserBasedCommand, IRequest, IUserDataPermissionCheck
{
	/// <summary>
	/// Initializes a new instance of the <see cref="UpdatePersonMedicamentCommand"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
	public UpdatePersonMedicamentCommand(
		string externalUserId,
		PersonMedicamentDto request)
		:base(externalUserId)
	{
		this.Request = request;
	}

	/// <inheritdoc cref="PersonMedicamentDto" path="/summary"/>
	public PersonMedicamentDto Request { get; }

	/// <inheritdoc/>
	public int PersonMedicamentId => Request.PersonMedicamentId;
}
