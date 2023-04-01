using AreaCalculatorDotNetLibrary.Interface;

namespace AreaCalculatorDotNetLibrary
{
    public class Circle : IShape
    {
        public double _radius { get; set; }

        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be positive");
            }
            _radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }
}
