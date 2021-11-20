using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class Employee : Person, IComparable<Employee>, ICloneable
    {
        private EnumVacation job;
        public EnumVacation Job
        {
            get { return job; }
            set { job = value; }
        }
        public Employee(string name, string surname, int age, EnumVacation job, string homeAddress, string contactNumber, string education) : base(name, surname, age, homeAddress, contactNumber, education)
        {
            Job = job;
        }
        public int CompareTo(Employee e)
        {
            return this.Age.CompareTo(e.Age);
        }
        public object Clone()
        {
            return new Employee(
                Name = this.Name,
                Surname = this.Surname,
                Age = this.Age,
                Job = this.Job,
                HomeAddress = this.HomeAddress,
                ContactNumber = this.ContactNumber,
                Education = this.Education
            );
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Employee e = obj as Employee;
            if (e as Employee == null)
            {
                return false;
            }
            return e.Age == this.Age;
        }
        public bool Equals(Employee e)
        {
            if (e == null)
            {
                return false;
            }
            return e.Age == this.Age;
        }
        public override int GetHashCode()
        {
            int unitCode;
            if (Age < 18)
                unitCode = 1;
            else unitCode = 2;
            return unitCode + Age;
        }
    }
}
