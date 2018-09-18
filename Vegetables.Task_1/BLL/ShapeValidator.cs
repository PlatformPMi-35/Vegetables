using System;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.BLL
{
    /// <summary>
    /// Validate IShape
    /// </summary>
    public static class ShapeValidator
    {
        /// <summary>
        /// Validate shapes
        /// </summary>
        /// <param name="shape">The shape</param>
        /// <returns>Interface of shape</returns>
        public static IShape Validate(IShape shape)
        {
            switch (shape)
            {
                case Circle circle when circle.Radius <= 0:
                    throw new ArgumentException();
                case Square square when Math.Abs(square.LeftTop.X - square.RightBottom.X) < 0.0001 && 
                                        Math.Abs(square.LeftTop.Y - square.RightBottom.Y) < 0.0001:
                    throw new ArgumentException();
                case Triangle triangle when triangle.Area() <= 0:
                    throw new ArgumentException();
            }

            return shape;
        }
    }
}
