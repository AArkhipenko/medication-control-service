namespace MedicationControl.Service.Application.Common
{
	/// <summary>
	/// Шаблон запроса, в котором обязательно указание ИД пользователя
	/// </summary>
    public abstract class UserBasedCommand
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="UserBasedCommand"/> class.
		/// </summary>
		/// <param name="userId"><inheritdoc cref="UserId" path="/summary"/></param>
		public UserBasedCommand(int userId)
		{
			this.UserId = userId;
		}

		 /// <summary>
		/// ИД пользователя
		/// </summary>
		public int UserId { get; }
    }
}
