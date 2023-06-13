namespace DesignPatterns.C_Behavioral_Patterns;

public interface IStrategy
{
    void disassemble();
}

public class ToyotaStrategy : IStrategy
{
    public void disassemble()
    {
        Console.WriteLine("Disassimle Toyota Algorithem");
    }
}

public class BmwStrategy : IStrategy
{
    public void disassemble()
    {
        Console.WriteLine("Disassimle Bmw Algorithem");
    }
}

public class Mechanic
{
    public void DisassembleCar(IStrategy strategy)
    {
        strategy.disassemble();
    }
}