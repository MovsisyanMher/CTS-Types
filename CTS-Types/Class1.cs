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

        public override string ToString()
        {
            return "Programmer " + base.ToString();
        }
    }


    public interface IEmployed
    {
        int Salary { get; set; }
        string Workplace { get; set; }
    }


    public struct Int32Phys
    {
        /// <summary>
        /// Value without physical descrptions and properties
        /// </summary>
        public int Value { get; set; }


        /// <summary>
        /// Units of kg (e.g. 1000 kg => Value == 1000 and kg == 1)
        /// can be 0 (e.g 32 seconds => Value == 32 and kg == 0)
        /// can be negative (e.g. 100$ per kg => Value == 10000 (cents) and kg == -1)
        /// </summary>
        public short Kg      { get; }

        public short Meters  { get; }

        public short Seconds { get; }

        public short Ampere  { get; }

        public short Kelvin  { get; }

        public short Mol     { get; }

        public short Candela { get; }

        public short Cent    { get; }

        public short Radian  { get; }

        public override string ToString()
        {
            return Value + 
                (Kg == 0 ?      System.String.Empty : " kg^"    + Kg)      + 
                (Meters == 0 ?  System.String.Empty : " m^"     + Meters)  + 
                (Seconds == 0 ? System.String.Empty : " s^"     + Seconds) + 
                (Ampere == 0 ?  System.String.Empty : " A^"     + Ampere)  +
                (Kelvin == 0 ?  System.String.Empty : " K^"     + Kelvin)  +
                (Mol == 0 ?     System.String.Empty : " mol^"   + Mol)     +
                (Candela == 0 ? System.String.Empty : " cd^"    + Candela) +
                (Radian == 0 ?  System.String.Empty : " rad^"   + Radian)  +
                (Cent == 0 ?    System.String.Empty : " cents^" + Cent);
        }



        public Int32Phys(int Value) : this(Value, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        {}

        public Int32Phys(int Value, short Kg, short Meters, short Seconds, short Ampere, short Kelvin, short Mol, short Candela, short Cents, short Radians)
        {
            this.Value   = Value;
            this.Kg      = Kg;
            this.Meters  = Meters;
            this.Seconds = Seconds;
            this.Ampere  = Ampere;
            this.Kelvin  = Kelvin;
            this.Mol     = Mol;
            this.Candela = Candela;
            this.Cent    = Cents;
            this.Radian  = Radians;
        }
    }


    public enum AccessCode
    {
        Owner,
        Investor,
        Accounting,
        Management,
        Employee,
        Client,
        Guest
    }

    public delegate string Msg(System.Collections.Generic.List<object> List);

    public struct CTSDataTypes
    {
        public byte MyByte { get; set; }
        public sbyte MySignedByte { get; set; }
        public short MyShort { get; set; }
        public int MyInt { get; set; }
        public long MyLong { get; set; }
        public ushort MyUnsignedShort { get; set; }
        public uint MyUnsignedInt { get; set; }
        public ulong MyULong { get; set; }
        public float MyFloat { get; set; }
        public double MyDouble { get; set; }
        public object MyObject { get; set; }
        public char MyChar { get; set; }
        public string MyString { get; set; }
        public decimal MyDecimal { get; set; }
        public bool MyBool { get; set; }
    }
}