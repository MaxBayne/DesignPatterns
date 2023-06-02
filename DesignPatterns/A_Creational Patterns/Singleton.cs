namespace DesignPatterns.A_Creational_Patterns;

/// <summary>
/// Create One Instance From Object and Create it on first Request it only and every request will get created static instance
/// All Constructor must be private the only way to create instance from this class is over by GetInstance()
/// Class Must be Sealed mean not inheritable
/// </summary>
public sealed class Singleton
{
    //Local Storage For Singleton Instance
    private static Lazy<Singleton>? _instance;
    
    //Store how many instances created from this class
    private static int _counter;


    #region Private Constructors

    private Singleton()
    {
        _counter++;

        Console.WriteLine($"Instance Number is {_counter}");
    }

    #endregion

    #region Creational Pattern Singleton

    public static Singleton Instance
    {
        get
        {

            //For First time only Create new Instance From this Class and save it inside static private variable
            if (_instance == null)
            {
                _instance = new Lazy<Singleton>(() => new Singleton());
            }
            return _instance.Value;
        }
    }

    #endregion

    #region Methods

    public void Print_Message(string message)
    {
        Console.WriteLine(message);
    }

    #endregion

}