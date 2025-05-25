using AArkhipenko.UserHelper.Providers;
using Asp.Versioning;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Application.PersonMedicament.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace MedicationControl.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер для работу лекарственными средствами, что назначены пользователю
	/// </summary>
	[ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("person-medicaments/v{version:apiVersion}")]
	[Authorize("UserRole")]
	public class PersonMedicamentController : ApiAuthBaseController
	{
		private readonly IUserProvider _userProvider;
		private readonly IMediator _mediator;
		/// <summary>
		/// Initializes a new instance of the <see cref="PersonMedicamentController"/> class.
		/// </summary>
		/// <param name="userProvider"><see cref="IUserProvider"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public PersonMedicamentController(
			IUserProvider userProvider,
			IMediator mediator,
			ILogger<PersonMedicamentController> logger)
			: base(logger)
		{
			this._userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Создание связи пользователя с лекарственным средством
		/// </summary>
		/// <param name="request"><inheritdoc cref="CreatePersonMedicamentDTO" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		[HttpPost]
		public async Task<ActionResult<int>> CreateAsync(CreatePersonMedicamentDTO request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				return await this._mediator.Send(new CreatePersonMedicamentCommand(user.Id, request), cancellationToken);
			}
		}

		/// <summary>
		/// Обновление связи пользователя с лекарственным средством
		/// </summary>
		/// <param name="request"><inheritdoc cref="PersonMedicamentDTO" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		[HttpPatch]
		public async Task<IActionResult> UpdateAsync(PersonMedicamentDTO request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				await this._mediator.Send(new UpdatePersonMedicamentCommand(user.Id, request), cancellationToken);
				return NoContent();
			}
		}

		/// <summary>
		/// Удаление связи пользователя с лекарственным средством
		/// </summary>
		/// <param name="id">ИД связи пользователя с лекарственным средством</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				await this._mediator.Send(new DeletePersonMedicamentCommand(user.Id, id), cancellationToken);
				return NoContent();
			}
		}
	}
}