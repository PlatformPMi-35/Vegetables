using System;
using System.Linq;
using System.Text;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Core
{
    /// <summary>
    ///     The main page class.
    /// </summary>
    public abstract class Page
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Page" /> class.
        /// </summary>
        /// <param name="title">The title of the page.</param>
        /// <param name="program">The main program class.</param>
        protected Page(string title, Program program)
        {
            Title = title;
            Program = program;
        }

        /// <summary>
        ///     Gets the title of the page.
        /// </summary>
        public string Title { get; }

        /// <summary>
        ///     Gets or sets the main program class.
        /// </summary>
        public Program Program { get; set; }

        /// <summary>
        ///     Method for displaying the page.
        /// </summary>
        public virtual void Display()
        {
            Console.Clear();
            Output.WriteLine("_______________________________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (Program.History.Count > 1 && Program.BreadcrumbHeader)
            {
                var breadcrumb = new StringBuilder();
                foreach (var title in Program.History.Select(page => page.Title).Reverse())
                    breadcrumb.Append(title + " > ");

                if (breadcrumb.Length != 0)
                {
                    breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3, 3);
                    Console.WriteLine(breadcrumb.ToString());
                }
            }
            else
            {
                Console.WriteLine(Title);
            }
            Console.ResetColor();
            Output.WriteLine("_______________________________________________________________________________________________________________________\n");
        }
    }
}