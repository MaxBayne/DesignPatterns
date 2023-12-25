#pragma warning disable CS8618
namespace DesignPatterns.A_Creational_Patterns
{
    /*
     * Factory Method
     * - mean make the creation of some classes with same family (implement same interface or inherit same base class) from one place , if u have some classes with varient conditions for creating 
     * this classes u can make centeral location that responsable for creatng this class and when i want to change the logic i will change 
     * inside center location (factory)
     * 
     * Example :
     * if we have bsae class or interface called invoice and some sub classess called (PurchaseInvoice-SalesInvoice etc..) and we need to make
     * factory method used to create invoice depend on condition like type of invoice so we will use InvoiceFactory class have method called
     * CreateInvoice(InvoiceType) and return IInvoice base class
     */

    #region Car Factory

    #region Factory


    public interface ICarFactory
    {
        ICar CreateCar(string type);
    }

    public class CarFactory : ICarFactory
    {
        public ICar CreateCar(string type)
        {
            switch (type)
            {
                case "S":
                    return new SedanCar();

                case "U":
                    return new SubUvCar();

                case "T":
                    return new TruckCar();

                default:
                    return new SedanCar();
            }
        }
    }

    #endregion



    public interface ICar
    {
        string Name { get; set; }

        void PrintName();
    }

    public abstract class Car : ICar
    {
        public string Name { get; set; }

        public void PrintName()
        {
            Console.WriteLine(Name);
        }

    }

    public class SedanCar:Car
    {
        public SedanCar()
        {
            Name = "Sedan";
        }
    }

    public class SubUvCar : Car
    {
        public SubUvCar()
        {
            Name = "SubUV";
        }
    }

    public class TruckCar : Car
    {
        public TruckCar()
        {
            Name = "Truck";
        }
    }

    #endregion

    #region Employee Factory

    #region Factory

    public class TeacherFactory
    {
        public static ITeacher? CreateTeacher(TeacherTypeEnum teacherType)
        {
            ITeacher? teacher = null;

            if (teacherType == TeacherTypeEnum.Permanent)
            {
                teacher = new PermanentTeacher("ahmed");
                teacher.PayHour = 100;
                teacher.Bonus = 50;
            }
            else if (teacherType == TeacherTypeEnum.Contract)
            {
                teacher = new ContractTeacher("ali");
                teacher.PayHour = 50;
                teacher.Bonus = 40;
            }
            else if (teacherType == TeacherTypeEnum.Templorary)
            {
                teacher = new TemploraryTeacher("mosafa");
                teacher.PayHour = 10;
                teacher.Bonus = 10;
            }


            return teacher;
        }
    }

    #endregion


    public enum TeacherTypeEnum
    {
        Permanent=0,
        Contract=1,
        Templorary=2
    }

    public interface ITeacher
    {
        string Name { get; set; }
        TeacherTypeEnum TeacherType { get; set; }

        decimal Bonus { get; set; }
        decimal PayHour { get; set; }
    }

    public abstract class Teacher : ITeacher
    {
        public string Name { get; set; }
        public TeacherTypeEnum TeacherType { get; set; }

        public decimal PayHour { get; set; }
        public decimal Bonus { get; set; }
    }

    public class PermanentTeacher: Teacher
    {
        public PermanentTeacher(string name)
        {
            Name = name;
            TeacherType = TeacherTypeEnum.Permanent;
        }
    }

    public class ContractTeacher: Teacher
    {
        public ContractTeacher(string name)
        {
            Name = name;
            TeacherType = TeacherTypeEnum.Contract;
        }
    }

    public class TemploraryTeacher: Teacher
    {
        public TemploraryTeacher(string name)
        {
            Name = name;
            TeacherType = TeacherTypeEnum.Templorary;
        }
    }


    #endregion

    #region Invoice Factory

    #region Factory

  
    public static class InvoiceFactory
    {
        public static IInvoice CreateInvoice(InvoiceTypeEnum invoiceType)
        {
            IInvoice? invoice;

            switch (invoiceType)
            {
                case InvoiceTypeEnum.Sales:
                    invoice = new SalesInvoice();
                    break;

                case InvoiceTypeEnum.Purchases:
                    invoice = new PurchaseInvoice();
                    break;

                case InvoiceTypeEnum.ReturnSales:
                    invoice = new ReturnSalesInvoice();
                    break;

                case InvoiceTypeEnum.ReturnPurchases:
                    invoice = new ReturnPurchaseInvoice();
                    break;

                default:
                    invoice = new SalesInvoice();
                    break;
            }

            return invoice;
        }
    }

    #endregion

    public enum InvoiceTypeEnum
    {
        Sales,
        Purchases,

        ReturnSales,
        ReturnPurchases
    }

    public interface IInvoice
    {
        string InvoiceNo { get; set; }
        DateTime InvoiceDate { get; set; }
        string InvoiceNotes { get; set; }

        InvoiceTypeEnum InvoiceType { get; set; }
    }

    /// <summary>
    /// فاتورة
    /// </summary>
    public abstract class BaseInvoice : IInvoice
    {
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNotes { get; set; }
        public InvoiceTypeEnum InvoiceType { get; set; }
    }

    /// <summary>
    /// فاتورة مشتريات
    /// </summary>
    public class PurchaseInvoice:BaseInvoice
    {
        public string SupplierName { get; set; }

    }

    /// <summary>
    /// فاتورة مبيعات
    /// </summary>
    public class SalesInvoice : BaseInvoice
    {
        public string CustomerName { get; set; }
        public decimal Discount { get; set; }
    }

    /// <summary>
    /// فاتورة مرتجع مشتريات
    /// </summary>
    public class ReturnPurchaseInvoice : BaseInvoice
    {
        public string SupplierName { get; set; }
        public DateTime ReturnedOn { get; set; }
        public string ReasonOfReturn { get; set; }
    }

    /// <summary>
    /// فاتورة مرتجع مبيعات
    /// </summary>
    public class ReturnSalesInvoice : BaseInvoice
    {
        public string CustomerName { get; set; }
        public DateTime ReturnedOn { get; set; }
        public string ReasonOfReturn { get; set; }
    }

    #endregion
}
