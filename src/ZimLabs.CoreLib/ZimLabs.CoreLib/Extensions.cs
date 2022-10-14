namespace ZimLabs.CoreLib;

/// <summary>
/// Provides several extensions
/// </summary>
public static class Extensions
{
    #region string
    /// <summary>
    /// Checks if the string value contains the given substring
    /// </summary>
    /// <param name="value">The string value</param>
    /// <param name="substring">The sub string which should be found</param>
    /// <returns>true when the string value contains the substring, otherwise false</returns>
    public static bool ContainsIgnoreCase(this string value, string substring)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(substring))
            return false;

        return value.Contains(substring, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Check two strings for equality and ignores the casing
    /// </summary>
    /// <param name="value">The value which should be checked</param>
    /// <param name="match">The comparative value</param>
    /// <returns>true when the strings are equal, otherwise false</returns>
    public static bool EqualsIgnoreCase(this string value, string match)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(match))
            return false;

        return string.Equals(value, match, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Tries to convert the <see cref="string"/> value into an <see cref="int"/>
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="fallback">The fallback (optional)</param>
    /// <returns>The converted value</returns>
    public static int ToInt(this string value, int fallback = 0)
    {
        return int.TryParse(value, out var result) ? result : fallback;
    }
    #endregion

    #region Numbers
    /// <summary>
    /// Converts the size of the file into a readable format (bytes, KB, MB, GB)
    /// </summary>
    /// <param name="fileInfo">The file</param>
    /// <param name="divider">The divider. If the value is 0, it will be automatically set to 1024 (optional)</param>
    /// <param name="addBytes"><see langword="true"/> to add the bytes to the end, otherwise <see langword="false"/></param>
    /// <returns>The converted size</returns>
    public static string ConvertToFileSize(this FileInfo fileInfo, int divider = 1024, bool addBytes = false)
    {
        if (divider == 0)
            divider = 1024;

        var result = fileInfo.Length switch
        {
            var size when size < divider => $"{size:N0} Bytes",
            var size when size >= divider && size < Math.Pow(divider, 2) => $"{size / divider:N2} KB",
            var size when size >= Math.Pow(divider, 2) && size < Math.Pow(divider, 3) =>
                $"{size / Math.Pow(divider, 2):N2} MB",
            var size when size >= Math.Pow(divider, 3) && size <= Math.Pow(divider, 4) => $"{size / Math.Pow(divider, 3):N2} GB",
            var size when size >= Math.Pow(divider, 4) => $"{size / Math.Pow(divider, 4)} TB",
            _ => fileInfo.Length.ToString()
        };

        return addBytes ? $"{result} ({fileInfo.Length:N0} Bytes)" : result;
    }
    #endregion

    #region Objects
    /// <summary>
    /// Gets the attribute of the enum
    /// </summary>
    /// <typeparam name="T">The type of the attribute</typeparam>
    /// <param name="value">The enum value</param>
    /// <returns>The attribute</returns>
    public static T? GetAttribute<T>(this Enum value) where T : Attribute
    {
        var memberInfo = value.GetType().GetMember(value.ToString());

        if (memberInfo.Length == 0)
            return null;

        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);

        foreach (var attribute in attributes)
        {
            if (attribute is T result)
                return result;
        }

        return null;
    }

    /// <summary>
    /// Gets the attribute of the desired object
    /// </summary>
    /// <typeparam name="T">The type of the attribute</typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static T? GetAttribute<T>(this object value) where T : Attribute
    {
        var attribute = Attribute.GetCustomAttribute(value.GetType(), typeof(T));

        if (attribute is T result)
            return result;

        return null;
    }
    #endregion

    #region DateTime
    /// <summary>
    /// Sets the time of the date / time value to the first possible value (00:00:00)
    /// </summary>
    /// <param name="value">The date / time value</param>
    /// <returns>The date / time with the new time</returns>
    public static DateTime SetStartOfDay(this DateTime value)
    {
        return value.SetTime(0, 0, 0);
    }

    /// <summary>
    /// Sets the time of the date / time value to the last possible value (23:59:59)
    /// </summary>
    /// <param name="value">The date / time value</param>
    /// <returns>The date / time value with the new time</returns>
    public static DateTime SetEndOfDay(this DateTime value)
    {
        return value.SetTime(23, 59, 59);
    }

    /// <summary>
    /// Sets the time of the date / time
    /// </summary>
    /// <param name="value">The date / time value</param>
    /// <param name="hour">The hour (0 through 23)</param>
    /// <param name="minute">The minutes (0 through 59)</param>
    /// <param name="second">The seconds (0 through 59)</param>
    /// <returns>The date / time with the new time</returns>
    public static DateTime SetTime(this DateTime value, int hour, int minute, int second)
    {
        if (hour is < 0 or > 23)
            hour = 0;

        if (minute is < 0 or > 59)
            minute = 0;

        if (second is < 0 or > 59)
            second = 0;

        return new DateTime(value.Year, value.Month, value.Day, hour, minute, second);
    }
    #endregion
}