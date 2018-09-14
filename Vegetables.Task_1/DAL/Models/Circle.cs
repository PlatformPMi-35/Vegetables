using System;
using System.Windows;
using Vegetables.Task_1.DAL.Interfaces;

namespace Vegetables.Task_1.DAL.Models
{
    /// <summary>
    /// Represents a circle.
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        public Circle()
        {
            Center = new Point();
            Radius = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="center">Center of the circle.</param>
        /// <param name="radius">Radius of the circle</param>
        public Circle(Point center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// Gets or sets radius of the circle.
        /// </summary>
        public Point Center { get; set; }

        /// <summary>
        /// Gets or sets radius of the circle.
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Calculates perimeter of the circle.
        /// </summary>
        /// <returns>Perimeter of the circle.</returns>
        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Calculates area of the circle.
        /// </summary>
        /// <returns>Square of the circle.</returns>
        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
