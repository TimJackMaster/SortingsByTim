using TJMSorts.AttributeClasses;
using TJMSorts.Enums;

namespace TJMSorts;

/// <summary>
/// Options for using the sorting algorithms.
/// </summary>
public class SortingOptions<T>
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
    /// The used ISortingObserver. Default is <see cref="DefaultObserver{T}"/>
    /// </summary>
    public ISortingObserver<T> Observer { get; set; } = new DefaultObserver<T>();

    /// <summary>
    /// Strategy used for component operations.
    /// </summary>
    public IList<ComponentDecoration> ComponentStrategy { get; set; }
        = new List<ComponentDecoration>{ ComponentDecoration.Base, };
    
    /// <summary>
    /// Strategy used for algorithm operations.
    /// </summary>
    public IList<AlgorithmDecoration> AlgorithmStrategy { get; set; }
        = new List<AlgorithmDecoration>{ AlgorithmDecoration.Base, };

    /// <summary>
    /// Provides a default set of options.
    /// </summary>
    public static SortingOptions<T> Default => new SortingOptions<T>
    {
        Algorithm = Algorithm.BubbleSort
    };
}