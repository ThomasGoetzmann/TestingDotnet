namespace TestingDotnet;

public interface IEngine
{
    void Start();
}

public class HydrogenEngine : IEngine
{
    public void Start()
    {
        throw new NotImplementedException("This hydrogen engine is not ready yet !");
    }
}
