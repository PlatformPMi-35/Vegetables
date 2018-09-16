using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Vegetables.Task_1.BLL.Enums;
using Vegetables.Task_1.BLL.Interfaces;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.BLL
{
    /// <summary>
    /// Find shapes in collections
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
            switch (shape)
            {
                case Circle circle:
                {
                    var leftPoint = GetQuarter(new Point(circle.Center.X - circle.Radius, circle.Center.Y));
                    var rightPoint = GetQuarter(new Point(circle.Center.X + circle.Radius, circle.Center.Y));
                    var topPoint = GetQuarter(new Point(circle.Center.X, circle.Center.Y + circle.Radius));
                    var bottomPoint = GetQuarter(new Point(circle.Center.X, circle.Center.Y - circle.Radius));
                    return (leftPoint == quarter || leftPoint == Quarter.None) &&
                           (rightPoint == quarter || rightPoint == Quarter.None) &&
                           (topPoint == quarter || topPoint == Quarter.None) &&
                           (bottomPoint == quarter || bottomPoint == Quarter.None) &&
                           (GetQuarter(circle.Center) != Quarter.None);
                }

                case Triangle triangle:
                {
                    var a = GetQuarter(triangle.A);
                    var b = GetQuarter(triangle.B);
                    var c = GetQuarter(triangle.C);
                    if (a == Quarter.None && b == Quarter.None && c == Quarter.None)
                    {
                        return false;
                    }

                    return (a == quarter || a == Quarter.None) &&
                           (b == quarter || b == Quarter.None) &&
                           (c == quarter || c == Quarter.None);
                }

                case Square square:
                {
                    var a = GetQuarter(square.LeftTop);
                    var b = GetQuarter(square.RightTop);
                    var c = GetQuarter(square.RightBottom);
                    var d = GetQuarter(square.LeftBottom);
                    return (a == quarter || a == Quarter.None) &&
                           (b == quarter || b == Quarter.None) &&
                           (c == quarter || c == Quarter.None) &&
                           (d == quarter || d == Quarter.None);
                }

                default:
                    throw new ArgumentException(nameof(shape));
            }
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
