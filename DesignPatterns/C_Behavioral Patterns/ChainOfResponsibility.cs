namespace DesignPatterns.C_Behavioral_Patterns;


#region Request

public enum RequestType
{
    Conference,
    Purchase,
    Sales
}

public interface IRequest
{
    RequestType RequestType { get; }

    double Amount { get; }
}

public class Request : IRequest
{
    public RequestType RequestType { get; }
    public double Amount { get; }

    public Request(RequestType requestType, double amount)
    {
        RequestType = requestType;
        Amount = amount;
    }
}


#endregion

#region Handler

public interface IHandler
{
    string Name { get; }
    IHandler AboveSuccessor { get; }

    void HandelRequest(IRequest request);
}

public abstract class Handler:IHandler
{
    public string Name { get; }
    public IHandler AboveSuccessor { get; }
    

    public Handler(string name,IHandler aboveSuccessor)
    {
        Name=name;
        AboveSuccessor = aboveSuccessor;
    }

    public abstract void HandelRequest(IRequest request);
}


public class Director : Handler
{
    public Director(string name, IHandler aboveSuccessor) : base(name, aboveSuccessor) { }

    public override void HandelRequest(IRequest request)
    {
        if (request.RequestType == RequestType.Conference)
        {
            Console.WriteLine("Director handel the Conference Request");
        }
        else
        {
            Console.WriteLine("Director cant handel the Request");
            AboveSuccessor.HandelRequest(request);
        }

    }
}

public class Vp : Handler
{
    public Vp(string name, IHandler aboveSuccessor) : base(name, aboveSuccessor) { }

    public override void HandelRequest(IRequest request)
    {
        if (request.RequestType == RequestType.Purchase && request.Amount<=1500)
        {
            Console.WriteLine("VP handel the Purchase Request less than 1500");
        }
        else
        {
            Console.WriteLine("VP cant handel the Request");
            AboveSuccessor.HandelRequest(request);
        }
    }
}

public class Ceo : Handler
{
    public Ceo(string name) : base(name, null!) {}

    public override void HandelRequest(IRequest request)
    {
        Console.WriteLine("Ceo Handel the Request");
    }
}


#endregion



