using MediatR;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Commands
{
	/// <summary>
	/// Запрос на удаление связи пользователя и лекарственного средства
	/// </summary>
    public class DeletePersonMedicamentCommand : IRequest
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="DeletePersonMedicamentCommand"/> class.
		/// </summary>
		/// <param name="externalUserId"><inheritdoc cref="ExternalUserId" path="/summary"/></param>
		/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
		public DeletePersonMedicamentCommand(
			string externalUserId,
			int personMedicamentId)
		{
			this.ExternalUserId = externalUserId;
			this.PersonMedicamentId = personMedicamentId;
		}

		/// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalUserId { get; }

		/// <summary>
		/// ИД связи пользователя с лекарственным средством
		/// </summary>
		public int PersonMedicamentId { get; }
	}
}
