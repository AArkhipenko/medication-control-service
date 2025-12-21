using AArkhipenko.UserHelper.Helpers;
using Asp.Versioning;
using MediatR;
using MedicationControl.Service.Application.PersonMedicament.Commands;
using MedicationControl.Service.Application.PersonMedicament.DTO;
using MedicationControl.Service.Application.PersonMedicament.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
		private readonly IUserHelper _userHelper;
		private readonly IMediator _mediator;
		/// <summary>
		/// Initializes a new instance of the <see cref="PersonMedicamentController"/> class.
		/// </summary>
		/// <param name="userHelper"><see cref="IUserHelper"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
		public PersonMedicamentController(
			IUserHelper userHelper,
			IMediator mediator,
			ILogger<PersonMedicamentController> logger)
			: base(logger)
		{
			this._userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Создание связи пользователя с лекарственным средством
		/// </summary>
		/// <param name="request"><inheritdoc cref="CreatePersonMedicamentDto" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		[HttpPost]
		public async Task<ActionResult<int>> CreateAsync(CreatePersonMedicamentDto request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userHelper.GetUserAsync(cancellationToken);

				var id = await this._mediator.Send(
					new CreatePersonMedicamentCommand(user.ExternalId, request),
					cancellationToken);

				return Ok(id);
			}
		}

		/// <summary>
		/// Обновление связи пользователя с лекарственным средством
		/// </summary>
		/// <param name="request"><inheritdoc cref="PersonMedicamentDto" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		[HttpPatch]
		public async Task<IActionResult> UpdateAsync(PersonMedicamentDto request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userHelper.GetUserAsync(cancellationToken);

				await this._mediator.Send(
					new UpdatePersonMedicamentCommand(user.ExternalId, request),
					cancellationToken);

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
				var user = await this._userHelper.GetUserAsync(cancellationToken);

				await this._mediator.Send(
					new DeletePersonMedicamentCommand(user.ExternalId, id),
					cancellationToken);

				return NoContent();
			}
		}

		/// <summary>
		/// Получение полного списка лекарств назначенных пользователю
		/// </summary>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Полный список лекарств, назначенных пользователю</returns>
		/// <remarks>
		/// person-medicaments/v10/list#GET
		/// </remarks>
		[HttpGet("list")]
		public async Task<ActionResult<IEnumerable<PersonMedicamentDto>>> GetListAsync(CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userHelper.GetUserAsync(cancellationToken);

				var list = await this._mediator.Send(
					new GetPersonMedicamentListQuery(user.ExternalId),
					cancellationToken);

				return Ok(list);
			}
		}
	}
}