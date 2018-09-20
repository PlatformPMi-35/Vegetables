using System;
using System.IO;
using System.Linq;
using Vegetables.Task_1.BLL;
using Vegetables.Task_1.BLL.Enums;
using Vegetables.Task_1.DAL;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Managers;
using Vegetables.Task_1.UI.Core;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Pages
{
    /// <summary>
    /// Page that write to file and to console shapes, which are found.
    /// </summary>
    public class FindShapes : Page
    {
        private readonly ShapeFinder _shapeFinder;

        private readonly IFileManager _fileManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="FindShapes"/> class.
        /// </summary>
        /// <param name="program">Main program.</param>
        public FindShapes(Program program) : base("Find shapes", program)
        {
            _shapeFinder = new ShapeFinder();
            _fileManager = new FileManager();
        }

        /// <summary>
        /// Displays the page.
        /// </summary>
        public override void Display()
        {
            base.Display();
            try
            {
                if (Data.Shapes == null || Data.Shapes.Count == 0)
                {
                    Output.DisplayInfo("Collection is empty!");
                }
                else
                {
                    var choice = Input.ReadEnum<Quarter>("Enter the Quarter");
                    var collection = ShapeSorter
                        .SortByDescending(_shapeFinder.Find(Data.Shapes, choice), SortShapesBy.Perimeter).ToList();
                    var path = Input.ReadString("Enter file path: ");
                    _fileManager.Save(path, collection);
                    ShapePrinter.Print(collection);
                }
            }
            catch (ArgumentException e)
            {
                Output.DisplayError(e.Message + e.ParamName);
            }
            catch (FileNotFoundException e)
            {
                Output.DisplayError(e.Message);
            }
            catch (IOException e)
            {
                Output.DisplayError(e.Message);
            }
            catch (Exception e)
            {
                Output.DisplayError(e.Message);
            }

            Output.DisplayInfo("Press any key to navigate home");
            Input.AnyKey();
            Program.NavigateBack();
        }
    }
}
