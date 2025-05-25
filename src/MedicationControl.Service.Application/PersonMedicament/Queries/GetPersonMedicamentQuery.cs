using MediatR;
using MedicationControl.Service.Application.PersonMedicament.DTO;

namespace MedicationControl.Service.Application.PersonMedicament.Queries
{
	/// <summary>
	/// Запрос на получение информации о связи пользователя с лекарственным средством
	/// </summary>
	/// <remarks>
	/// Здесь реализована логика проверки пользователя из токена и пользователя из записи в БД
	/// </remarks>
    internal class GetPersonMedicamentQuery : IRequest<PersonMedicamentDTO>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="GetPersonMedicamentQuery"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserId" path="/summary"/></param>
		/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
		public GetPersonMedicamentQuery(
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
