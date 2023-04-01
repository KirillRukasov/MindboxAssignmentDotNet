using Xunit;

namespace AreaCalculatorDotNetLibrary.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void CalculateArea_ValidSides_CorrectArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            double expectedArea = 6;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double actualArea = triangle.CalculateArea();

            // Assert
            Assert.Equal(expectedArea, actualArea);
        }

        [Fact]
        public void IsRightTriangle_ValidSides_True()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isRight = triangle.IsRightTriangle();

            // Assert
            Assert.True(isRight);
        }

        [Theory]
        [InlineData(-1, 4, 5)]
        [InlineData(3, 4, 0)]
        public void Constructor_InvalidSides_ThrowsArgumentException(double sideA, double sideB, double sideC)
        {
            // Arrange, Act, Assert
            Assert.Throws<System.ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Theory]
        [InlineData(1, 1, 10)]
        public void Constructor_NonExistingTriangle_ThrowsArgumentException(double sideA, double sideB, double sideC)
        {
            // Arrange, Act, Assert
            Assert.Throws<System.ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }
    }
}
