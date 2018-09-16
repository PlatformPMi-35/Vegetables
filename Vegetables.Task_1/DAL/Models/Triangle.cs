using System;
using System.Windows;
using Vegetables.Task_1.DAL.Interfaces;

namespace Vegetables.Task_1.DAL.Models
{
    /// <summary>
    /// Represents a triangle.
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        public Triangle()
        {
            A = new Point();
            B = new Point();
            C = new Point();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="a">Point A.</param>
        /// <param name="b">Point B.</param>
        /// <param name="c">Point C.</param>
        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Gets or sets vertex of the triangle.
        /// </summary>
        public Point A { get; set; }

        /// <summary>
        /// Gets or sets vertex of the triangle.
        /// </summary>
        public Point B { get; set; }

        /// <summary>
        /// Gets or sets vertex of the triangle.
        /// </summary>
        public Point C { get; set; }

        /// <summary>
        /// Calculates area of the triangle.
        /// </summary>
        /// <returns>Square of the circle.</returns>
        public double Area()
        {
            return (((A.X * B.Y) + (B.X * C.Y) + (C.X * A.Y)) - ((A.Y * B.X) + (B.Y * C.X) + (C.Y * A.X))) * 0.5;
        }

        /// <summary>
        /// Calculates perimeter of the triangle.
        /// </summary>
        /// <returns>Perimeter of the circle.</returns>
        public double Perimeter()
        {
            var ab = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
            var bc = Math.Sqrt(Math.Pow(C.X - B.X, 2) + Math.Pow(C.Y - B.Y, 2));
            var ca = Math.Sqrt(Math.Pow(A.X - C.X, 2) + Math.Pow(A.Y - C.Y, 2));
            return ab + bc + ca;
        }
    }
}
