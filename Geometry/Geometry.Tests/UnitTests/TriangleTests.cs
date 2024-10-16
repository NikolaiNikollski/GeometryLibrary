using Geometry.Core.Entities;

namespace Geometry.Tests.UnitTests;

public class TriangleTests
{
    [Theory]
    [InlineData(-5, 3, 4)] 
    [InlineData(3, -3, 4)] 
    [InlineData(3, 4, -5)] 
    [InlineData(0, 3, 4)] 
    [InlineData(3, 0, 4)] 
    [InlineData(3, 4, 0)] 
    [InlineData(double.MaxValue, 3, 4)] 
    [InlineData(3, double.MaxValue, 4)] 
    [InlineData(3, 4, double.MaxValue)] 
    public void Constructor_InvalidSides_ThrowsArgumentException(double a, double b, double c)
    {
        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }
    
    [Theory]
    [InlineData(double.NaN, 3, 4)] 
    [InlineData(3, double.NaN, 4)] 
    [InlineData(3, 4, double.NaN)] 
    public void CalculateArea_NaNSides_ThrowsArithmeticException(double a, double b, double c)
    {
        // Arrange
        var triangle = new Triangle(a, b, c);

        // Act & Assert
        Assert.Throws<ArithmeticException>(() => triangle.CalculateArea());
    }

    [Fact]
    public void Constructor_InvalidTriangle_ThrowsArgumentException()
    {
        // Arrange
        double a = 1, b = 1, c = 3;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Fact]
    public void CalculateArea_ValidTriangleWithIntegerSides_ReturnsCorrectArea()
    {
        // Arrange
        double a = 3, b = 4, c = 5; 
        double expectedArea = 6;
        var triangle = new Triangle(a, b, c);

        // Act
        var area = triangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area);
    }
    
    [Fact]
    public void CalculateArea_ValidTriangleWithNonIntegerSides_ReturnsCorrectArea()
    {
        // Arrange
        double a = 3.21, b = 4.32, c = 5.43; 
        double expectedArea = 6.93;
        var triangle = new Triangle(a, b, c);

        // Act
        var area = triangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area, 2);
    }
    
    [Fact]
    public void IsRightTriangle_ValidTriangleWithIntegerSides_ReturnsTrue()
    {
        // Arrange
        var triangle = new Triangle(3, 4, 5);
        var precision = 5;

        // Act
        bool isRight = triangle.IsRightTriangle(precision);

        // Assert
        Assert.True(isRight);
    }
    
    [Fact]
    public void IsRightTriangle_ValidTriangleWithNonIntegerSides_ReturnsTrue()
    {
        // Arrange
        var triangle = new Triangle(3.21, 4.39, 5.44);

        // Act
        bool isRight = triangle.IsRightTriangle(1);

        // Assert
        Assert.True(isRight);
    }
    
    [Fact]
    public void IsRightTriangle_ValidTriangleWithNonIntegerSidesWithHightPrecision_ReturnsFalse()
    {
        // Arrange
        var triangle = new Triangle(3.21, 4.39, 5.44);

        // Act
        bool isRight = triangle.IsRightTriangle(3);

        // Assert
        Assert.False(isRight);
    }

    [Fact]
    public void IsRightTriangle_ValidNonRightTriangle_ReturnsFalse()
    {
        // Arrange
        var triangle = new Triangle(2, 3, 4);

        // Act
        bool isRight = triangle.IsRightTriangle(0);

        // Assert
        Assert.False(isRight);
    }
}