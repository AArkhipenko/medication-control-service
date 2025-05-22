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
	/// Контроллер-пример
	/// </summary>
    [ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("person-medicaments/v{version:apiVersion}")]
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
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>ИД новой записи</returns>
		[HttpPost]
		[Authorize("UserRole")]
		public async Task<ActionResult<int>> CreateAsync(CreatePersonMedicamentDTO request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var user = await this._userProvider.GetUserAsync(cancellationToken);

				return await this._mediator.Send(new CreatePersonMedicamentCommand(user.Id, request), cancellationToken);
			}
		}
	}
}