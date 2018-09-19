using System;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Models;
using Vegetables.Task_1.UI.IO;

namespace Vegetables.Task_1.UI.Extensions
{
    /// <summary>
    ///  Extensions for <see cref="IShape" /> interface.
    /// </summary>
    public static class ShapeExtensions
    {
        /// <summary>
        /// Find extension.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public static void Print(this IShape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    Output.WriteLine($"{nameof(Circle)}\nCenter: {circle.Center}\nRadius: {circle.Radius}");
                    break;
                case Triangle triangle:
                    Output.WriteLine($"{nameof(Triangle)}\nA: {triangle.A}\nB: {triangle.B}\nC: {triangle.C}");
                    break;
                case Square square:
                    Output.WriteLine($"{nameof(Square)}\nLeft Top: {square.LeftTop}\nRight Bottom: {square.RightBottom}");
                    break;
                default:
                    throw new ArgumentException(nameof(shape));
            }
        }
    }
}
