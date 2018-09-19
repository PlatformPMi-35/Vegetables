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
            AddPage(new AllShapes(this));
            AddPage(new FindShapes(this));
            AddPage(new LoadFromFile(this));
            AddPage(new SaveToFile(this));
            SetPage<MainMenu>();
        }
    }
}