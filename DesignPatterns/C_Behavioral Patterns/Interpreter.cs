namespace DesignPatterns.C_Behavioral_Patterns;

public interface IContext
{
    string Content { get; set; }
}

public class Context: IContext
{
    public string Content { get; set; }

    public Context(string content)
    {
        Content=content;
    }
}

public interface IExpression
{
    abstract void Interpret(IContext context);
}

public abstract class Expression: IExpression
{
    public abstract void Interpret(IContext context);
}

public class TerminalExpression : Expression
{
    public override void Interpret(IContext context)
    {
        Console.WriteLine($"Terminal Expression {context}");
    }
}


public class NonTerminalExpression : Expression
{
    public IExpression Expression1 { get; set; }
    public IExpression Expression2 { get; set; }

    public override void Interpret(IContext context)
    {
        Console.WriteLine($"Non-Terminal Expression {context}");
        Expression1.Interpret(context);
        Expression2.Interpret(context);
    }
}


public class Interpreter
{
    
}