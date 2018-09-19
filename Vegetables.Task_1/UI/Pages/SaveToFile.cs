using System;
using System.IO;
using Vegetables.Task_1.DAL;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Managers;
using Vegetables.Task_1.UI.Core;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Pages
{
    /// <summary>
    ///  Page that saves shapes to the file.
    /// </summary>
    public class SaveToFile : Page
    {
        private readonly IFileManager _fileManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaveToFile"/> class.
        /// </summary>
        /// <param name="program">The main program class.</param>
        public SaveToFile(Program program) : base("Save",program)
        {
            _fileManager = new FileManager();
        }

        /// <summary>
        /// Displays page.
        /// </summary>
        public override void Display()
        {
            base.Display();
            string filePath = Input.ReadString(" Enter file path : ");
            try
            {
                _fileManager.Save(filePath, Data.Shapes);
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

            Output.WriteLine("Press any key...");
            Input.AnyKey();
            Program.NavigateBack();
        }
    }
}
