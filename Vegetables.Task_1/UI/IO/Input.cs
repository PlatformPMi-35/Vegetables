using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        /// <param name="prompt">The prompt.</param>
        /// <returns>An integer.</returns>
        public static int ReadInt(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt();
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
        ///     Method for reading not empty string.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>A string.</returns>
        public static string ReadNotEmptyString(string prompt)
        {
            var value = ReadString(prompt);
            while (string.IsNullOrWhiteSpace(value)) value = ReadString(prompt);

            return value;
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
        ///     Method for reading Console Key.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <param name="args">Console keys.</param>
        /// <returns>A console key.</returns>
        public static ConsoleKey ReadKey(string prompt, params ConsoleKey[] args)
        {
            var key = ReadKey(prompt);
            while (!args.Contains(key)) key = ReadKey(prompt);

            return key;
        }

        /// <summary>
        ///     Method for reading a Date Time.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>A date time.</returns>
        public static DateTime ReadDateTime(string prompt)
        {
            Output.DisplayPrompt(prompt);
            var input = Console.ReadLine();
            DateTime value;

            while (!DateTime.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter a date time:");
                input = Console.ReadLine();
            }

            return value;
        }

        /// <summary>
        ///     Method for reading a decimal.
        /// </summary>
        /// <param name="prompt">The prompt.</param>
        /// <returns>A decimal.</returns>
        public static decimal ReadDecimal(string prompt)
        {
            Output.DisplayPrompt(prompt);
            var input = Console.ReadLine();
            decimal value;

            while (!decimal.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter a decimal:");
                input = Console.ReadLine();
            }

            return value;
        }

        /// <summary>
        ///     Method for reading E-mail.
        /// </summary>
        /// <param name="prompt">A prompt.</param>
        /// <returns>A string.</returns>
        public static string ReadEmail(string prompt)
        {
            var email = ReadString(prompt);
            var pattern =
                @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            while (!Regex.IsMatch(email, pattern)) email = ReadString(prompt);

            return email;
        }

        /// <summary>
        ///     Method for reading password.
        /// </summary>
        /// <param name="prompt">A prompt.</param>
        /// <returns>A string.</returns>
        public static string ReadPassword(string prompt)
        {
            Output.DisplayPrompt(prompt);
            var str = new StringBuilder();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (str.Length != 0)
                    {
                        str = str.Remove(str.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    str.Append(key.KeyChar);
                    Console.Write("*");
                }
            } while (true);

            Console.WriteLine();
            return str.ToString();
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