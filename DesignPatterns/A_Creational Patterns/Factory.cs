using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.A_Creational_Patterns
{
    public static class Factory
    {
        public static Car getCar(string type) 
        {
            switch (type)
            {
                case "S":
                    return new SedanCar();

                case "U":
                    return new SubUVCar();

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

        void printName();
    }

    public abstract class Car : ICar
    {
        public string Name { get; set; }

        public void printName()
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

    public class SubUVCar : Car
    {
        public SubUVCar()
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
