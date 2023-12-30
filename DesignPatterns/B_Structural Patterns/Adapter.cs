using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.B_Structure_Patterns
{
    /// <summary>
    /// used to convert type to another type that required for some functions
    /// ReShape Old Class to New Class without editing old class
    /// </summary>
    /// 

    #region Adapter By Inheritance

    //Legacy Logic
    public class SalaryCalculator
    {
        public string CalculateSalary(Employee employee)
        {
            return $"The Salary of Employee ({employee.Name}) is {employee.Salary * 1.5}";
        }
    }

    //New Logic by Adapter
    public class SalaryCalculatorAdapter : SalaryCalculator
    {
        public string Calculate_Salary(Supervisor supervisor)
        {
            var emp = new B_Structure_Patterns.Employee(supervisor.Name,supervisor.Salary);

            return CalculateSalary(emp);
        }

        public string Calculate_Salary(Employee employee)
        {
            return CalculateSalary(employee);
        }
    }

    public class Employee
    {
        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
    }
    public class Supervisor
    {
        public Supervisor(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
    }

    #endregion

    #region Adapter by Composition

    #endregion
}
