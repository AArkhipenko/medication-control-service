using Asp.Versioning;
using MediatR;
using MedicationControl.Service.Application.Dictionary.DTO;
using MedicationControl.Service.Application.Dictionary.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicationControl.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер для работы со справочниками
	/// </summary>
	[ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("dictionaries/v{version:apiVersion}")]
	[Authorize("UserRole")]
	public class DictionaryController : ApiAuthBaseController
	{
		private readonly IMediator _mediator;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="DictionaryController"/> class.
		/// </summary>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public DictionaryController(
			IMediator mediator,
			ILogger<MedicamentPurchaseController> logger)
			: base(logger)
		{
			this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		
		/// <summary>
		/// Получение списка лекарственных средств
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Список лекарственных средств</returns>
		[HttpGet("medicament-type/list")]
		public async Task<ActionResult<IEnumerable<Element>>> GetMedicamentTypeListAsync(CancellationToken cancellationToken = default)
		{
			using (_ = base.BeginLoggingScope())
			{
				var list = await this._mediator.Send(new GetMedicamentTypeListQuery(), cancellationToken);
				return Ok(list);
			}
		}

		/// <summary>
		/// Получение списка пользовательского представления времени суток
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Список лекарственных средств</returns>
		[HttpGet("day-time-type/list")]
		public async Task<ActionResult<IEnumerable<Element>>> GetDayTimeTypeListAsync(CancellationToken cancellationToken = default)
		{
			using (_ = base.BeginLoggingScope())
			{
				var list = await this._mediator.Send(new GetDayTimeTypeListQuery(), cancellationToken);
				return Ok(list);
			}
		}
	}
}