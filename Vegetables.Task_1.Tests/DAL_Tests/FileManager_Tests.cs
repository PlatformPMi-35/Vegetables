using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using NUnit.Framework;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Managers;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.Tests.DAL_Tests
{
    [TestFixture]
    public class FileManager_Tests
    {
        private FileManager _fileManager;
        private string _path;

        [SetUp]
        public void Setup()
        {
            _path = AppDomain.CurrentDomain.BaseDirectory + "\\Test.csv";
            _fileManager = new FileManager();
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
        }

        [Test]
        public void LoadWithNullPath_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => _fileManager.Load(null));
        }

        [Test]
        public void Load_Test()
        {
            //Arrange
            var streamWriter = new StreamWriter(_path);
            var circle = new Circle(new Point(0,0), 5);
            var triangle = new Triangle(new Point(0,0), new Point(2,2), new Point(4,0));
            var square = new Square(new Point(0,5), new Point(5,0));
            streamWriter.WriteLine($"{nameof(Circle)};{circle.Center.X};{circle.Center.Y};{circle.Radius}");
            streamWriter.WriteLine($"{nameof(Triangle)};{triangle.A.X};{triangle.A.Y};{triangle.B.X};{triangle.B.Y};{triangle.C.X};{triangle.C.Y}");
            streamWriter.WriteLine($"{nameof(Square)};{square.LeftTop.X};{square.LeftTop.Y};{square.RightBottom.X};{square.RightBottom.Y}");
            streamWriter.Close();
            streamWriter.Dispose();
            //Act
            var shapes = _fileManager.Load(_path).ToList();
            //Assert
            Assert.AreEqual(shapes.Count, 3);
            Assert.IsNotNull(shapes.Select(i => i).Where(i => i.GetType() == typeof(Circle)));
            Assert.IsNotNull(shapes.Select(i => i).Where(i => i.GetType() == typeof(Triangle)));
            Assert.IsNotNull(shapes.Select(i => i).Where(i => i.GetType() == typeof(Square)));
        }

        [Test]
        public void SaveWithNullPath_Test()
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => _fileManager.Save(null, null));
        }

        [Test]
        public void Save_Test()
        {
            //Arrange
            var shapes = new List<IShape>
            {
                new Circle(new Point(0, 0), 5),
                new Triangle(new Point(0, 0), new Point(2, 2), new Point(4, 0)),
                new Square(new Point(0, 5), new Point(5, 0))
            };
            var resultStrings = new string[3];
            //Act
            _fileManager.Save(_path, shapes);
            var streamReader = new StreamReader(_path);
            resultStrings[0] = streamReader.ReadLine();
            resultStrings[1] = streamReader.ReadLine();
            resultStrings[2] = streamReader.ReadLine();
            streamReader.Close();
            streamReader.Dispose();
            //Assert
            Assert.AreEqual(resultStrings[0], $"{nameof(Circle)};0;0;5");
            Assert.AreEqual(resultStrings[1], $"{nameof(Triangle)};0;0;2;2;4;0");
            Assert.AreEqual(resultStrings[2], $"{nameof(Square)};0;5;5;0");
        }
    }
}
