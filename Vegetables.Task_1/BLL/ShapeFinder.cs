using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Vegetables.Task_1.BLL.Enums;
using Vegetables.Task_1.BLL.Interfaces;
using Vegetables.Task_1.DAL.Interfaces;

namespace Vegetables.Task_1.BLL
{
    /// <summary>
    /// Find shapes in collections.
    /// </summary>
    public class ShapeFinder : IFinder<IShape>
    {
        /// <summary>
        /// Finds shapes which are on quarter. 
        /// </summary>
        /// <param name="shapes">Collection of shapes</param>
        /// <param name="quarter">The quarter</param>
        /// <returns>Collection of shapes.</returns>
        public IEnumerable<IShape> Find(IEnumerable<IShape> shapes, Quarter quarter)
        {
            return shapes.Where(item => IsOnQuarter(item, quarter)).ToList();
        }

        /// <summary>
        /// Is shape in quarter
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <param name="quarter">The quarter</param>
        /// <returns>True - if shape is on quarter, false - if shape is not on quarter </returns>
        private bool IsOnQuarter(IShape shape, Quarter quarter)
        {
            return GetQuarter(shape.MiddlePoint) == quarter;
        }

        /// <summary>
        /// Find quarter, which has point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The quarter</returns>
        private Quarter GetQuarter(Point point)
        {
            if (point.X > 0 && point.Y > 0)
            {
                return Quarter.First;
            }

            if (point.X < 0 && point.Y > 0)
            {
                return Quarter.Second;
            }

            if (point.X < 0 && point.Y < 0)
            {
                return Quarter.Third;
            }

            if (point.X > 0 && point.Y < 0)
            {
                return Quarter.Fourth;
            }

            return Quarter.None;
        }
    }
}