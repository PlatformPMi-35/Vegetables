using System;

namespace Vegetables.Task_1.UI.IO
{
    /// <summary>
    ///     The class for console output.
    /// </summary>
    public static class Output
    {
        /// <summary>
        ///     Method for writing string line.
        /// </summary>
        /// <param name="color">Output color.</param>
        /// <param name="value">Output value.</param>
        public static void WriteLine(ConsoleColor color, string value)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        /// <summary>
        ///     Method for writing string line.
        /// </summary>
        /// <param name="str">Output string.</param>
        public static void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        ///     Method for displaying a prompt.
        /// </summary>
        /// <param name="format">Prompt format.</param>
        /// <param name="args">Output objects.</param>
        public static void DisplayPrompt(string format, params object[] args)
        {
            format = format.Trim() + " ";
            Console.Write(format, args);
        }

        /// <summary>
        ///     Method for displaying an error.
        /// </summary>
        /// <param name="message">Error message.</param>
        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n[ERROR]: {0}", message);
            Console.ResetColor();
        }

        /// <summary>
        ///     Method for displaying an info.
        /// </summary>
        /// <param name="message">Info message.</param>
        public static void DisplayInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n[INFO]: {0}", message);
            Console.ResetColor();
        }
    }
}