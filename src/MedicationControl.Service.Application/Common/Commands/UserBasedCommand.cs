namespace MedicationControl.Service.Application.Common.Commands
{
	/// <summary>
	/// Шаблон запроса, в котором обязательно указание ИД пользователя
	/// </summary>
    public abstract class UserBasedCommand
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UserBasedCommand"/> class.
		/// </summary>
		/// <param name="externalUserId"><inheritdoc cref="ExternalUserId" path="/summary"/></param>
		protected UserBasedCommand(string externalUserId)
		{
			this.ExternalUserId = externalUserId;
		}

		 /// <summary>
		/// ИД пользователя во внешней системе
		/// </summary>
		public string ExternalUserId { get; }
    }
}
