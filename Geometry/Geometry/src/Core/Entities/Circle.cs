namespace Geometry.Core.Entities;

/// <summary>
/// Represents a circle and provides methods to calculate its area.
/// </summary>
public class Circle : IAreaCalculable 
{
    public double Radius { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> class with the specified radius.
    /// </summary>
    /// <param name="radius">The radius of the circle. Must be a positive number and not NaN.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when the provided radius is zero, negative, or NaN.
    /// </exception>
    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("Circle radius must be positive.");
        }
        
        if (double.IsNaN(radius))
        {
            throw new ArgumentException("Circle radius must not be NaN.");
        }
        
        Radius = radius;
    }

    /// <summary>
    /// Calculates the area of the circle
    /// </summary>
    /// <returns>The area of the circle.</returns>
    /// <exception cref="ArithmeticException">
    /// Thrown when the calculated area is infinity.
    /// </exception>
    public double CalculateArea()
    {
        var area = Math.PI * Radius * Radius;
        
        if (double.IsInfinity(area))
        {
            throw new ArithmeticException("Error calculating area: the result is infinity.");
        }

        return area;
    }
}