using System.Windows;
using Vegetables.Task_1.DAL.Interfaces;

namespace Vegetables.Task_1.DAL.Models
{
    /// <summary>
    /// Represents a square.
    /// </summary>
    public class Square : IShape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        public Square()
        {
            LeftTop = new Point();
            RightBottom = new Point();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="leftTop">Left top point of the square.</param>
        /// <param name="rightBottom">Right bottom point of the square.</param>
        public Square(Point leftTop, Point rightBottom)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
        }

        /// <summary>
        /// Gets or sets left top point of the square.
        /// </summary>
        public Point LeftTop { get; set; }

        /// <summary>
        /// Gets or sets right bottom point of the square.
        /// </summary>
        public Point RightBottom { get; set; }

        /// <summary>
        /// Calculates perimeter of the square.
        /// </summary>
        /// <returns>Perimeter of the circle.</returns>
        public double Perimeter()
        {
            return (2 * (LeftTop.Y - RightBottom.Y)) + (2 * (RightBottom.X - LeftTop.X));
        }

        /// <summary>
        /// Calculates area of the circle.
        /// </summary>
        /// <returns>Square of the circle.</returns>
        public double Area()
        {
            return (LeftTop.Y - RightBottom.Y) * (RightBottom.X - LeftTop.X);
        }
    }
}
