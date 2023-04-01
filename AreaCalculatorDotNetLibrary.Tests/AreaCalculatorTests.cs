using Xunit;

namespace AreaCalculatorDotNetLibrary.Tests
{
    public class AreaCalculatorTests
    {
        [Fact]
        public void CalculateShapeArea_Circle_ValidArea()
        {
            // Arrange
            double radius = 3;
            double expectedArea = 28.2743338;
            Circle circle = new Circle(radius);
            AreaCalculator calculator = new AreaCalculator();

            // Act
            double actualArea = calculator.CalculateShapeArea(circle);

            // Assert
            Assert.Equal(expectedArea, actualArea, 6);
        }

        [Fact]
        public void CalculateShapeArea_Triangle_ValidArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            double expectedArea = 6;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            AreaCalculator calculator = new AreaCalculator();

            // Act
            double actualArea = calculator.CalculateShapeArea(triangle);

            // Assert
            Assert.Equal(expectedArea, actualArea);
        }
    }
}
