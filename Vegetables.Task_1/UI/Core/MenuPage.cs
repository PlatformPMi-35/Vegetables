using Vegetables.Task_1.UI.Core.Context;

namespace Vegetables.Task_1.UI.Core
{
    /// <summary>
    ///     The base implementation of <see cref="Page" /> class.
    /// </summary>
    public class MenuPage : Page
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MenuPage" /> class.
        /// </summary>
        /// <param name="title">The title of the page.</param>
        /// <param name="program">The program class.</param>
        /// <param name="options">The options.</param>
        public MenuPage(string title, Program program, params Option[] options)
            : base(title, program)
        {
            Menu = new Menu();

            foreach (var option in options) Menu.Add(option);
        }

        /// <summary>
        ///     Gets or sets the menu.
        /// </summary>
        protected Menu Menu { get; set; }

        /// <summary>
        ///     Method for displaying the page.
        /// </summary>
        public override void Display()
        {
            base.Display();
            Menu.Display();
        }
    }
}