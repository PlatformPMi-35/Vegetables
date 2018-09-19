using System;
using Vegetables.Task_1.UI.Core;

namespace Vegetables.Task_1.UI.IO
{
    /// <summary>
    ///     The class for console input.
    /// </summary>
    public static class Input
    {
        /// <summary>
        ///     Method for reading an integer.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>An integer.</returns>
        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        /// <summary>
        ///     Method for reading an integer.
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>An integer.</returns>
        public static int ReadInt(int min, int max)
        {
            var value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive):", min, max);
                value = ReadInt();
            }

            return value;
        }

        /// <summary>
        ///     Method for reading an integer.
        /// </summary>
        /// <returns>An integer.</returns>
        public static int ReadInt()
        {
            var input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer:");
                input = Console.ReadLine();
            }

            return value;
        }

        /// <summary>
        ///     Method for reading a string.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>A string.</returns>
        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        ///     Method for reading <see cref="Enum" /> value.
        /// </summary>
        /// <typeparam name="TEnum">Enum type.</typeparam>
        /// <param name="prompt">The prompt.</param>
        /// <returns>Enum value.</returns>
        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var type = typeof(TEnum);

            if (!type.IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            var menu = new Menu();
            var choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum) value; });
            menu.Display();
            return choice;
        }

        /// <summary>
        ///     Method for reading Console Key.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>A key.</returns>
        public static ConsoleKey ReadKey(string prompt)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Output.DisplayPrompt(prompt);
            Console.ResetColor();
            return Console.ReadKey().Key;
        }

        /// <summary>
        ///     Method for wait when pressing any key.
        /// </summary>
        public static void AnyKey()
        {
            Console.ReadKey();
        }
    }
}