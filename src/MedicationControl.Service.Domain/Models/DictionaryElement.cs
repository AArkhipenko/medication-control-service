namespace MedicationControl.Service.Domain.Models;

/// <summary>
/// Элемент словаря
/// </summary>
public class DictionaryElement
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