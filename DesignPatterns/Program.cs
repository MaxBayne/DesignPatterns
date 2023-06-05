using DesignPatterns.A_Creational_Patterns;
using DesignPatterns.B_Structure_Patterns;

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
            Singleton.Instance.Print_Message("Hello World");
            Singleton.Instance.Print_Message("How Are You");

            
            
            //For Multi Thread ----------------
            Console.WriteLine("\n(From Multi Thread)");
            Parallel.Invoke(() =>
            {
                Singleton.Instance.Print_Message("Hello World");
            },
                () =>
                {
                    Singleton.Instance.Print_Message("How Are You");
                });

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


            Console.WriteLine("\n Build Full Robot");
            Console.WriteLine("----------------");

            var fullRobot = new RobotBuilder(new Robot())
                            .SetHead("Head of Robot")
                            .SetArms("Arms of Robot")
                            .SetLegs("Legs of Robot")
                            .Build();

            
            fullRobot.PrintInfo();


            Console.WriteLine("\nBuild Limited Robot");
            Console.WriteLine("---------------------");
            var limitedRobot = new RobotBuilder(new Robot())
                                    .SetHead("Head of Robot")
                                    .SetLegs("Legs of Robot")
                                    .Build();
            
            
            limitedRobot.PrintInfo();

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

            var sendSmsProxy = new Proxy();

            Console.WriteLine(sendSmsProxy.SendSms(1, "01054544", "Iam User 1"));
            Console.WriteLine(sendSmsProxy.SendSms(2, "012454544", "Iam User 2"));
            Console.WriteLine(sendSmsProxy.SendSms(3, "01015454", "Iam User 3"));

            #endregion

            #region Decorator Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Decorator Pattern ###");

            //Used To Add Functionality to another class without edit it

            var smsService = new ConcreteSmsService();
            var emailDecorator = new SendSmsWithEmailDecorator("maxbayne@gmail.com");

            emailDecorator.SetService(smsService);
            Console.WriteLine(emailDecorator.SendSms(1, "01051545847", "Hello Decorator"));

            #endregion

            #region Adapter Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Adapter Pattern ###");

            //Used as Converter from type to another

            //We Have SalaryCalculator to calc salary for Employee only and need to calc salary for supervisor

            var employee = new B_Structure_Patterns.Employee("ahmed",2000);
            var supervisor = new Supervisor("mohammed", 1000);

            var adapter = new SalaryCalculatorAdapter();

            Console.WriteLine(adapter.Calculate_Salary(employee));
            Console.WriteLine(adapter.Calculate_Salary(supervisor));


            #endregion

            #region Facade Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Facade Pattern ###");

            //Used To Collect Multi Steps inside one step

            var shoppingCart = new ShoppingCart();
            var facadeSaleOrder = new FacadeSaleOrder();

            shoppingCart.Items.Add(new CartItem { ItemId=1,ItemName="Item1",UnitPrice=150,Quantity=3 });
            shoppingCart.Items.Add(new CartItem { ItemId = 2, ItemName = "Item2", UnitPrice = 120.5, Quantity = 2 });
            shoppingCart.Items.Add(new CartItem { ItemId = 3, ItemName = "Item3", UnitPrice = 84.2, Quantity = 3 });

            facadeSaleOrder.CreateOrder(shoppingCart);

            #endregion

            #region Composite Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Composite Pattern ###");

            //Employees
            Composite.IEmployee ahmed=new Composite.Employee("Ahmed");
            Composite.IEmployee khalid = new Composite.Employee("Khalid");
            Composite.IEmployee mostafe = new Composite.Employee("Mostafa");
            Composite.IEmployee maxBayne = new Composite.Employee("MaxBayne");

            //Managers
            Composite.IEmployee mainManager = new Composite.Manager("MainManager",new(){ahmed,khalid});
            Composite.IEmployee branchManager = new Composite.Manager("BranchManager", new() { maxBayne, mostafe,ahmed });


            ahmed.GetDetails();

            mainManager.GetDetails();

            branchManager.GetDetails();

            #endregion

            #region FlyWeight Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### FlyWeight Pattern ###");

            

            #endregion

            Console.WriteLine("==============================================================================");





            Console.ReadKey();
        }
    }
}