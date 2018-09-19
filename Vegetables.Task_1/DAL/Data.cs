using System.Collections.Generic;
using Vegetables.Task_1.DAL.Interfaces;

namespace Vegetables.Task_1.DAL
{
    public static class Data
    {
        static Data()
        {
            Shapes = new List<IShape>();
        }

        public static ICollection<IShape> Shapes { get; set; }
    }
}