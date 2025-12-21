using MediatR;
using MedicationControl.Service.Application.Common.Commands;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Commands;

/// <summary>
/// Запрос на создание связи пользователя и лекарственного средства.
/// </summary>
public sealed class CreatePersonMedicamentCommand : UserBasedCommand, IRequest<int>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CreatePersonMedicamentCommand"/> class.
	/// </summary>
	/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
	/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
	public CreatePersonMedicamentCommand(
		string externalUserId,
		CreatePersonMedicamentDto request)
		:base(externalUserId)
	{
		this.Request = request;
	}

	/// <inheritdoc cref="CreatePersonMedicamentDto" path="/summary"/>
	public CreatePersonMedicamentDto Request { get; }
}
