using Microsoft.Extensions.DependencyInjection;
using TJMSorts.Algorithms;
using TJMSorts.Components;

namespace TJMSorts;

/// <summary>
/// Service extension used to register dependency injection for the TJMSorts library.
/// </summary>
public static class ServiceExtensions
{
    private static SortingOptions _options = new();
    
    /// <summary>
    /// Registers all components to use ISorter in the dependency injection container.
    /// </summary>
    /// <param name="services">Service Collection</param>
    /// <param name="options">Options configuring the components.</param>
    /// <returns></returns>
    public static IServiceCollection RegisterSorting(this IServiceCollection services, SortingOptions options)
    {
        _options = options;

        services = services.RegisterComponents();
        services = services.RegisterAlgorithm();
        services.AddTransient<ISorter, Sorter>();
        
        return services;
    }

    private static IServiceCollection RegisterComponents(this IServiceCollection services)
    {
        services.AddTransient<IComparisonEncapsulation, ComparisonEncapsulation>();
        services.AddTransient<ISwapEncapsulation, SwapEncapsulation>();

        return services;
    }

    private static IServiceCollection RegisterAlgorithm(this IServiceCollection services)
    {
        switch (_options.Algorithm)
        {
            case Algorithm.BubbleSort:
                services.AddTransient<ISortingAlgorithm, BubbleSort>();
                break;
            default:
                throw new Exception("Algorithm not implemented");
        }

        return services;
    }
}