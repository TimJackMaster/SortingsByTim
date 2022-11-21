using TJMSorts.AttributeClasses;

namespace TJMSorts;

/// <summary>
/// Options for using the sorting algorithms.
/// </summary>
public class SortingOptions
{
    /// <summary>
    /// Constant string use when loading options from appsettings.json.
    /// </summary>
    public const string Sorting = "Sorting";
    /// <summary>
    /// Used Algorithm.
    /// </summary>
    public Algorithm Algorithm { get; set; }
    /// <summary>
    /// Optional Observer implementing ISortingObserver.
    /// </summary>
    public ISortingObserver? Observer { get; set; } = null;
}