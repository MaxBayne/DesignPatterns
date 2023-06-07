namespace DesignPatterns.C_Behavioral_Patterns;

#region Subscriber

public interface ISubscriber
{
    string Name { get; }

    void Update(ISubject subject);

}

public abstract class BaseSubscriber : ISubscriber
{
    protected BaseSubscriber(string name)
    {
        Name=name;
    }
    public string Name { get; }
    public abstract void Update(ISubject subject);
}

public class Subscriber : BaseSubscriber
{
    public Subscriber(string name):base(name) {}

    public override void Update(ISubject subject)
    {
        Console.WriteLine($"({Name})=> Coming Notify from Subject With Title ({subject.Title})");
    }
}

#endregion


#region Subject

public interface ISubject
{
    string Title { get; set; }

    List<ISubscriber> Subscribers { get; }

    void Attach(ISubscriber subscriber);
    void Detach(ISubscriber subscriber);

    void Notify();

    void DoSomeLogic();
}

public abstract class BaseSubject : ISubject
{
    public string Title { get; set; }
    public List<ISubscriber> Subscribers { get; }

    protected BaseSubject(string title)
    {
        Title = title;
        Subscribers = new List<ISubscriber>();
    }

    public void Attach(ISubscriber subscriber)
    {
        Subscribers.Add(subscriber);
    }

    public void Detach(ISubscriber subscriber)
    {
        Subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        Subscribers.ForEach((subscriber) =>
        {
            subscriber.Update(this);
        });
    }

    public abstract void DoSomeLogic();
}

public class Subject : BaseSubject
{
    public Subject(string title):base(title) {}

    public override void DoSomeLogic()
    {
        Console.WriteLine("Subject Make Some Jobs");
        Thread.Sleep(5000);
        Notify();
    }
}

#endregion


