using DesignPatterns.A_Creational_Patterns;
using DesignPatterns.B_Structure_Patterns;
using DesignPatterns.C_Behavioral_Patterns;

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

            /*
             *  Create One Instance From Object and Create it on first Request it only and every request will get created static instance
             *  All Constructor must be private the only way to create instance from this class is over by GetInstance()
             *  Class Must be Sealed mean not inheritable
             */

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

            /*
             * Make Factory Class To Create Any Children Classes Depend on Some Parameters
             */

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

            /*
             *  Create Object that Depend on Multi Objects Like Invoice with Header and Details and Footer info
             */

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

            /*
             *  Clone Object from object with shallow or Deep Copy
             */

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

            #region Adapter Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Adapter Pattern ###");

            /*
             * Used as Converter from type to another or make wrapper from old class to adapte it to work as new class
             */

            //We Have SalaryCalculator to calc salary for Employee only and need to calc salary for supervisor

            var employee = new B_Structure_Patterns.Employee("ahmed", 2000);
            var supervisor = new Supervisor("mohammed", 1000);

            var adapter = new SalaryCalculatorAdapter();

            Console.WriteLine(adapter.Calculate_Salary(employee));
            Console.WriteLine(adapter.Calculate_Salary(supervisor));


            #endregion

            #region Facade Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Facade Pattern ###");

            /*
             * Used To Collect Multi Steps inside one step called (Facade)
             */

            var shoppingCart = new ShoppingCart();
            var facadeSaleOrder = new FacadeSaleOrder();

            shoppingCart.Items.Add(new CartItem { ItemId = 1, ItemName = "Item1", UnitPrice = 150, Quantity = 3 });
            shoppingCart.Items.Add(new CartItem { ItemId = 2, ItemName = "Item2", UnitPrice = 120.5, Quantity = 2 });
            shoppingCart.Items.Add(new CartItem { ItemId = 3, ItemName = "Item3", UnitPrice = 84.2, Quantity = 3 });

            facadeSaleOrder.CreateOrder(shoppingCart);

            #endregion

            #region Decorator Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Decorator Pattern ###");

            /*
             * Used To Add Functionality to another class without edit it
             */

            var smsService = new ConcreteSmsService();
            var emailDecorator = new SendSmsWithEmailDecorator("maxbayne@gmail.com");

            emailDecorator.SetService(smsService);
            Console.WriteLine(emailDecorator.SendSms(1, "01051545847", "Hello Decorator"));

            #endregion

            #region Proxy Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Proxy Pattern ###");

            /*
             * Make Access To Class over Proxy for security or filteration or caching and so on
             */

            var sendSmsProxy = new Proxy();

            Console.WriteLine(sendSmsProxy.SendSms(1, "01054544", "Iam User 1"));
            Console.WriteLine(sendSmsProxy.SendSms(2, "012454544", "Iam User 2"));
            Console.WriteLine(sendSmsProxy.SendSms(3, "01015454", "Iam User 3"));

            #endregion

            #region FlyWeight Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### FlyWeight Pattern ###");

            /*
             *  reuse cached objects and reuse it again without reCreating new instances , used dictionary as store inside memory
             *  we can use factory pattern with it
             */

            var player1 = FlyWeight.CreatePlayer("blue");

            player1.Name = "Ahmed";
            player1.Mission = "Kill Enemey";
            player1.Weapon = "AK47";
            player1.PrintInfo();
            
            var player2= FlyWeight.CreatePlayer("blue");
            player2.Mission = "Capture the Flag";
            player2.Weapon = "M4";
            player2.PrintInfo();

            #endregion

            #region Composite Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Composite Pattern ###");

            /*
             *  Make Tree of Objects
             */

            //Employees
            Composite.IEmployee ahmed = new Composite.Employee("Ahmed");
            Composite.IEmployee khalid = new Composite.Employee("Khalid");
            Composite.IEmployee mostafe = new Composite.Employee("Mostafa");
            Composite.IEmployee maxBayne = new Composite.Employee("MaxBayne");

            //Managers
            Composite.IEmployee mainManager = new Composite.Manager("MainManager", new() { ahmed, khalid });
            Composite.IEmployee branchManager = new Composite.Manager("BranchManager", new() { maxBayne, mostafe, ahmed });


            ahmed.GetDetails();

            mainManager.GetDetails();

            branchManager.GetDetails();

            #endregion

            #region Bridge Pattern
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Bridge Pattern ###");

            /*
             * Make Bridge Between Two Big Classes like (OperatingSystem <> Control) and if we modify any class not affect the other
             */

            var windows = new Windows();
            var button = new Button(windows);

            button.Click();

            button.OperatingSystem=new Linux();
            button.Click();

            #endregion

            Console.WriteLine("==============================================================================");

            Console.WriteLine("Behavioral Design Pattern");
            Console.WriteLine("==============================================================================");

            #region Chain Of Responsibility Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Chain Of Responsibility Pattern ###");

            /*
             * Send Request To Multi Handlers inside Chain and Each Handel Process Request if he can do it then will send Response other wise push it to the next handler inside the chain
            */

            //Create Handels
            var ceo = new Ceo("ceo mohammed");
            var vp = new Vp("vp mostafa", ceo);
            var director = new Director("Ahmed Director", vp);

            //Create Requests
            var conferenceRequest = new Request(RequestType.Conference, 0);
            var purchaseRequest = new Request(RequestType.Purchase, 1200);
            var purchaseHighRequest = new Request(RequestType.Purchase, 2500);

            //Path Request To Chain of Handelers
            director.HandelRequest(conferenceRequest);
            vp.HandelRequest(purchaseRequest);
            vp.HandelRequest(purchaseHighRequest);

            #endregion

            #region Observer Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Observer Pattern ###");

            /*
             * Observer act as subscriber for subject when subject updated then subject responsible to notify any subscripers on it
             */

            var subscriber1 = new Subscriber("ahmed");
            var subscriber2 = new Subscriber("khalid");
            var subscriber3 = new Subscriber("ali");

            var subject = new Subject("Newspaper");
            
            subject.Attach(subscriber1);
            subject.Attach(subscriber2);
            subject.Attach(subscriber3);

            subject.DoSomeLogic();

            #endregion

            #region Command Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Command Pattern ###");

            /*
             * Execute Command By Invoker From Sender to Receiver 
             */


            IInvoker invoker = new Invoker("osama");

            IReceiver receiverAhmed = new Receiver("ahmed");
            IReceiver receiverKhalid = new Receiver("kalid");
            IReceiver receiverMona = new Receiver("Mona");

            ICommand sendMoneyCmd = new SendMoneyToSingleCommand(receiverAhmed);
            ICommand sendMoneyCmd2 = new SendMoneyToSingleCommand(receiverKhalid);

            invoker.Invoke(sendMoneyCmd);
            invoker.Invoke(sendMoneyCmd2);
            #endregion

            #region Interpreter Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Interpreter Pattern ###");

            /*
             * Make Rules used to interpret some context from language to another
             */

            


            #endregion

            #region Iterator Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Iterator Pattern ###");

            /*
             * 
             */



            #endregion

            #region Mediator Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Mediator Pattern ###");

            /*
             * 
             */



            #endregion

            #region Memento Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Memento Pattern ###");

            /*
             * 
             */



            #endregion

            #region State Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### State Pattern ###");

            /*
             * 
             */



            #endregion

            #region Strategy Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Strategy Pattern ###");

            /*
             * 
             */



            #endregion

            #region Template Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Template Pattern ###");

            /*
             * 
             */



            #endregion

            #region Visitor Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Visitor Pattern ###");

            /*
             * 
             */



            #endregion

            Console.WriteLine("==============================================================================");

            Console.ReadKey();

        }
    }
}