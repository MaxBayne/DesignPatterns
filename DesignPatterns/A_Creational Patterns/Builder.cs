using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.A_Creational_Patterns
{
    public class Builder
    {
        private IRobot _robot;

        public Builder(IRobot robot)
        {
            _robot = robot;
        }

        public IRobot getRobot()
        {
            return _robot;
        }

        public IRobot buildRobot()
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
