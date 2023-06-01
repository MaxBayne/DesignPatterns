using DesignPatterns.A_Creational_Patterns;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Creational Design Pattern");
            Console.WriteLine("==============================================================================");

            #region Singleton Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Singleton Pattern ###");


            //For Single Thread ----------------
            Console.WriteLine("\n(From Single Thread)");
            Get_Singleton_1();
            Get_Singleton_2();
            
            //For Multi Thread ----------------
            Console.WriteLine("\n(From Multi Thread)");
            Parallel.Invoke(Get_Singleton_1, Get_Singleton_2);

            #endregion

            #region Factory Pattern
            
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Factory Pattern ###");

            var factory = new Factory();

            var sedan = factory.CreateCar("S");
            sedan.PrintName();

            var subuv = factory.CreateCar("U");
            subuv.PrintName();

            var truck = factory.CreateCar("T");
            truck.PrintName();

            #endregion

            #region Builder Pattern
            
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Builder Pattern ###");

            var robotBuilder = new Builder(new Robot());
            var builtedRobot = robotBuilder.BuildRobot();
            
            builtedRobot.PrintInfo();

            #endregion

            #region Prototype Pattern
            
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Prototype Pattern ###");

            var emp1 = new RegularEmployee();
            var shallowCopy = emp1.ShallowCopy();
            var deepCopy = emp1.DeepCopy();

            Console.WriteLine($"emp1 (Original) => {emp1}");
            Console.WriteLine($"emp1 (shallow)  => {shallowCopy} \n");
            Console.WriteLine("Try Change shallow Copy by change Name to Ahmed and Address to Giza , On Original Value Types Not Effected (Id,Name),Reference Types (Address) Will Effected because its reference");

            shallowCopy.Name = "Ahmed";
            shallowCopy.Address.Street = "Giza";

            Console.WriteLine($"emp1 (Original) => {emp1}");
            Console.WriteLine($"emp1 (shallow)  => {shallowCopy} \n");

            Console.WriteLine($"emp1 (Original) => {emp1}");
            Console.WriteLine($"emp1 (Deep)  => {deepCopy} \n");

            Console.WriteLine("Try Change Deep Copy by change Name to Khalid And Address to Benha,On Original Value Types Not Effected (Id,Name),Reference Types (Address) Not Effected");
            deepCopy.Name = "Kalid";
            deepCopy.Address.Street = "Benha";

            Console.WriteLine($"emp1 (Original) => {emp1}");
            Console.WriteLine($"emp1 (Deep)  => {deepCopy}");

            Console.WriteLine("--------------------------------------------------------------");

            #endregion

            Console.WriteLine("==============================================================================");


            Console.WriteLine("Structure Design Pattern");
            Console.WriteLine("==============================================================================");

            #region Proxy Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Proxy Pattern ###");



            #endregion

            Console.WriteLine("==============================================================================");





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