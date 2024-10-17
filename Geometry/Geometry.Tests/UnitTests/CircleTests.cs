using Geometry.Core.Entities;

namespace Geometry.Tests.UnitTests;

public class CircleTests
{
    [Fact]
    public void Constructor_NegativeRadius_ThrowsArgumentException()
    {
        // Arrange
        double negativeRadius = -1;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Circle(negativeRadius));
    }

    [Fact]
    public void Constructor_ZeroRadius_ThrowsArgumentException()
    {
        // Arrange
        double zeroRadius = 0;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Circle(zeroRadius));
    }
    
    [Fact]
    public void Constructor_NaNRadius_ThrowsArgumentException()
    {
        // Arrange
        double zeroRadius = double.NaN;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new Circle(zeroRadius));
    }
    
    [Fact]
    public void CalculateArea_MaximumRadius_ThrowsArithmeticException()
    {
        // Arrange
        var circle = new Circle(double.MaxValue);
        
        // Act & Assert
        Assert.Throws<ArithmeticException>(() => circle.CalculateArea());
    }
    
    [Fact]
    public void CalculateArea_PositiveIntegerRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 10;
        var expectedArea = 314.16;
        var circle = new Circle(radius);
    
        // Act
        var area = circle.CalculateArea();
    
        // Assert
        Assert.Equal(expectedArea, area, 2);
    }
    
    [Fact]
    public void CalculateArea_PositiveNonIntegerRadius_ReturnsCorrectArea()
    {
        // Arrange
        double radius = 5.39;
        var expectedArea = 91.27;
        var circle = new Circle(radius);
    
        // Act
        var area = circle.CalculateArea();
    
        // Assert
        Assert.Equal(expectedArea, area, 2);
    }
}