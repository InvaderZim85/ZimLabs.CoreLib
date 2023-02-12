using ZimLabs.CoreLib.Common;

namespace ZimLabs.CoreLib.DataObjects;

/// <summary>
/// Represents a filter entry
/// </summary>
public class FilterEntry
{
    /// <summary>
    /// Gets or sets the value to search for
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the desired filter
    /// </summary>
    public FilterType FilterType { get; set; } = FilterType.Equals;

    /// <summary>
    /// Gets or sets the original value (with wildcards)
    /// </summary>
    public string OriginalValue { get; set; } = string.Empty;

    /// <summary>
    /// Creates a new empty instance of the <see cref="FilterEntry"/>
    /// </summary>
    public FilterEntry() { }

    /// <summary>
    /// Creates a new instance of the <see cref="FilterEntry"/>
    /// </summary>
    /// <param name="value">The value to search for</param>
    /// <param name="wildcard">The desired wildcard (optional)</param>
    public FilterEntry(string value, string wildcard = "*")
    {
        Value = value.Replace(wildcard, ""); // Remove the wild card
        FilterType = value.ToFilterType(wildcard);
        OriginalValue = value;
    }
}