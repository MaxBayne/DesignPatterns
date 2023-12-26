#pragma warning disable CS8618

namespace DesignPatterns.A_Creational_Patterns
{

    #region Robot Builder

    public class Robot
    {
        public Robot(string head, string arms, string legs)
        {
            Head = head;
            Arms = arms;
            Legs = legs;
        }

        public string Head { get; private set; }
        public string Arms { get; private set; }
        public string Legs { get; private set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Head= {Head}");
            Console.WriteLine($"Arms= {Arms}");
            Console.WriteLine($"Legs= {Legs}");
        }
    }

    public class RobotBuilder
    {
        private string _head;
        private string _arms;
        private string _legs;

        public RobotBuilder SetHead(string head)
        {
            _head = head;
            return this;
        }

        public RobotBuilder SetArms(string arms)
        {
            _arms = arms;
            return this;
        }

        public RobotBuilder SetLegs(string legs)
        {
            _legs = legs;
            return this;
        }

        //Build the final Instance of Builder as Robot
        public Robot Build()
        {
            //Make Any Validation

            //Return Robot
            return new Robot(_head,_arms,_legs);
        }
    }

    #endregion

    #region Salary Calculator Builder

    public class SalaryCalculator
    {
        public SalaryCalculator(int employeeId,double basicSalary,double transportValue,double eatsValue,double taxPercent,double discountValue)
        {
            EmployeeId = employeeId;
            BasicSalary = basicSalary;
            TransportValue = transportValue;
            EatsValue = eatsValue;
            TaxPercent = taxPercent;
            DiscountValue = discountValue;
        }

        public int EmployeeId { get; private set; }
        public double BasicSalary { get; private set; }
        public double TransportValue { get; private set;}
        public double EatsValue { get; private set; }
        public double TaxPercent { get; private set; }
        public double DiscountValue { get; private set; }
        public double NetSalary => CalculateNetSalary();


        private double CalculateNetSalary()
        {
            var AddedValues = TransportValue + EatsValue;
            var SubValues = (BasicSalary * TaxPercent / 100) + DiscountValue;

            var netSalary = BasicSalary + AddedValues - SubValues;

            return netSalary;
        }

        public void PrintSalaryInfo()
        {
            Console.WriteLine($"Employee #{EmployeeId} with Basic Salary={BasicSalary},TransportValue={TransportValue},EatsValue={EatsValue},TaxPercent={TaxPercent},DiscountValue={DiscountValue} has Net Salary = ({NetSalary})");
        }
    }

    public class SalaryCalculatorBuilder
    {
        private int _employeeId;
        private double _basicSalary;
        private double _transportValue;
        private double _eatsValue;
        private double _taxPercent;
        private double _discountValue;

        public SalaryCalculatorBuilder SetEmployeeId(int employeeId)
        {
            _employeeId = employeeId;
            return this;
        }

        public SalaryCalculatorBuilder SetBasicSalary(double basicSalary)
        {
            _basicSalary = basicSalary;
            return this;
        }
        public SalaryCalculatorBuilder SetTransportValue(double transportValue)
        {
            _transportValue = transportValue;
            return this;
        }
        public SalaryCalculatorBuilder SetEatsValue(double eatsValue)
        {
            _eatsValue = eatsValue;
            return this;
        }
        public SalaryCalculatorBuilder SetTaxPercent(double taxPercent)
        {
            _taxPercent = taxPercent;
            return this;
        }
        public SalaryCalculatorBuilder SetDiscountValue(double discountValue)
        {
            _discountValue = discountValue;
            return this;
        }


        public SalaryCalculator Build()
        {
            return new SalaryCalculator(_employeeId, _basicSalary, _transportValue, _eatsValue, _taxPercent, _discountValue);
        }

    }


    #endregion
}
