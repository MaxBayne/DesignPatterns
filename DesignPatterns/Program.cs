using DesignPatterns.A_Creational_Patterns;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Creational Design Pattern");
            Console.WriteLine("==========================");

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("### Singleton Pattern ###");


            //For Single Thread ----------------
            Console.WriteLine("\n(From Single Thread)");
            Get_Singleton_1();
            Get_Singleton_2();
            
            //For Multi Thread ----------------
            Console.WriteLine("\n(From Multi Thread)");
            Parallel.Invoke(Get_Singleton_1, Get_Singleton_2);


            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Factory Pattern ###");

            var sedan = Factory.getCar("S");
            sedan.printName();

            var subuv = Factory.getCar("U");
            subuv.printName();

            var truck = Factory.getCar("T");
            truck.printName();

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Builder Pattern ###");

            var robotBuilder = new Builder(new Robot());
            var builtedRobot = robotBuilder.buildRobot();
            
            builtedRobot.PrintInfo();

            Console.WriteLine("--------------------------------------------------------------");












            Console.ReadKey();
        }

        #region Creational Design Patterns

        #region Singleton

        static void Get_Singleton_1()
        {
            var singletonInstance1 = Singleton.GetInstance();
            singletonInstance1.Print_Message("Hello World");
        }

        static void Get_Singleton_2()
        {
            var singletonInstance2 = Singleton.GetInstance();
            singletonInstance2.Print_Message("How Are You");
        }


        #endregion

        #endregion
    }
}