namespace Geometry.Core.Entities;

public class Circle : IAreaCalculable 
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Circle radius must be positive.");
        }
        
        Radius = radius;
    }

    public double CalculateArea()
    {
        var area = Math.PI * Radius * Radius;
        
        //Is it excessive?
        if (double.IsNaN(area) || double.IsInfinity(area))
        {
            throw new ArithmeticException("Error calculating area: the result is not a valid number.");
        }

        return area;
    }
}