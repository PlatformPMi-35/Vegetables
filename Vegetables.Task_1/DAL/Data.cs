using System.Collections.Generic;
using Vegetables.Task_1.DAL.Interfaces;

namespace Vegetables.Task_1.DAL
{
    /// <summary>
    /// Contains the collection of shapes.
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// Initializes a static member of the <see cref="Data"/> class.
        /// </summary>
        static Data()
        {
            Shapes = new List<IShape>();
        }

        /// <summary>
        /// Gets or sets collection of shapes.
        /// </summary>
        public static ICollection<IShape> Shapes { get; set; }
    }
}