using System;
using System.Collections.Generic;
using System.Windows;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Models;
using Vegetables.Task_1.UI.Core;

namespace Vegetables.Task_1
{
    /// <summary>
    /// The main program class
    /// </summary>
    internal static class Runner
    {
        /// <summary>
        /// The main method
        /// </summary>
        private static void Main()
        {
            List<IShape> l = new List<IShape>()
            {
                new Circle(new Point(0, 0), 23),
                new Square(new Point(2, 3), new Point(4, 5)),
                new Triangle(new Point(2, 5), new Point(2, 6), new Point(3, 6))
            };
            ShapePrinter.Print(l);
            Console.ReadKey();
        }
    }
}
