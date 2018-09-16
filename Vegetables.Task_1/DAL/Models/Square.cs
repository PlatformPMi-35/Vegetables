using System;
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
        /// Gets right top point of the square.
        /// </summary>
        public Point RightTop
        {
            get
            {
                var middle = MiddlePoint();
                return new Point(middle.X + Math.Abs(middle.Y - LeftTop.Y), middle.Y + Math.Abs(middle.X - LeftTop.X));
            }
        }

        /// <summary>
        /// Gets left bottom point of the square.
        /// </summary>
        public Point LeftBottom
        {
            get
            {
                var middle = MiddlePoint();
                return new Point(middle.X - Math.Abs(middle.Y - LeftTop.Y), middle.Y - Math.Abs(middle.X - LeftTop.X));
            }
        }

        /// <summary>
        /// Calculates perimeter of the square.
        /// </summary>
        /// <returns>Perimeter of the square.</returns>
        public double Perimeter()
        {
            return 4 * Side();
        }

        /// <summary>
        /// Calculates area of the square.
        /// </summary>
        /// <returns>Square of the square.</returns>
        public double Area()
        {
            return Side() * Side();
        }

        /// <summary>
        /// Calculates side of the square
        /// </summary>
        /// <returns>Side of the square</returns>
        private double Side()
        {
            return Diagonal() / Math.Sqrt(2);
        }

        /// <summary>
        /// Calculates diagonal of the square
        /// </summary>
        /// <returns>Diagonal of the square</returns>
        private double Diagonal()
        {
            return Math.Sqrt((RightBottom.X - LeftTop.X) * (RightBottom.X - LeftTop.X) +
                             (LeftTop.Y - RightBottom.Y) * (LeftTop.Y - RightBottom.Y));
        }

        /// <summary>
        /// Calculates middle point of the square
        /// </summary>
        /// <returns>Middle point of the square</returns>
        private Point MiddlePoint()
        {
            double x;
            double y;
            if (Math.Abs(RightBottom.Y - LeftTop.Y) < 0.0001)
            {
                y = RightBottom.Y;
                x = (RightBottom.X + LeftTop.X) / 2;
            }
            else if (Math.Abs(RightBottom.X - LeftTop.X) < 0.0001)
            {
                x = RightBottom.X;
                y = (RightBottom.Y + LeftTop.Y) / 2;
            }
            else
            {
                x = (RightBottom.X + LeftTop.X) / 2;
                y = (RightBottom.Y + LeftTop.Y) / 2;
            }

            return new Point(x, y);
        }
    }
}
