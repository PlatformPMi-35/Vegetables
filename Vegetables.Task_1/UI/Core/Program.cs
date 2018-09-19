using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Vegetables.Task_1.UI.Extensions;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Core
{
    /// <summary>
    ///     The main program class.
    /// </summary>
    public abstract class Program
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Program" /> class.
        /// </summary>
        /// <param name="title">The title of the program.</param>
        /// <param name="breadcrumbHeader">The pages history switcher.</param>
        protected Program(string title, bool breadcrumbHeader)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Title = title;
            Pages = new Dictionary<Type, Page>();
            History = new Stack<Page>();
            BreadcrumbHeader = breadcrumbHeader;
        }

        /// <summary>
        ///     Gets a value indicating whether pages history enabling.
        /// </summary>
        public bool BreadcrumbHeader { get; }

        /// <summary>
        ///     Gets the pages history.
        /// </summary>
        public Stack<Page> History { get; }

        /// <summary>
        ///     Navigation switcher.
        /// </summary>
        public bool NavigationEnabled => History.Count > 1;

        /// <summary>
        ///     Gets or sets the title of the program.
        /// </summary>
        protected string Title { get; set; }

        /// <summary>
        ///     Current page.
        /// </summary>
        protected Page CurrentPage => History.Any() ? History.Peek() : null;

        /// <summary>
        ///     Gets or sets all pages.
        /// </summary>
        private Dictionary<Type, Page> Pages { get; }

        /// <summary>
        ///     Method for running the program.
        /// </summary>
        public virtual void Run()
        {
            try
            {
                Console.Title = Title;

                CurrentPage.Display();
            }
            catch (Exception e)
            {
                Output.WriteLine(ConsoleColor.Red, e.ToString());
            }
            finally
            {
                if (Debugger.IsAttached) Input.ReadString("Press [Enter] to exit");
            }
        }

        /// <summary>
        ///     Method for clearing pages.
        /// </summary>
        public void Clear()
        {
            Pages.Clear();
            History.Clear();
        }

        /// <summary>
        ///     Method for adding new page.
        /// </summary>
        /// <param name="page">Adding page.</param>
        public void AddPage(Page page)
        {
            var pageType = page.GetType();

            if (Pages.ContainsKey(pageType))
                Pages[pageType] = page;
            else
                Pages.Add(pageType, page);
        }

        /// <summary>
        ///     Method for navigate home.
        /// </summary>
        public void NavigateHome()
        {
            while (History.Count > 1) History.Pop();

            Console.Clear();
            CurrentPage.Display();
        }

        /// <summary>
        ///     Method for set home page.
        /// </summary>
        /// <typeparam name="T">Home page type.</typeparam>
        /// <returns>Home page.</returns>
        public T SetPage<T>() where T : Page
        {
            var pageType = typeof(T);

            if (CurrentPage != null && CurrentPage.GetType() == pageType) return CurrentPage as T;

            // leave the current page

            // select the new page
            Page nextPage;
            if (!Pages.TryGetValue(pageType, out nextPage))
                throw new KeyNotFoundException(
                    "The given page \"{0}\" was not present in the program".Format(pageType));

            // enter the new page
            History.Push(nextPage);

            return CurrentPage as T;
        }

        /// <summary>
        ///     Method for navigate to page.
        /// </summary>
        /// <typeparam name="T">Navigation page type.</typeparam>
        /// <returns>Navigation page.</returns>
        public T NavigateTo<T>() where T : Page
        {
            SetPage<T>();

            Console.Clear();
            CurrentPage.Display();
            return CurrentPage as T;
        }

        /// <summary>
        ///     Method for navigate back to the page.
        /// </summary>
        /// <typeparam name="T">Navigation page type.</typeparam>
        /// <returns>Navigation page.</returns>
        public T NavigateBackTo<T>() where T : Page
        {
            while (typeof(T) != History.Peek().GetType()) History.Pop();

            Console.Clear();
            CurrentPage.Display();
            return CurrentPage as T;
        }

        /// <summary>
        ///     Method for navigate back.
        /// </summary>
        /// <returns>Navigation page.</returns>
        public Page NavigateBack()
        {
            History.Pop();

            Console.Clear();
            CurrentPage.Display();
            return CurrentPage;
        }
    }
}