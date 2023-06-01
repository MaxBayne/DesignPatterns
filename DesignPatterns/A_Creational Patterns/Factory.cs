#pragma warning disable CS8618
namespace DesignPatterns.A_Creational_Patterns
{
    public interface IFactory
    {
        ICar CreateCar(string type);
    }

    public class Factory: IFactory
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
       

}
