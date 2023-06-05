namespace DesignPatterns.B_Structure_Patterns;

public class FlyWeight
{
    private static Dictionary<string, IPlayer> _playersDictionary = new();

    public static IPlayer CreatePlayer(string type)
    {
        switch (type)
        {
            case "blue":

                if (!_playersDictionary.ContainsKey(type))
                {
                    _playersDictionary.Add(type, new BluePlayer());
                }

                return _playersDictionary[type];

            case "red":
                if (!_playersDictionary.ContainsKey(type))
                {
                    _playersDictionary.Add(type, new RedPlayer());
                }

                return _playersDictionary[type];

            default:
                throw new Exception("Not Exist Type");
        }
    }

    public interface IPlayer
    {
        string Name { get; set; }
        string Weapon { get; set; }
        string Mission { get; set; }

        void PrintInfo();
    }

    public abstract class Player : IPlayer
    {
        public string Name { get; set; }
        public string Weapon { get; set; }
        public string Mission { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Player ({Name}) , has Weapon ({Weapon}) With Mission ({Mission})");
        }

    }

    public class BluePlayer : Player
    {

    }

    public class RedPlayer : Player
    {
     
    }
    
}
