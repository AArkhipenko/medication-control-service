namespace MedicationControl.Service.Application.Dictionary.DTO;

/// <summary>
/// Элемент словаря
/// </summary>
public sealed record class Element
{
    /// <summary>
    /// ИД записи
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; init; } 

    /// <summary>
    /// Код
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// Полное наименование
    /// </summary>
    public string? FullName { get; init; }
}