using Microsoft.Extensions.DependencyInjection;
using TJMSorts.Algorithms;
using TJMSorts.Algorithms.Components;

namespace TJMSorts;

public static class ServiceExtensions
{
    private static SortingOptions _options = new();
    
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