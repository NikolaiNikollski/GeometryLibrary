namespace Geometry.Core.Entities;

/// <summary>
/// Represents a circle and provides methods to calculate its area.
/// </summary>
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

    /// <summary>
    /// Calculates the area of the circle
    /// </summary>
    /// <returns>The area of the circle.</returns>
    /// <exception cref="ArithmeticException">
    /// Thrown when the calculated area is not a valid number (NaN or Infinity).
    /// </exception>
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