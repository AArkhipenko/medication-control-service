using AArkhipenko.UserHelper.Providers;
using Asp.Versioning;
using MediatR;
using MedicationControl.Service.Application.MedicationSchedule.Commands;
using MedicationControl.Service.Application.MedicationSchedule.DTO;
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
	/// Котроллер для работы с расписанием приема лекарственных средств
	/// </summary>
	[ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("medication-schedules/v{version:apiVersion}")]
	[Authorize("UserRole")]
	public class MedicationScheduleController : ApiAuthBaseController
	{
		private readonly IUserProvider _userProvider;
		private readonly IMediator _mediator;
		/// <summary>
		/// Initializes a new instance of the <see cref="MedicationScheduleController"/> class.
		/// </summary>
		/// <param name="userProvider"><see cref="IUserProvider"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public MedicationScheduleController(
			IUserProvider userProvider,
			IMediator mediator,
			ILogger<MedicationScheduleController> logger)
			: base(logger)
		{
			this._userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Создание расписания приема лекарственного средства
		/// </summary>
		/// <param name="request"><inheritdoc cref="CreateMedicationScheduleDTO" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		[HttpPost]
		public async Task<ActionResult<int>> CreateAsync(CreateMedicationScheduleDTO request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				var id = await this._mediator.Send(
					new CreateMedicationScheduleCommand(user.Id, request),
					cancellationToken);

				return Ok(id);
			}
		}

		/// <summary>
		/// Изменение расписания приема лекарственного средства
		/// </summary>
		/// <param name="request"><inheritdoc cref="MedicationScheduleDTO" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		[HttpPatch]
		public async Task<IActionResult> UpdateAsync(MedicationScheduleDTO request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				await this._mediator.Send(
					new UpdateMedicationScheduleCommand(user.Id, request),
					cancellationToken);

				return NoContent();
			}
		}

		/// <summary>
		/// Удаление расписания приема лекарственного средства
		/// </summary>
		/// <param name="id">ИД расписания приема лекарственного средства</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				await this._mediator.Send(
					new DeletePersonMedicamentCommand(user.Id, id),
					cancellationToken);

				return NoContent();
			}
		}
	}
}