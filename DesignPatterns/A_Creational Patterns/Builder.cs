#pragma warning disable CS8618

namespace DesignPatterns.A_Creational_Patterns
{

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



    public interface IRobotBuilder
    {
        IRobot Build();
    }

    public class RobotBuilder: IRobotBuilder
    {
        private IRobot _robot;

        public RobotBuilder(IRobot robot)
        {
            _robot = robot;
        }


        public RobotBuilder SetHead(string head)
        {
            _robot.Head = head;
            return this;
        }

        public RobotBuilder SetArms(string arms)
        {
            _robot.Arms = arms;
            return this;
        }

        public RobotBuilder SetLegs(string legs)
        {
            _robot.Legs=legs;
            return this;
        }


        public IRobot Build()
        {
            //Make Any Validation

            //Return Robot
            return _robot;
        }
    }

}
