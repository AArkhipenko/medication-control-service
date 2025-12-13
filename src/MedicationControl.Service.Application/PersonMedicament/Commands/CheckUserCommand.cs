using MediatR;
using MedicationControl.Service.Application.Common;

namespace MedicationControl.Service.Application.PersonMedicament.Commands
{
	/// <summary>
	/// Запрос на проверку пользователя из токена с пользователм из записи в БД
	/// </summary>
    internal class CheckUserCommand : UserBasedCommand, IRequest
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="CheckUserCommand"/> class.
		/// </summary>
		/// <param name="externalUserId"><inheritdoc cref="UserBasedCommand.ExternalUserId" path="/summary"/></param>
		/// <param name="personMedicamentId"><inheritdoc cref="PersonMedicamentId" path="/summary"/></param>
		public CheckUserCommand(string externalUserId, int personMedicamentId)
			: base(externalUserId)
		{
			this.PersonMedicamentId = personMedicamentId;
		}

		/// <summary>
		/// ИД связи пользователя с лекарственным средством
		/// </summary>
		public int PersonMedicamentId { get; }
	}
}
