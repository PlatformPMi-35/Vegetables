using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Vegetables.Task_1.BLL;
using Vegetables.Task_1.BLL.Enums;
using Vegetables.Task_1.DAL.Interfaces;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.Tests.BLL_Tests
{
    [TestFixture]
    public class ShapeFinder_Tests
    {
        [Test]
        public void Find_Test()
        {
            //Arrange
            var shapeFinder = new ShapeFinder();
            var shapes = new List<IShape>
            {
                new Circle(new Point(5, 5), 2),
                new Triangle(new Point(2, 2), new Point(4, 2), new Point(2, 5)),
                new Square(new Point(2, 5), new Point(5, 2)),
                new Triangle(new Point(-10, 2), new Point(-4, 4), new Point(2, 2)),
                new Circle(new Point(-5, 5), 6),
                new Circle(new Point(-1, 1), 10),
                new Circle(new Point(-1, 10), 6),
                new Circle(new Point(-5, -5), 2),
                new Square(new Point(-10, -1), new Point(-1, -10)),
                new Square(new Point(-1, 1), new Point(5, -5)),
                new Circle(new Point(0, 0), 1)
            };
            //Act
            var firstQuarter = shapeFinder.Find(shapes, Quarter.First).ToList();
            var secondQuarter = shapeFinder.Find(shapes, Quarter.Second).ToList();
            var thirdQuarter = shapeFinder.Find(shapes, Quarter.Third).ToList();
            var fourthQuarter = shapeFinder.Find(shapes, Quarter.Fourth).ToList();
            var noneQuarter = shapeFinder.Find(shapes, Quarter.None).ToList();
            //Assert
            Assert.AreEqual(firstQuarter.Count, 3);
            Assert.AreEqual(secondQuarter.Count, 4);
            Assert.AreEqual(thirdQuarter.Count, 2);
            Assert.AreEqual(fourthQuarter.Count, 1);
            Assert.AreEqual(noneQuarter.Count, 1);
        }
    }
}
