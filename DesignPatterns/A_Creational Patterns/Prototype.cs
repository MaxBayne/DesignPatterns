#pragma warning disable CS8618
namespace DesignPatterns.A_Creational_Patterns
{
    public class Address
    {
        public Address()
        {
            Street = string.Empty;
            PostalCode = string.Empty;
        }

        public string Street { get; set; }
        public string PostalCode { get; set; }
    }

    public abstract class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        /// <summary>
        /// Copy All Value Types like (int, decimal,bool) and let Reference Types like (String,Array,Classes) as it
        /// </summary>
        /// <returns></returns>
        public abstract Employee ShallowCopy();

        /// <summary>
        /// Copy All Value Types like (int, decimal,bool) and reNew all Reference Types like (String,Array,Classes)
        /// </summary>
        /// <returns></returns>
        public abstract Employee DeepCopy();

        public override string ToString()
        {
            return $"Id={Id},Name={Name},Street={Address.Street}";
        }
    }

    public class RegularEmployee : Employee
    {
        public RegularEmployee()
        {
            Id = 100;
            Name = "Regular Employee";
            Address = new Address()
            {
                Street = "Street 1",
                PostalCode = "0001"
            };
        }

        public override Employee ShallowCopy()
        {
            return (RegularEmployee)MemberwiseClone();
        }

        public override Employee DeepCopy()
        {
            //Copy With Shallow
            var deepCopy = (RegularEmployee)MemberwiseClone();

            //ReNew Reference Values
            deepCopy.Address = new Address()
            {
                Street = Address.Street,
                PostalCode = Address.PostalCode
            };

            //Return Deep Copy
            return deepCopy;
        }
    }

    public class TempEmployee : Employee
    {
        public TempEmployee()
        {
            Id = 200;
            Name = "Temp Employee";
            Address = new Address()
            {
                Street = "Street 2",
                PostalCode = "0002"
            };
        }

        public override Employee ShallowCopy()
        {
            return (TempEmployee)MemberwiseClone();
        }

        public override Employee DeepCopy()
        {
            //Copy With Shallow
            var deepCopy = (TempEmployee)MemberwiseClone();

            //ReNew Reference Values
            deepCopy.Address = new Address()
            {
                Street = Address.Street,
                PostalCode = Address.PostalCode
            };

            //Return Deep Copy
            return deepCopy;
        }
    }

}
