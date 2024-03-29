﻿using System.Reflection;
using System.Text;
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

    /// <summary>
    /// Combines a list of strings to a single string where each entered value gets its own line
    /// <example>
    /// <code>
    /// var result = Core.CombineString("Value1", "Value2", "Value3");
    ///
    /// Console.WriteLine(result);
    ///
    /// // Result
    /// Value1
    /// Value2
    /// Value3
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="values">The list with the values</param>
    /// <returns>The values as single string. Each value in its own line</returns>
    public static string CombineString(params string[] values)
    {
        var sb = new StringBuilder();
        foreach (var value in values)
        {
            sb.AppendLine(value);
        }

        return sb.ToString();
    }
}