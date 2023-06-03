using FluentAssertions;

namespace TestingDotnet;

public class CarOneUnitTests
{
    [Fact]
    public void Start_IsVrouming()
    {
        //Arrange
        var myCar = new CarOne();

        //Act
        var result = myCar.Start();

        //Assert
        //Assert.Equal("Vroum", result);
        result.Should().Be("Vroum");
    }

    [Fact]
    public void ToggleLights_ForNewCar_LightsOn()
    {
        //Arrange
        var myCar = new CarOne();

        //Act
        myCar.ToggleLights();

        //Assert
        myCar.IsLightOn.Should().BeTrue();
    }
}