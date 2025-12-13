using MediatR;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Commands
{
	/// <summary>
	/// Запрос на изменение связи пользователя и лекарственного средства
	/// </summary>
    public class UpdatePersonMedicamentCommand : IRequest
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UpdatePersonMedicamentCommand"/> class.
		/// </summary>
		/// <param name="externalUserId"><inheritdoc cref="ExternalUserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public UpdatePersonMedicamentCommand(
			string externalUserId,
			PersonMedicamentDTO request)
		{
			this.ExternalUserId = externalUserId;
			this.Request = request;
		}

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalUserId { get; }

		/// <inheritdoc cref="PersonMedicamentDTO" path="/summary"/>
		public PersonMedicamentDTO Request { get; }
	}
}
