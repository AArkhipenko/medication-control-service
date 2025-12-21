using AArkhipenko.Core.Exceptions;
using AArkhipenko.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicationControl.Service.Infrastructure.Database.Repositories;

/// <summary>
/// Ощий функционал всех репозиториев
/// </summary>
/// <typeparam name="TEntity">Тип данных в БД</typeparam>
internal abstract class GeneralRepository<TEntity> : LoggerWrapper
	where TEntity: class
{
	private readonly ControlContext _context;

	/// <summary>
	/// Initializes a new instance of the <see cref="GeneralRepository{TEntity}"/> class.
	/// </summary>
	/// <param name="context"><see cref="ControlContext"/></param>
	/// <param name="logger"><see cref="ILogger"/></param>
	/// <exception cref="ArgumentNullException">Не задан один из входных параметров</exception>
	protected GeneralRepository(
		ControlContext context,
		ILogger<GeneralRepository<TEntity>> logger)
		: base(logger)
	{
		this._context = context ?? throw new ArgumentNullException(nameof(context));
	}

	/// <summary>
	/// Получение сущности из БД
	/// </summary>
	/// <param name="id">ключ для поиска</param>
	/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
	/// <returns>Сущность из БД</returns>
	/// <exception cref="NotFoundException">Сущность не найдена по ключу</exception>
	protected Task<TEntity> GetEntityAsync(int id, CancellationToken cancellationToken)
		=> this.GetEntityAsync(new object[] { id }, cancellationToken);

	/// <summary>
	/// Получение сущности из БД
	/// </summary>
	/// <param name="keyValues">ключ для поиска</param>
	/// <param name="cancellationToken"><inheritdoc cref="CancellationToken" path="/summary"/></param>
	/// <returns>Сущность из БД</returns>
	/// <exception cref="NotFoundException">Сущность не найдена по ключу</exception>
	private async Task<TEntity> GetEntityAsync(object?[]? keyValues, CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();
		var member = await this._context.Set<TEntity>().FindAsync(keyValues, cancellationToken);
		if(member is null)
		{
			var tableName = this._context.Set<TEntity>().EntityType.GetTableName();
			throw new NotFoundException($"В таблице {tableName} не найдена запись с id={keyValues}");
		}

		return member;
	}
}
