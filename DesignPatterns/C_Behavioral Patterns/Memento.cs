namespace DesignPatterns.C_Behavioral_Patterns
{
    /*
     * Memento Pattern
     * ---------------
     * its like take snapshot from object and can restore that snapshot at any time
     */

    #region Player Memento

    //snapshot
    public class PlayerMemento
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public PlayerMemento(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }


    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Player(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public PlayerMemento CreateMemento() => new PlayerMemento(Name, Age);

        public void UndoMemento(PlayerMemento memento)
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
        private readonly Stack<PlayerMemento> _stack;

        public Manager()
        {
            _stack = new Stack<PlayerMemento>();
        }

        public void PushMemento(PlayerMemento memento)
        {
            _stack.Push(memento);
        }

        public PlayerMemento PopMemento()
        {
            return _stack.Pop();
        }
    }

    #endregion


}