using System.Reflection;

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
}