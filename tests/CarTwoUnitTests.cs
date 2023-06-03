using FluentAssertions;
using NSubstitute;

namespace TestingDotnet.Tests;

public class CarTwoUnitTests
{
    [Fact]
    public void Start_IsRunning()
    {
        //Arrange
        var fakeEngine = Substitute.For<IEngine>();
        var myCar = new CarTwo(fakeEngine);

        //Act
        myCar.Start();

        //Assert
        myCar.IsRunning.Should().BeTrue();
    }

    [Fact]
    public void Start_CallsEngineStart()
    {
        //Arrange
        var fakeEngine = Substitute.For<IEngine>();
        var myCar = new CarTwo(fakeEngine);

        //Act
        myCar.Start();

        //Assert
        fakeEngine.Received(1).Start();
    }
}
