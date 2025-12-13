using MediatR;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Commands
{
	/// <summary>
	/// Запрос на создание связи пользователя и лекарственного средства
	/// </summary>
    public class CreatePersonMedicamentCommand : IRequest<int>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="CreatePersonMedicamentCommand"/> class.
		/// </summary>
		/// <param name="externalUserId"><inheritdoc cref="ExternalUserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public CreatePersonMedicamentCommand(
			string externalUserId,
			CreatePersonMedicamentDTO request)
		{
			this.ExternalUserId = externalUserId;
			this.Request = request;
		}

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalUserId { get; }

		/// <inheritdoc cref="CreatePersonMedicamentDTO" path="/summary"/>
		public CreatePersonMedicamentDTO Request { get; }
	}
}
