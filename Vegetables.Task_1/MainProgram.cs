using Vegetables.Task_1.UI.Core;
using Vegetables.Task_1.UI.Pages;

namespace Vegetables.Task_1
{
    /// <summary>
    /// The main program.
    /// </summary>
    public class MainProgram : Program
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainProgram"/> class.
        /// </summary>
        public MainProgram() : base("Shapes", true)
        {
            AddPage(new MainMenu(this));
            AddPage(new Sort(this));
            SetPage<MainMenu>();
        }
    }
}