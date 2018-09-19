using System;
using Vegetables.Task_1.UI.Core;
using Vegetables.Task_1.UI.Core.Context;

namespace Vegetables.Task_1.UI.Pages
{
    /// <summary>
    /// Main menu page.
    /// </summary>
    public class MainMenu : MenuPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        /// <param name="program"></param>
        public MainMenu(Program program) : base(
            "Main menu",
            program,
            new Option("Show all shapes", () => program.NavigateTo<AllShapes>()),
            new Option("Load from file", () => program.NavigateTo<LoadFromFile>()),
            new Option("Save to file", () => program.NavigateTo<SaveToFile>()),
            new Option("Sort", () => program.NavigateTo<Sort>()),
            new Option("Find shapes in the third quarter", () => program.NavigateTo<FindShapes>()),
            new Option("Exit", () => Environment.Exit(0)))
        {
        }
    }
}