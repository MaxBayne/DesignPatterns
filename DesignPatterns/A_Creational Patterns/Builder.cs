#pragma warning disable CS8618

namespace DesignPatterns.A_Creational_Patterns
{
    public interface IBuilder
    {
        IRobot GetRobot();

        IRobot BuildRobot();

    }

    public class Builder: IBuilder
    {
        private IRobot _robot;

        public Builder(IRobot robot)
        {
            _robot = robot;
        }

        public IRobot GetRobot()
        {
            return _robot;
        }

        public IRobot BuildRobot()
        {
            _robot.Head = "This is Head Of Robot";
            _robot.Arms = "This is Arms of Robot";
            _robot.Legs = "This is Legs of Robot";

            return _robot;
        }
    }

    public interface IRobot
    {
        string Arms { get; set; }
        string Head { get; set; }
        string Legs { get; set; }

        void PrintInfo();
    }

    public class Robot : IRobot
    {
        public string Head { get; set; }
        public string Arms { get; set; }
        public string Legs { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Head= {Head}");
            Console.WriteLine($"Arms= {Arms}");
            Console.WriteLine($"Legs= {Legs}");
        }
    }


}
