using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class Person
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

        private string contactNumber;
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
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

        public Person(string name, string surname, int age, string homeAddress, string contactNumber, string education)
        {
            Name = name;
            Surname = surname;
            Age = age;
            HomeAddress = homeAddress;
            ContactNumber = contactNumber;
            Education = education;
        }
    }
}
