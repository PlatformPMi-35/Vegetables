using System.Windows;

namespace Vegetables.Task_1.DAL.Interfaces
{
    /// <summary>
    /// Represents basics methods for shapes.
    /// </summary>
   public interface IShape
    {
        /// <summary>
        /// Gets middle point in shape
        /// </summary>
        Point MiddlePoint { get; }

        /// <summary>
        /// Calculates area square.
        /// </summary>
        /// <returns>Square of the shape</returns>
        double Area();

        /// <summary>
        /// Calculate shape perimeter.
        /// </summary>
        /// <returns>Perimeter of the shape.</returns>
        double Perimeter();
    }
}
