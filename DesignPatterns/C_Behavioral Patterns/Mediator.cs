namespace DesignPatterns.C_Behavioral_Patterns;

public interface ICab
{
    int Id { get; set; }
    string Name { get; set; }
    string Location { get; set; }

    void NotifyMessage(ICab sender, string message);
}

public class Cab:ICab
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    public Cab(int id,string name,string location)
    {
        this.Id= id;
        this.Name= name;
        this.Location= location;
    }

    public void NotifyMessage(ICab sender,string message)
    {
        Console.WriteLine($"({Name})=> [{sender.Name}] ask help with message {message}");
    }

}

#region Mediator    

public interface ICabTower
{
    void RegisterCab(ICab cab);
    void AskHelp(ICab sender,string message);
}

public class CabTower:ICabTower
{
    private readonly Dictionary<int, ICab> _cabs;

    public CabTower()
    {
        _cabs = new();
    }

    public void RegisterCab(ICab cab)
    {
        if (!_cabs.ContainsKey(cab.Id))
        {
            _cabs.Add(cab.Id,cab);
        }
    }

    public void AskHelp(ICab sender, string message)
    {
        Console.WriteLine($"(CabTower) => ({sender.Name}) ask help !");

        foreach (var cab in _cabs)
        {
            if (cab.Key != sender.Id)
            {
                cab.Value.NotifyMessage(sender, message);
            }
        }
    }
}

#endregion
