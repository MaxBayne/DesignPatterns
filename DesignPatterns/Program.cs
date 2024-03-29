﻿using System.Numerics;
using DesignPatterns.A_Creational_Patterns;
using DesignPatterns.B_Structure_Patterns;
using DesignPatterns.C_Behavioral_Patterns;
using DesignPatterns.C_Behavioral_Patterns.OrderCommand;
using DesignPatterns.C_Behavioral_Patterns.StatePattern;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Creational Design Pattern");
            Console.WriteLine("==============================================================================");
            Console.WriteLine("deal with object creation and initialization");
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
            Singleton.GetInstance.Print_Message("Hello World");
            Singleton.GetInstance.Print_Message("How Are You");

            LogSingleton.GetInstance.Log_Message("Log my first message please");
            LogSingleton.GetInstance.Log_Message("Log my second message please");

            //For Multi Thread ----------------
            Console.WriteLine("\n(From Multi Thread)");

            //Try to Execute same code on two thread each different another
            Parallel.Invoke(() =>
            {
                Singleton.GetInstance.Print_Message("Hello World");
            },
            () =>
            {
                Singleton.GetInstance.Print_Message("How Are You");
            });

            #endregion

            #region Simple Factory Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Simple Factory Pattern ###");

            /*
             * Make Factory Class To Create Any Children Classes Depend on Some Parameters
             */

            var carFactory = new CarFactory();

            var sedan = carFactory.CreateCar("S");
            sedan.PrintName();

            var subuv = carFactory.CreateCar("U");
            subuv.PrintName();

            var truck = carFactory.CreateCar("T");
            truck.PrintName();

            var permanent = TeacherSimpleFactory.CreateTeacher(TeacherTypeEnum.Permanent);
            var contact = TeacherSimpleFactory.CreateTeacher(TeacherTypeEnum.Contract);
            var templorary = TeacherSimpleFactory.CreateTeacher(TeacherTypeEnum.Templorary);

            var salesInvoice = InvoiceFactory.CreateInvoice(InvoiceTypeEnum.Sales);
            var purchasesInvoice = InvoiceFactory.CreateInvoice(InvoiceTypeEnum.Purchases);

            #endregion

            #region Factory Method Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Factory Method Pattern ###");

            /*
             * Make Abstract Factory Class to create unknown classes with same family and let client implement that abstraction for more classes
             */


            var paypalPayment = new PaypalPaymentProcessor().ProcessPayment(1, 500);
            var visaPayment = new VisaPaymentProcessor().ProcessPayment(2, 1400);
            var masterPayment = new MasterPaymentProcessor().ProcessPayment(3, 4000);

            #endregion

            #region Builder Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Builder Pattern ###");

            /*
             *  Create Object that Depend on Multi Objects Like Invoice with Header and Details and Footer info
             */

            Console.WriteLine("\n Build Full Robot");
            Console.WriteLine("----------------");

            var fullRobot = new RobotBuilder()
                            .SetHead("Head of Robot")
                            .SetArms("Arms of Robot")
                            .SetLegs("Legs of Robot")
                            .Build();

            
            fullRobot.PrintInfo();


            Console.WriteLine("\nBuild Limited Robot");
            Console.WriteLine("---------------------");
            var limitedRobot = new RobotBuilder()
                                    .SetHead("Head of Robot")
                                    .SetLegs("Legs of Robot")
                                    .Build();
            
            
            limitedRobot.PrintInfo();


            Console.WriteLine("\nBuild Salary Calculator");
            Console.WriteLine("-------------------------");

            var salaryCalculator = new SalaryCalculatorBuilder().SetEmployeeId(100)
                                                                .SetBasicSalary(2000)
                                                                .SetTransportValue(500)
                                                                .SetEatsValue(250)
                                                                .SetTaxPercent(10)
                                                                .Build();

            salaryCalculator.PrintSalaryInfo();

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


            Console.WriteLine("Structural Design Pattern");
            Console.WriteLine("==============================================================================");
            Console.WriteLine("deal with class and object composition");
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

            var oldSmsSenderService = new SmsSenderService();
            var smsSenderServiceWithEmailDecorator = new SmsSenderServiceEmailingDecorator(oldSmsSenderService);
            var smsSenderServiceWithExceptionHandelDecorator = new SmsSenderServiceExceptionHandelDecorator(oldSmsSenderService);

            smsSenderServiceWithEmailDecorator.SendSms(100, "01091281295", "Hello Man iam Max bayne");

            smsSenderServiceWithExceptionHandelDecorator.SendSms(100, "", "Hello Man iam Max bayne");

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
            Console.WriteLine("deal with the communication between classes and objects");
            Console.WriteLine("==============================================================================");

            #region Chain Of Responsibility Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Chain Of Responsibility Pattern ###");

            /*
             * Send Request To Multi Handlers inside Chain and Each Handel Process Request if he can do it then will send Response other wise push it to the next handler inside the chain
            */

            //Create Requests
            var vacationRequest = new VacationRequest(RequestType.CTO, "Ahmed", DateTime.Now, 5);

            //Create Handels
            var teamLeaderHandler = new TeamLeaderHandler();
            var technicalLeaderHandler = new TechnicalLeadHandler();
            var ctoHandler = new CtoHandler();
            var ceoHandler = new CeoHandler();

            //Build Chain of Handlers that request will pass throw until found the handler that will handle it
            teamLeaderHandler.SetNextHandler(technicalLeaderHandler);
            technicalLeaderHandler.SetNextHandler(ctoHandler);
            ctoHandler.SetNextHandler(ceoHandler);

            //Pass Request to first handler inside chain
            teamLeaderHandler.ProcessRequest(vacationRequest);


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
             * Execute Command By Invoker 
             */

            //create Commands and store it inside list of command inside command invoker and just invoke them

            var order = new Order();

            //create commands
            var addOrderLineCommand = new AddOrderLineCommand(order,100,"Item1",15,100);
            var setCustomerCommand = new SetCustomerCommand(order, "Ahmed Ali");
            var printOrderLineCommand = new PrintOrderLineCommand(100, "Item1", 15, 100);

            //store commands inside list
            var commandsInvoker = new CommandsInvokers();
            commandsInvoker.AddCommand(addOrderLineCommand);
            commandsInvoker.AddCommand(setCustomerCommand);
            commandsInvoker.AddCommand(printOrderLineCommand);

            //invoke commands stored inside invoker
            commandsInvoker.InvokeCommands();


            #endregion

            #region Interpreter Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Interpreter Pattern ###");

            /*
             * Make Rules used to interpret some context from language to another
             */

            IExpression isMale = Interpreter.GetMaleExpressions();
            IExpression isFemale = Interpreter.GetFeMaleExpressions();
            IExpression isDoctor = Interpreter.GetDoctorExpressions();
            IExpression isTeacher = Interpreter.GetTeacherExpressions();


            Console.WriteLine($"ahmed is male ? {isMale.Interpret(new Context("ahmed"))}");
            Console.WriteLine($"mona is female ? {isFemale.Interpret(new Context("mona"))}");
            Console.WriteLine($"khalid is female ? {isFemale.Interpret(new Context("khalid"))}");
            Console.WriteLine($"ahmed is teacher ? {isTeacher.Interpret(new Context("teacher ahmed"))}");
            Console.WriteLine($"ahmed is doctor ? {isDoctor.Interpret(new Context("doctor ahmed"))}");

            #endregion

            #region Iterator Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Iterator Pattern ###");

            /*
             * Access element inside collection without dive inside the implementation or the type of collection or list
             */

            //list of collection
            var persons = new Aggregator<string>();
            persons.Add("Ahmed");
            persons.Add("Khalid");
            persons.Add("Ali");
            persons.Add("Mohammed");
            persons.Add("Mona");

            //iterate over collection elements using iterator
            var iterator = persons.Iterator;

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Current);
            }

            #endregion

            #region Mediator Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Mediator Pattern ###");

            /*
             * make object mediator between multi objects and not coupple objects with other
             */

            //multi objects
            var cabA = new Cab(1, "CabA", "Benha");
            var cabB = new Cab(2, "CabB", "Benha");
            var cabC = new Cab(3, "CabC", "Benha");

            //mediator
            var cabTower = new CabTower();
            cabTower.RegisterCab(cabA);
            cabTower.RegisterCab(cabB);
            cabTower.RegisterCab(cabC);

            cabTower.AskHelp(cabA,"hii my tear is below :(");
            cabTower.AskHelp(cabB, "hii my Gas is empty :(");



            #endregion

            #region Memento Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Memento Pattern ###");

            /*
             * Just store multi states inside list and can undo to go to this state like checkpoints in games  
             */

            var player = new Player("ahmed",25);

            //save memento state inside manager
            var manager = new Manager();
            manager.PushMemento(player.CreateMemento());

            Console.WriteLine("Initial state for Player");
            Console.WriteLine(player.ToString());

            //Change State of player and store it inside manager
            player.Name = "Khalid";
            player.Age = 35;
            manager.PushMemento(player.CreateMemento());

            Console.WriteLine("Change state for Player");
            Console.WriteLine(player.ToString());

            //Undo changes over player and restore previous state
            manager.PopMemento();
            player.UndoMemento(manager.PopMemento());


            Console.WriteLine("Undo Changes of state for Player");
            Console.WriteLine(player.ToString());


            #endregion

            #region State Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### State Pattern ###");
            /*
            * Make State Machine from object and save this state inside it
            */

            var vehicle = new Vehicle();

            vehicle.StartVehicle();

            vehicle.AccelerateVehicle();

            vehicle.StopVehicle();

            Console.WriteLine("");
            ///////////////////////////////////

            var myOrder = new Order();

            myOrder.SetCustomer("Mohammed Salah");

            myOrder.AddOrderLine(100, "Item1", 5, 1200);
            myOrder.AddOrderLine(200, "Item2", 3, 4100);
            myOrder.AddOrderLine(300, "Item3", 2, 500);

            myOrder.CancelOrder();

            myOrder.ConfirmOrder();

            myOrder.ProcessOrder();

            myOrder.ShippedOrder();

            myOrder.DeliverOrder();

            myOrder.ReturnOrder();

            #endregion

            #region Strategy Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Strategy Pattern ###");

            /*
             * if we have multi algorithm family and need to select one from family to execute like sorting methods
             */

            var bmwStrategy=new BmwStrategy();
            var toyotaStrategy = new ToyotaStrategy();

            var mechanic = new Mechanic();

            mechanic.DisassembleCar(toyotaStrategy);
            mechanic.DisassembleCar(bmwStrategy);


            //Select Discount Depend on Customer Category inside Invoice
            new Invoice("Mohammed Salah", CustomerCategoryEnum.Simple, 15000).Print_Invoice_Info();
            new Invoice("Ahmed Ali", CustomerCategoryEnum.Silver, 9000).Print_Invoice_Info();
            new Invoice("Mona Adel", CustomerCategoryEnum.Gold, 17000).Print_Invoice_Info();
            new Invoice("Mostafa Magdi", CustomerCategoryEnum.Diamond, 20000).Print_Invoice_Info();



            #endregion

            #region Template Pattern

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("### Template Pattern ###");

            /*
             * when we have shared steps and only few steps are changed then we use this pattern
             */

            var onlineShopping = new OnlineShoppingCart("Ahmed Salah", CustomerCategoryEnum.Gold);
            var onStoreShopping = new InStoreShoppingCart("Mido Ali", CustomerCategoryEnum.Silver);

            onlineShopping.Checkout(10000);
            onStoreShopping.Checkout(5000);

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