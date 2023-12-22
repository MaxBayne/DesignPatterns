#pragma warning disable CS8618
namespace DesignPatterns.A_Creational_Patterns
{
    #region Car Factory

    public interface ICarFactory
    {
        ICar CreateCar(string type);
    }

    public class CarFactory: ICarFactory
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
            else if(teacherType == TeacherTypeEnum.Contract)
            {
                teacher = new ContractTeacher("ali");
                teacher.PayHour = 50;
                teacher.Bonus = 40;
            }
            else if(teacherType == TeacherTypeEnum.Templorary)
            {
                teacher = new TemploraryTeacher("mosafa");
                teacher.PayHour = 10;
                teacher.Bonus = 10;
            }
           

            return teacher;
        }
    }

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
}
