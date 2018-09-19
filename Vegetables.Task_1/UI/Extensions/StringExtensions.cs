namespace Vegetables.Task_1.UI.Extensions
{
    /// <summary>
    ///     Extensions for <see cref="string" /> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Format extension.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>A string.</returns>
        public static string Format(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}