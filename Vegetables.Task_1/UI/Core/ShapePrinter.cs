using System.Collections.Generic;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.UI.Extensions;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Core
{
    public static class ShapePrinter
    {
        public static void Print(IEnumerable<IShape> shapes)
        {
            foreach (var shape in shapes)
            {
                shape.Print();
                Output.WriteLine("\n");
            }
        }
    }
}
