using Xunit;

namespace AreaCalculatorDotNetLibrary.Tests
{
    public class CircleTest
    {
        [Fact]
        public void CalculateArea_ValidRadius_CorrectArea()
        {
            // Arrange
            double radius = 3;
            double expectedArea = 28.2743338;
            Circle circle = new Circle(radius);

            // Act
            double actualArea = circle.CalculateArea();

            // Assert
            Assert.Equal(expectedArea, actualArea, 6);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Constructor_InvalidRadius_ThrowsArgumentException(double radius)
        {
            // Arrange, Act, Assert
            Assert.Throws<System.ArgumentException>(() => new Circle(radius));
        }
    }
}