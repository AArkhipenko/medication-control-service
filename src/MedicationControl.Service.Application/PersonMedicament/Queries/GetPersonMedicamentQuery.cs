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
		/// <param name="externalUserId"><inheritdoc cref="ExternalUserId" path="/summary"/></param>
		/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
		public GetPersonMedicamentQuery(
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
