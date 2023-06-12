namespace DesignPatterns.C_Behavioral_Patterns;

public record Memento(string Name, int Age);

public class Player
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Player(string name,int age)
    {
        Name=name;
        Age=age;
    }

    public Memento CreateMemento() => new Memento(Name, Age);
    
    public void UndoMemento(Memento memento)
    {
        Name = memento.Name;
        Age = memento.Age;
    }

    public override string ToString()
    {
        return $"Player ({Name}) with Age ({Age})";
    }
}

public class Manager
{
    private readonly Stack<Memento> _stack;

    public Manager()
    {
        _stack = new Stack<Memento>();
    }

    public void PushMemento(Memento memento)
    {
        _stack.Push(memento);
    }

    public Memento PopMemento()
    {
        return _stack.Pop();
    }
}

