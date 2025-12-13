using System.Text;
using MedicationControl.Service.Domain.Models;
using MedicationControl.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicationControl.Service.Infrastructure.Database.Repositories;

/// <inheritdoc cref="IDictionaryRepository"/>
internal class DictionaryRepository : IDictionaryRepository
{
	private readonly ControlContext _context;

	/// <summary>
	/// Initializes a new instance of the <see cref="DictionaryRepository"/> class.
	/// </summary>
	/// <param name="context"><see cref="ControlContext"/></param>
	public DictionaryRepository(
		ControlContext context)
	{
		this._context = context ?? throw new ArgumentNullException(nameof(context));
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<DictionaryElement>> GetMedicamentTypeList(CancellationToken cancellationToken)
	{
		var list = await this._context.MedicamentTypes
			.Include(x => x.ActiveSubstanceType)
			.Select(x => new
			{
				Id = x.Id,
				Name = x.Name,
				Code = x.Code,
				Dosage = x.Dosage,
				ActiveSubstanceName = x.ActiveSubstanceTypeId.HasValue ? x.ActiveSubstanceType.Name : null
			})
			.ToListAsync(cancellationToken);

		return list.Select(x =>
		{
			var fullNameBuilder = new StringBuilder(x.Name);
			if (!string.IsNullOrEmpty(x.Dosage) ||
				!string.IsNullOrEmpty(x.ActiveSubstanceName))
			{
				fullNameBuilder.Append(" (");
				if (!string.IsNullOrEmpty(x.Dosage))
				{
					fullNameBuilder.Append(x.Dosage);
				}

				if (!string.IsNullOrEmpty(x.Dosage) &&
					!string.IsNullOrEmpty(x.ActiveSubstanceName))
				{
					fullNameBuilder.Append(" ");
				}

				if (!string.IsNullOrEmpty(x.ActiveSubstanceName))
				{
					fullNameBuilder.Append(x.ActiveSubstanceName);
				}

				fullNameBuilder.Append(")");
			}

			return new DictionaryElement
			{
				Id = x.Id,
				Name = x.Name,
				Code = x.Code,
				FullName = fullNameBuilder.ToString()
			};
		});
	}

	/// <inheritdoc/>
	public Task<List<DictionaryElement>> GetDayTimeTypeList(CancellationToken cancellationToken)
	{
		return this._context.DayTimeTypes
			.Select(x => new DictionaryElement
			{
				Id = x.Id,
				Name = x.Name,
				Code = x.Code,
				FullName = $"{x.Name} ({x.Time.ToString("HH:mm")})"
			})
			.ToListAsync(cancellationToken);
	}
}