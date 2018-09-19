using System;

namespace Vegetables.Task_1.UI.Core.Context
{
    /// <summary>
    ///     The option class.
    /// </summary>
    public class Option
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Option" /> class.
        /// </summary>
        /// <param name="name">Option name.</param>
        /// <param name="callback">Option callback function.</param>
        public Option(string name, Action callback)
        {
            Name = name;
            Callback = callback;
        }

        /// <summary>
        ///     Gets the option name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets the option callback function.
        /// </summary>
        public Action Callback { get; }

        /// <summary>
        ///     Method for string presentations.
        /// </summary>
        /// <returns>A string.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}