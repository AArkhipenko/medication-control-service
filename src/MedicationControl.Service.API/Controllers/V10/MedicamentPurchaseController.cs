using AArkhipenko.UserHelper.Helpers;
using Asp.Versioning;
using MediatR;
using MedicationControl.Service.Application.MedicamentPurchase.Commands;
using MedicationControl.Service.Application.MedicamentPurchase.DTO;
using MedicationControl.Service.Application.MedicamentPurchase.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicationControl.Service.API.Controllers.V10;

/// <summary>
/// Контроллер для работы с закупками лекарств
/// </summary>
[ApiController]
[ApiVersion("10", Deprecated = false)]
[Route("medication-purchases/v{version:apiVersion}")]
[Authorize("UserRole")]
public class MedicamentPurchaseController : ApiAuthBaseController
{
	private readonly IUserHelper _userHelper;
	private readonly IMediator _mediator;
	/// <summary>
	/// Initializes a new instance of the <see cref="MedicamentPurchaseController"/> class.
	/// </summary>
	/// <param name="userHelper"><see cref="IUserHelper"/>.</param>
	/// <param name="mediator"><see cref="IMediator"/>.</param>
	/// <param name="logger"><see cref="ILogger"/>.</param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров.</exception>
	public MedicamentPurchaseController(
		IUserHelper userHelper,
		IMediator mediator,
		ILogger<MedicamentPurchaseController> logger)
		: base(logger)
	{
		this._userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
		this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}

	/// <summary>
	/// Создание закупки лекарства
	/// </summary>
	/// <param name="request"><inheritdoc cref="CreateMedicamentPurchaseDto" path="/summary"/></param>
	/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
	/// <returns>ИД новой записи</returns>
	[HttpPost]
	public async Task<ActionResult<int>> CreateAsync(CreateMedicamentPurchaseDto request, CancellationToken cancellationToken)
	{
		using (_ = base.BeginLoggingScope())
		{
			var user = await this._userHelper.GetUserAsync(cancellationToken);

			var id = await this._mediator.Send(
				new CreateMedicamentPurchaseCommand(user.ExternalId, request),
				cancellationToken);

			return Ok(id);
		}
	}

	/// <summary>
	/// Изменение закупки лекарства
	/// </summary>
	/// <param name="request"><inheritdoc cref="MedicamentPurchaseDto" path="/summary"/></param>
	/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
	/// <returns>Ничего</returns>
	[HttpPatch]
	public async Task<IActionResult> UpdateAsync(MedicamentPurchaseDto request, CancellationToken cancellationToken)
	{
		using (_ = base.BeginLoggingScope())
		{
			var user = await this._userHelper.GetUserAsync(cancellationToken);

			await this._mediator.Send(
				new UpdateMedicamentPurchaseCommand(user.ExternalId, request),
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
			var user = await this._userHelper.GetUserAsync(cancellationToken);

			await this._mediator.Send(
				new DeleteMedicamentPurchaseCommand(user.ExternalId, id),
				cancellationToken);

			return NoContent();
		}
	}

	/// <summary>
	/// Получение списка закупок лекарств.
	/// </summary>
	/// <param name="cancellationToken">Токен отмены.</param>
	/// <returns>Список закупок лекарственных средств пользователя.</returns>
	/// <example>
	/// /medication-purchases/v10/list#GET
	/// </example>
	[HttpGet("list")]
	public async Task<ActionResult<IEnumerable<MedicamentPurchaseDto>>> GetListAsync(CancellationToken cancellationToken)
	{
		using (_ = base.BeginLoggingScope())
		{
			cancellationToken.ThrowIfCancellationRequested();
			
			var user = await this._userHelper.GetUserAsync(cancellationToken);

			var list = await this._mediator.Send(
				new GetMedicamentPurchaseListQuery(user.ExternalId),
				cancellationToken);

			return Ok(list);
		}
	}
}