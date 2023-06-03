namespace TestingDotnet;

public class CarOne
{
    //1
    public string Start()
    {
        return "Vroum";
    }

    //2
    public bool IsLightOn { get; private set; }

    public void ToggleLights()
    {
        IsLightOn = !IsLightOn;
    }
}