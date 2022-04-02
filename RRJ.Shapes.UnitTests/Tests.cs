using Xunit;
using Moq;
using System;

namespace RRJ.Shapes.UnitTests
{
    public class Tests
    {
        [Fact]
        public void isRightTriangleTest()
        {
            //Arrange

            //Египетский треугольник
            Triangle triange = new Triangle(3, 4, 5); 

            //Act
            bool result = triange.IsRightTriangle();

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ComputeTest()
        {
            //Arrange

            IShape circle = new Circle(1);          
           

            //Act
            var areaOfCircle = Area.Compute(circle);
                  

            //Assert
            Assert.Equal(areaOfCircle, Math.PI);
        }

        [Fact]
        public void ComputeTriangleTest()
        {
            //Arrange
            IShape triangle = new Triangle(3, 4, 5);


            //Act
            var areaOfTriangle = Area.Compute(triangle);

            //Assert
            Assert.Equal(areaOfTriangle, 6);           
        }

        [Fact]
        public void ComputeShapeTest()
        {
            //Arrange
            Mock<IShape> fakeShape = new Mock<IShape>();


            //Act
            Func<object> del = () => Area.Compute(fakeShape.Object);

            //Assert
            Assert.Throws<UndefinedShapeException>(del);
        }
    }
}