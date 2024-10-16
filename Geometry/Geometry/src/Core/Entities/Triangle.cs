namespace Geometry.Core.Entities;

public class Triangle : IAreaCalculable
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

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

    public bool IsRightTriangle()
    {
        var sortedSides = new[] { SideA, SideB, SideC }.OrderBy(side => side).ToArray();

        var pythagoreanDifference = Math.Abs(
            Math.Pow(sortedSides[0], 2) +
            Math.Pow(sortedSides[1], 2) -
            Math.Pow(sortedSides[2], 2)
        );

        //Is it excessive?
        if (double.IsNaN(pythagoreanDifference) || double.IsInfinity(pythagoreanDifference))
        {
            throw new ArithmeticException("Error pythagorean difference: the result is not a valid number.");
        }

        // Check for zero considering computational precision
        return pythagoreanDifference < 1e-10;
    }
}