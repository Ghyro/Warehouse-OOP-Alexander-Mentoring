using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class Employee
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private int age;
        public int Age
        {
            get { return age; ; }
            set { age = value; }
        }

        private EnumVacation job;
        public EnumVacation Job
        {
            get { return job; }
            set { job = value; }
        }

        private string homeAddress;
        public string HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }

        private string contactNumber;
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        private string education;
        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        public Employee(string Name, string Surname, int Age, EnumVacation Job, string HomeAddress, string ContactNumber, string Education)
        {
            
        }
        public Employee(string Surname, int Age, EnumVacation Job, string ContactNumber)
        {
            string Name = string.Empty;
            string Education = string.Empty;
        }
        public Employee(string Name, string Surname, int Age, EnumVacation Job, string ContactNumber)
        {
            string HomeAddress = string.Empty;
            string Education = string.Empty;
        }
        public Employee(string Name, string Surname, int Age, EnumVacation Job, string ContactNumber, string Education)
        {
            string HomeAddress = string.Empty;
        }
        public Employee(string Surname, EnumVacation Job, string ContactNumber)
        {
            string Name = string.Empty;
            string HomeAddress = string.Empty;
            string Education = string.Empty;
        }
    }
}
