using AreaCalculatorDotNetLibrary.Interface;

namespace AreaCalculatorDotNetLibrary
{
    public class AreaCalculator
    {
        public double CalculateShapeArea(IShape shape) => shape.CalculateArea();
    }
}
