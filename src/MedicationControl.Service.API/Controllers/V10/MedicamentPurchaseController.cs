using AArkhipenko.UserHelper.Providers;
using Asp.Versioning;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.Commands;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicationControl.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер для работы с закупками лекарств
	/// </summary>
	[ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("medication-purchases/v{version:apiVersion}")]
	[Authorize("UserRole")]
	public class MedicamentPurchaseController : ApiAuthBaseController
	{
		private readonly IUserProvider _userProvider;
		private readonly IMediator _mediator;
		/// <summary>
		/// Initializes a new instance of the <see cref="MedicamentPurchaseController"/> class.
		/// </summary>
		/// <param name="userProvider"><see cref="IUserProvider"/></param>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public MedicamentPurchaseController(
			IUserProvider userProvider,
			IMediator mediator,
			ILogger<MedicamentPurchaseController> logger)
			: base(logger)
		{
			this._userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider));
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Создание закупки лекарства
		/// </summary>
		/// <param name="request"><inheritdoc cref="CreateMedicamentPurchaseDTO" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>ИД новой записи</returns>
		[HttpPost]
		public async Task<ActionResult<int>> CreateAsync(CreateMedicamentPurchaseDTO request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				var id = await this._mediator.Send(
					new CreateMedicamentPurchaseCommand(user.Id, request),
					cancellationToken);

				return Ok(id);
			}
		}

		/// <summary>
		/// Изменение закупки лекарства
		/// </summary>
		/// <param name="request"><inheritdoc cref="MedicamentPurchaseDTO" path="/summary"/></param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		[HttpPatch]
		public async Task<IActionResult> UpdateAsync(MedicamentPurchaseDTO request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				var id = await this._mediator.Send(
					new CreateMedicamentPurchaseCommand(user.Id, request),
					cancellationToken);

				return NoContent();
			}
		}

		/// <summary>
		/// Удаление закупки лекарства
		/// </summary>
		/// <param name="id">ИД закупки лекарства</param>
		/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
		/// <returns>Ничего</returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				await this._mediator.Send(
					new DeleteMedicamentPurchaseCommand(user.Id, id),
					cancellationToken);

				return NoContent();
			}
		}
	}
}