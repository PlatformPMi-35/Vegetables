using System;
using Vegetables.Task_1.BLL;
using Vegetables.Task_1.BLL.Enums;
using Vegetables.Task_1.DAL;
using Vegetables.Task_1.UI.Core;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Pages
{
    /// <summary>
    /// Page that sorts shapes.
    /// </summary>
    public class Sort : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort"/> class.
        /// </summary>
        /// <param name="program">Main program.</param>
        public Sort(Program program) : base("Sort", program)
        {
        }

        /// <summary>
        /// Displaying the page.
        /// </summary>
        public override void Display()
        {
            base.Display();
            if (Data.Shapes == null || Data.Shapes.Count == 0)
            {
                Output.DisplayInfo("Collection is empty\n\nPress any key to navigate home");
                Input.AnyKey();
                Program.NavigateHome();
            }

            var choiceMethod = Input.ReadEnum<SortShapesBy>("Choose the sort method");
            switch (choiceMethod)
            {
                case SortShapesBy.Area:
                    ShapeSorter.SortByAscending(Data.Shapes, choiceMethod);
                    break;
                case SortShapesBy.Perimeter:
                    ShapeSorter.SortByAscending(Data.Shapes, choiceMethod);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            ShapePrinter.Print(Data.Shapes);
            Output.DisplayInfo("Press any key to navigate home");
            Input.AnyKey();
        }
    }
}
