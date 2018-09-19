using Vegetables.Task_1.DAL;
using Vegetables.Task_1.UI.Core;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Pages
{
    /// <summary>
    /// Page that shows all shape.
    /// </summary>
    public class AllShapes : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllShapes"/> class.
        /// </summary>
        /// <param name="program">Main program.</param>
        public AllShapes(Program program) : base("All shapes", program)
        {        
        }

        /// <summary>
        /// Displays the page.
        /// </summary>
        public override void Display()
        {
            base.Display();
            if (Data.Shapes == null || Data.Shapes.Count == 0)
            {
               Output.DisplayInfo("Collection is empty!");
            }
            else
            {
               ShapePrinter.Print(Data.Shapes); 
            }

            Output.DisplayInfo("Press any key to navigate home");
            Input.AnyKey();
            Program.NavigateHome();
        }
    }
}
