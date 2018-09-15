using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.DAL.Managers
{
    /// <summary>
    /// Represents a file manager
    /// </summary>
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Loads all shapes from  the file.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <returns>Collection of shapes.</returns>
        public IEnumerable<IShape> Load(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            var shapes = new List<IShape>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string[] values = reader.ReadLine()?.Split(';');
                    shapes.Add(CreateShape(values));
                }
            }

            return shapes;
        }

        /// <summary>
        /// Saves all shapes to the file.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <param name="shapes">Collection of shapes.</param>
        /// <returns>True - if shapes successfully saved in the file, otherwise - false.</returns>
        public bool Save(string filePath, IEnumerable<IShape> shapes)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var shape in shapes)
                {
                    WriteShape(writer, shape);
                }
            }

            return true;
        }

        /// <summary>
        /// Creates new shape.
        /// </summary>
        /// <param name="values">Collection values of the shape.</param>
        /// <returns>A new shape.</returns>
        private IShape CreateShape(string[] values)
        {
            IShape result = null;
            switch (values[0])
            {
                case "Triangle":
                    result = new Triangle
                    {
                        A = new Point(double.Parse(values[1]), double.Parse(values[2])),
                        B = new Point(double.Parse(values[3]), double.Parse(values[4])),
                        C = new Point(double.Parse(values[5]), double.Parse(values[6]))
                    };
                    break;
                case "Circle":
                    result = new Circle
                    {
                        Center = new Point(double.Parse(values[1]), double.Parse(values[2])),
                        Radius = double.Parse(values[3])
                    };
                    break;
                case "Square":
                    result = new Square
                    {
                        LeftTop = new Point(double.Parse(values[1]), double.Parse(values[2])),
                        RightBottom = new Point(double.Parse(values[3]), double.Parse(values[4]))
                    };
                    break;
            }
            return result;
        }

        /// <summary>
        /// Writes shape to the file. 
        /// </summary>
        /// <param name="writer">Stream writer.</param>
        /// <param name="shape">A shape.</param>
        private void WriteShape(StreamWriter writer, IShape shape)
        {
            if (shape is Circle circle)
            {
                writer.WriteLine($"{nameof(Circle)};{circle.Center.X};{circle.Center.Y};{circle.Radius}");
            }

            if (shape is Triangle triangle)
            {
                writer.WriteLine($"{nameof(Triangle)};{triangle.A.X};{triangle.A.Y};{triangle.B.X};{triangle.B.Y};{triangle.C.X};{triangle.C.Y}");
            }

            if (shape is Square square)
            {
                writer.WriteLine($"{nameof(Square)};{square.LeftTop.X};{square.LeftTop.Y};{square.RightBottom.X};{square.RightBottom.Y}");
            }
        }
    }
}
