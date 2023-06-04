namespace DesignPatterns.B_Structure_Patterns;

public class Composite
{
    public interface IEmployee
    {
        string Name { get; set; }
        void GetDetails();
    }

    public class Employee:IEmployee 
    {
        public string Name { get; set; }

        public Employee(string name)
        {
            Name=name;
        }

        public void GetDetails()
        {
            Console.WriteLine($"Employee ({Name}) - Leaf");
        }
    }

    public class Manager:IEmployee
    {
        public string Name { get; set; }

        public List<IEmployee> SubEmployees { get; set; }

        public Manager(string name,List<IEmployee> subEmployees)
        {
            Name=name;
            SubEmployees=subEmployees;
        }

        public void GetDetails()
        {
            Console.WriteLine($"Employee ({Name}) - Composite");

            foreach (var employee in SubEmployees)
            {
                employee.GetDetails();
            }
        }
    }
}