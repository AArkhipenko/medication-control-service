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
		/// <param name="userId"><inheritdoc cref="UserId" path="/summary"/></param>
		/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
		public DeletePersonMedicamentCommand(
			int userId,
			int personMedicamentId)
		{
			this.UserId = userId;
			this.PersonMedicamentId = personMedicamentId;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int UserId { get; }

		/// <summary>
		/// ИД связи пользователя с лекарственным средством
		/// </summary>
		public int PersonMedicamentId { get; }
	}
}
