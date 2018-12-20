namespace CTS_Types
{
    public abstract class Person
    {
        public string Name { get; set; }

        public System.Guid Id { get; }

        public Person(string Name)
        {
            this.Name = Name;
            Id = System.Guid.NewGuid();
        }
        
    }

    public class Employee : Person
    {
        public Employee(string Name) : base(Name){}

        public Employee(string Name, int Salary) : base(Name)
        {
            this.Salary = Salary;
        }

        /// <summary>
        /// Salary in USD cents
        /// </summary>
        public int Salary { get; set; }


        public override bool Equals(object obj)
        {
            try
            {
                var person = obj as Person;
                if (person.Id == Id) return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public sealed class Programmer : Employee
    {
        public Programmer(string Name) : base(Name)
        {

        }

        public Programmer(string Name, int Salary) : base(Name, Salary)
        {

        }


    }
}
