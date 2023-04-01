using AreaCalculatorDotNetLibrary;
using Microsoft.AspNetCore.Mvc;

namespace AreaCalculatorMindbox.Controllers
{
    public class CircleController : ControllerBase
    {
        private readonly AreaCalculator _areaCalculator;

        public CircleController(AreaCalculator areaCalculator)
        {
            _areaCalculator = areaCalculator;
        }

        public IActionResult GetArea(double radius)
        {
            try
            {
                Circle circle = new Circle(radius);
                double area = _areaCalculator.CalculateShapeArea(circle);
                return Ok(area);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
