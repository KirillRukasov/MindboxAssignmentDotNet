using AreaCalculatorDotNetLibrary.Interface;

namespace AreaCalculatorDotNetLibrary
{
    public class Triangle : IShape
    {
        public double _sideA { get; set; }
        public double _sideB { get; set; }
        public double _sideC { get; set; }

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (IsPositiveSides(sideA, sideB, sideC) && IsValidTriangle(sideA, sideB, sideC))
            {
                _sideA = sideA;
                _sideB = sideB;
                _sideC = sideC;
            }
            else
            {
                throw new ArgumentException("A triangle with given sides does not exist");
            }
        }

        public double CalculateArea()
        {
            double semiPerimeter = (_sideA + _sideB + _sideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
        }

        public bool IsRightTriangle()
        {
            double[] sides = new double[] { _sideA, _sideB, _sideC };
            Array.Sort(sides);

            return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < 1e-10;
        }

        private bool IsValidTriangle(double sideA, double sideB, double sideC)
        {
            return sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA;
        }
        private bool IsPositiveSides(double sideA, double sideB, double sideC)
        {
            return sideA > 0 && sideB > 0 && sideC > 0;
        }
    }
}
