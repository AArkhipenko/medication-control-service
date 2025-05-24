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
		/// <param name="userId"><inheritdoc cref="UserId" path="/summary"/></param>
		/// <param name="request"><inheritdoc cref="Request" path="/summary"/></param>
		public UpdatePersonMedicamentCommand(
			int userId,
			PersonMedicamentDTO request)
		{
			this.UserId = userId;
			this.Request = request;
		}

		/// <summary>
		/// ИД пользователя
		/// </summary>
		public int UserId { get; }

		/// <inheritdoc cref="PersonMedicamentDTO" path="/summary"/>
		public PersonMedicamentDTO Request { get; }
	}
}
