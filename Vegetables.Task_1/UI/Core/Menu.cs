using System;
using System.Collections.Generic;
using System.Linq;
using Vegetables.Task_1.UI.Core.Context;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Core
{
    /// <summary>
    ///     The menu page class with options.
    /// </summary>
    public class Menu
    {
        /// <summary>
        ///     The options.
        /// </summary>
        private readonly IList<Option> _options;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Menu" /> class.
        /// </summary>
        public Menu()
        {
            _options = new List<Option>();
        }

        /// <summary>
        ///     Method for displaying page.
        /// </summary>
        public void Display()
        {
            for (var i = 0; i < _options.Count; i++) Console.WriteLine("{0}. {1}", i + 1, _options[i].Name);

            var choice = Input.ReadInt("Choose an option:", 1, _options.Count);
            _options[choice - 1].Callback();
        }

        /// <summary>
        ///     Method for adding new option.
        /// </summary>
        /// <param name="option">An option.</param>
        /// <param name="callback">Callback action.</param>
        /// <returns>Menu page.</returns>
        public Menu Add(string option, Action callback)
        {
            return Add(new Option(option, callback));
        }

        /// <summary>
        ///     Method for adding new option.
        /// </summary>
        /// <param name="option">An option.</param>
        /// <returns>Menu page.</returns>
        public Menu Add(Option option)
        {
            _options.Add(option);
            return this;
        }

        /// <summary>
        ///     Method for check containing option.
        /// </summary>
        /// <param name="option">Name of option.</param>
        /// <returns>True - if contains, false - if not.</returns>
        public bool Contains(string option)
        {
            return _options.FirstOrDefault(op => op.Name.Equals(option)) != null;
        }
    }
}