## Create

1. Create `xunit` project.
Create `classlib` project.
2. Add **Reference** of classlib in test project.

## Project

1. Rename `CarOne`
2. Create method `public string Start() { return "Vroum"; }`

## Test 1 : Value Based

1. Rename `CarOneUnitTests`
2. Talk about test attributes `Fact` or `TestClass`/`TestMethod`
3. Write first test and talk about **AAA** and **[Fact]** 
```csharp
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
        Assert.Equal("Vroum", result);
    }
}
```
4. Talk about [**FluentAssertions**](https://fluentassertions.com/introduction) or [**Shouldly**](https://github.com/shouldly/shouldly)
```csharp
using FluentAssertions;

//...
        //Assert
        result.Should().Be("Vroum");

        //instead of 
        //Assert.Equal("Vroum", result); 
```
5. Talk about some other extensions like [Fine Code Coverage](https://marketplace.visualstudio.com/items?itemName=FortuneNgwenya.FineCodeCoverage)

## Test 2 : State-Based
1. Add code for `ToggleLights()`
```csharp
    public bool IsLightOn { get; private set; }

    public void ToggleLights()
    {
        IsLightOn = !IsLightOn;
    }
```

2. Write test
```csharp
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
```
3. Talk about **method name** `MethodName_Scenario_ExpectedBehavior`

## Test 3 : Interaction Based

1. Create new class `CarTwo`
2. It has a `Start()` method which requires an engine.
```csharp
    public bool IsRunning { get; private set; }

    public void Start()
    {
        engine.Start();
        IsRunning = true;
    }

```
3. Add the engine and inject it through the constructor
```csharp
    private readonly IEngine engine;

    public CarTwo(IEngine engine)
    {
        this.engine = engine;
    }
```
4. Create the interface
```csharp
public interface IEngine
{
    void Start();
}
```
5. Create an implementation for the interface which is not ready yet
```csharp
public class HydrogenEngine : IEngine
{
    public void Start()
    {
        throw new NotImplementedException("This hydrogen engine is not ready yet !");
    }
}
```
6. Create the first unit test 
```csharp
public class CarTwoUnitTests
{
    [Fact]
    public void Start_IsRunning()
    {
        //Arrange
        var engine = new HydrogenEngine();
        var myCar = new CarTwo(engine);

        //Act
        myCar.Start();

        //Assert
        myCar.IsRunning.Should().BeTrue();
    }
}
```

This is failing ! Because the Hydrogen Engine is not ready yet !
7. Use a "Fake" engine by using a framework like [NSubsitute](https://nsubstitute.github.io/help.html) or [FakeItEasy](https://fakeiteasy.github.io/docs/)
Here fakeEngine is called a **STUB**
```csharp
using NSubstitute;

    [Fact]
    public void Start_IsRunning()
    {
        //Arrange
        var fakeEngine = Substitute.For<IEngine>();
        //var fakeEngine = new HydrogenEngine();
        var myCar = new CarTwo(fakeEngine);

        //Act
        myCar.Start();

        //Assert
        myCar.IsRunning.Should().BeTrue();
    }

```

8. Now we want to check if the Car has called the Engine correctly. This is a **MOCK**
```csharp
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
```