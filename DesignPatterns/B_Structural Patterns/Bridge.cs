namespace DesignPatterns.B_Structure_Patterns;

#region Bridge A

public interface IOperatingSystem
{
    string Name { get; set; }
    void DoOperation();
}

public abstract class OperatingSystem: IOperatingSystem
{
    public string Name { get; set; }
    public abstract void DoOperation();
}

public class Windows : OperatingSystem
{
    public Windows()
    {
        Name = "Windows";
    }

    public override void DoOperation()
    {
        Console.WriteLine("Do Operation on Windows");
    }
}

public class Linux : OperatingSystem
{
    public Linux()
    {
        Name = "Linux";
    }

    public override void DoOperation()
    {
        Console.WriteLine("Do Operation on Linux");
    }
}

public class IOS : OperatingSystem
{
    public IOS()
    {
        Name = "IOS";
    }

    public override void DoOperation()
    {
        Console.WriteLine("Do Operation on IOS");
    }
}

#endregion

#region Bridge B

public interface IControl
{
    IOperatingSystem OperatingSystem { get; set; }
    void Click();
}

public class Button : IControl
{
    public IOperatingSystem OperatingSystem { get; set; }

    public Button(IOperatingSystem operatingSystem)
    {
        OperatingSystem = operatingSystem;
    }

    public void Click()
    {
        OperatingSystem.DoOperation();
    }
}

public class TextBox : IControl
{
    public IOperatingSystem OperatingSystem { get; set; }

    public TextBox(IOperatingSystem operatingSystem)
    {
        OperatingSystem = operatingSystem;
    }

    public void Click()
    {
        OperatingSystem.DoOperation();
    }
}

#endregion
