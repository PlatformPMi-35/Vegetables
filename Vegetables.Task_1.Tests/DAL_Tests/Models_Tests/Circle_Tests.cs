using System;
using System.Windows;
using NUnit.Framework;
using Vegetables.Task_1.DAL.Models;

namespace Vegetables.Task_1.Tests.DAL_Tests.Models_Tests
{
    [TestFixture]
    public class Circle_Tests
    {
        [Test]
        public void MiddlePoint_Test()
        {
            //Arrange
            var circle = new Circle(new Point(0, 0), 10);
            //Act
            var middlePoint = circle.MiddlePoint;
            //Assert
            Assert.AreEqual(new Point(0,0), middlePoint);
        }

        [Test]
        public void Perimeter_Test()
        {
            //Arrange
            var circle = new Circle(new Point(0, 0), 10);
            //Act
            var perimeter = circle.Perimeter();
            //Assert
            Assert.AreEqual(2 * Math.PI * 10, perimeter);
        }

        [Test]
        public void Area_Test()
        {
            //Arrange
            var circle = new Circle(new Point(0, 0), 10);
            //Act
            var area = circle.Area();
            //Assert
            Assert.AreEqual(Math.PI * 100, area);
        }
    }
}
