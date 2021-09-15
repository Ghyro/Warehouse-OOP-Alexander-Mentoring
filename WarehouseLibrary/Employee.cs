using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class Employee : Person
    {
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


        private string education;
        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        public Employee(string name, string surname, int age, EnumVacation job, string homeAddress, string contactNumber, string education) : base(name, surname, age, contactNumber)
        {
            Job = job;
            HomeAddress = homeAddress;
            Education = education;
        }
    }
}
