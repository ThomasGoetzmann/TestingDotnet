namespace TestingDotnet;

public class CarTwo
{
    private readonly IEngine engine;
    public bool IsRunning { get; private set; }

    public CarTwo(IEngine engine)
    {
        this.engine = engine;
    }

    public void Start()
    {
        engine.Start();
        IsRunning = true;
    }
}
