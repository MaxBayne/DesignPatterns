namespace DesignPatterns.C_Behavioral_Patterns;

public interface ICommand
{
    IReceiver Receiver { get; }
    void Execute();
}

public abstract class Command:ICommand
{
    public IReceiver Receiver { get; }

    protected Command(IReceiver receiver)
    {
        Receiver = receiver;
    }

    
    public abstract void Execute();
}

public class SendMoneyToSingleCommand: Command
{
    public SendMoneyToSingleCommand(IReceiver receiver) : base(receiver) {}

    public override void Execute()
    {
        Console.WriteLine($"({Receiver.Name})=> Receive Command From Invoker");
    }
}


public class SendMoneyToMultiCommand : Command
{
    public SendMoneyToMultiCommand(IReceiver receiver) : base(receiver) { }

    public override void Execute()
    {
        Console.WriteLine($"({Receiver.Name})=> Receive Command From Invoker");
    }
}





#region Invoker

public interface IInvoker
{
    string Name { get; }
    void Invoke(ICommand command);
}

public class Invoker : IInvoker
{
    public string Name { get; }
    public Invoker(string name)
    {
        Name=name;
    }

    public void Invoke(ICommand command)
    {
        command.Execute();
    }
}


#endregion

public interface IReceiver
{
    string Name { get; }
    void Receive(ICommand command,IInvoker invoker);
}

public class Receiver:IReceiver
{
    public string Name { get; }

    public Receiver(string name)
    {
        Name = name;
    }

    public void Receive(ICommand command, IInvoker invoker)
    {
        
    }
}