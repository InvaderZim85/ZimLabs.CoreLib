using System.Reflection;
using ZimLabs.CoreLib.Common;
using ZimLabs.CoreLib.DataObjects;

namespace ZimLabs.CoreLib;

/// <summary>
/// Provides several helper functions
/// </summary>
public static class Core
{
    /// <summary>
    /// Gets the path of the base directory
    /// </summary>
    /// <returns>The path of the base directory</returns>
    public static string GetBaseDirPath()
    {
        var assemblyPath = Assembly.GetExecutingAssembly().Location;
        return Path.GetDirectoryName(assemblyPath) ?? "";
    }

    /// <summary>
    /// Checks if the value matches the desired filter
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="filter">The filter</param>
    /// <returns><see langword="true"/> when the filter matches, otherwise <see langword="false"/></returns>
    public static bool MatchFilter(string value, FilterEntry filter)
    {
        return filter.FilterType switch
        {
            FilterType.Contains => value.Contains(filter.Value, StringComparison.OrdinalIgnoreCase),
            FilterType.Equals => value.Equals(filter.Value, StringComparison.OrdinalIgnoreCase),
            FilterType.StartsWith => value.StartsWith(filter.Value, StringComparison.OrdinalIgnoreCase),
            FilterType.EndsWith => value.EndsWith(filter.Value, StringComparison.OrdinalIgnoreCase),
            _ => false
        };
    }
}