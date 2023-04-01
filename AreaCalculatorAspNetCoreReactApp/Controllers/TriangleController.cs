using AreaCalculatorDotNetLibrary;
using Microsoft.AspNetCore.Mvc;

namespace AreaCalculatorMindbox.Controllers
{
    public class TriangleController : ControllerBase
    {
        private readonly AreaCalculator _areaCalculator;

        public TriangleController(AreaCalculator areaCalculator)
        {
            _areaCalculator = areaCalculator;
        }

        public IActionResult GetArea(double sideA, double sideB, double sideC)
        {
            try
            {
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                double area = _areaCalculator.CalculateShapeArea(triangle);
                return Ok(area);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        public IActionResult IsRight(double sideA, double sideB, double sideC)
        {
            try
            {
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                bool isRight = triangle.IsRightTriangle();
                return Ok(isRight);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
