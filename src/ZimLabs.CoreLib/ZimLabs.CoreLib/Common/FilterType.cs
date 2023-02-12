namespace ZimLabs.CoreLib.Common;

/// <summary>
/// The different filter types
/// </summary>
public enum FilterType
{
    /// <summary>
    /// The value has to contain
    /// </summary>
    Contains,

    /// <summary>
    /// The value has to be equals
    /// </summary>
    Equals,

    /// <summary>
    /// The value has to starts with
    /// </summary>
    StartsWith,

    /// <summary>
    /// The value has to ends with
    /// </summary>
    EndsWith
}