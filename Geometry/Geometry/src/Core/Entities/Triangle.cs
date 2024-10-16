namespace Geometry.Core.Entities;

/// <summary>
/// Represents a triangle and provides methods to calculate its area and check if it is a right triangle.
/// </summary>
public class Triangle : IAreaCalculable
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    
    /// <summary>
    /// Initializes a new instance of the <see cref="Triangle"/> class.
    /// </summary>
    /// <param name="a">The length of side A.</param>
    /// <param name="b">The length of side B.</param>
    /// <param name="c">The length of side C.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when any side length is less than or equal to zero, or when the provided sides do not form a valid triangle.
    /// </exception>
    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
        {
            throw new ArgumentException("Triangle sides must be positive.");
        }

        if (a + b <= c || a + c <= b || b + c <= a)
        {
            throw new ArgumentException("Sides do not form a valid triangle.");
        }

        SideA = a;
        SideB = b;
        SideC = c;
    }

    /// <summary>
    /// Calculates the area of the triangle.
    /// </summary>
    /// <returns>The area of the triangle.</returns>
    /// <exception cref="ArithmeticException">
    /// Thrown when the area calculation results in an invalid number (NaN or Infinity).
    /// </exception>
    public double CalculateArea()
    {
        double semiPerimeter = (SideA + SideB + SideC) / 2;
        double area = Math.Sqrt(
            semiPerimeter *
            (semiPerimeter - SideA) *
            (semiPerimeter - SideB) *
            (semiPerimeter - SideC)
        );

        //Is it excessive?
        if (double.IsNaN(area) || double.IsInfinity(area))
        {
            throw new ArithmeticException("Error calculating area: the result is not a valid number.");
        }

        return area;
    }

    /// <summary>
    /// Checks if the triangle is a right triangle by comparing the squares of its sides.
    /// </summary>
    /// <param name="decimalPlaces">The number of decimal places to use for comparison.</param>
    /// <returns>
    /// <c>true</c> if the triangle is a right triangle; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Thrown when the decimal places parameter is a negative integer.
    /// </exception>
    /// <exception cref="ArithmeticException">
    /// Thrown when the Pythagorean difference calculation results in an invalid number (NaN or Infinity).
    /// </exception>
    public bool IsRightTriangle(int decimalPlaces)
    {
        var sortedSides = new[] { SideA, SideB, SideC }.OrderBy(side => side).ToArray();

        var sumOfSquaredCatheti = Math.Pow(sortedSides[0], 2) + Math.Pow(sortedSides[1], 2);
        var squaredHypotenuse = Math.Pow(sortedSides[2], 2);
        
        //Is it excessive?
        if (double.IsNaN(sumOfSquaredCatheti) || double.IsInfinity(sumOfSquaredCatheti))
        {
            throw new ArithmeticException("Sum of squared Catheti is not a valid number.");
        }
        
        if (double.IsNaN(squaredHypotenuse) || double.IsInfinity(squaredHypotenuse))
        {
            throw new ArithmeticException("Squared hypotenuse is not a valid number.");
        }

        double tolerance = Math.Pow(10, -decimalPlaces);

        // Check for zero considering user-defined tolerance
        return Math.Abs(sumOfSquaredCatheti - squaredHypotenuse) < tolerance;
    }
}