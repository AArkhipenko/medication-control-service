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
		/// <param name="userId"><inheritdoc cref="UserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public CreatePersonMedicamentCommand(
			int userId,
			CreatePersonMedicamentDTO request)
		{
			this.UserId = userId;
			this.Request = request;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int UserId { get; }

		/// <inheritdoc cref="CreatePersonMedicamentDTO" path="/summary"/>
		public CreatePersonMedicamentDTO Request { get; }
	}
}
