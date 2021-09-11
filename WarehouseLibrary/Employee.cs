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

        public Employee(string name, string surname, int age, EnumVacation job, string homeAddress, string contactNumber, string education)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.Job = job;
            this.HomeAddress = homeAddress;
            this.ContactNumber=contactNumber;
            this.Education = education;
        }
    }
}
