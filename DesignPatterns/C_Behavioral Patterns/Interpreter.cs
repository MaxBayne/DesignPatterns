namespace DesignPatterns.C_Behavioral_Patterns;

#region Context

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

#endregion

#region Expression

public interface IExpression
{
    bool Interpret(IContext context);
}

public abstract class Expression : IExpression
{
    public abstract bool Interpret(IContext context);
}

//Terminal Expression
public class TerminalExpression : Expression
{
    private string _data;

    public TerminalExpression(string data)
    {
        _data = data;
    }

    public override bool Interpret(IContext context)
    {
        return context.Content.Contains(_data);
    }
}

//Non-Terminal Expression
public class OrExpression : Expression
{
    private IExpression _expression1;
    private IExpression _expression2;

    public OrExpression(IExpression expression1, IExpression expression2)
    {
        this._expression1 = expression1;
        this._expression2 = expression2;
    }

    public override bool Interpret(IContext context)
    {
        return _expression1.Interpret(context) || _expression2.Interpret(context);
    }
}

//Non-Terminal Expression
public class AndExpression : Expression
{
    private IExpression _expression1;
    private IExpression _expression2;

    public AndExpression(IExpression expression1, IExpression expression2)
    {
        _expression1 = expression1;
        _expression2 = expression2;
    }

    public override bool Interpret(IContext context)
    {
        return _expression1.Interpret(context) && _expression2.Interpret(context);
    }
}

#endregion

#region Interpreter

public class Interpreter
{
    //ahmed and khalid are male
    public static IExpression GetMaleExpressions()
    {
        var ahmed = new TerminalExpression("ahmed");
        var khalid = new TerminalExpression("khaild");

        return new OrExpression(ahmed, khalid);
    }

    //mona and hoda are female
    public static IExpression GetFeMaleExpressions()
    {
        var mona = new TerminalExpression("mona");
        var hoda = new TerminalExpression("hoda");

        return new OrExpression(mona, hoda);
    }




    //ahmed is a doctor
    public static IExpression GetDoctorExpressions()
    {
        var ahmed = new TerminalExpression("ahmed");
        var doctor = new TerminalExpression("doctor");

        return new AndExpression(ahmed, doctor);
    }

    //mona is a teacher
    public static IExpression GetTeacherExpressions()
    {
        var mona = new TerminalExpression("mona");
        var teacher = new TerminalExpression("teacher");

        return new AndExpression(mona, teacher);
    }
}

#endregion
