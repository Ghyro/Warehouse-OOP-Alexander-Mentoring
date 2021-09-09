using System;

namespace WarehouseLibrary
{
    public class Warehouse
    {
        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        private string address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        private string contactNumbers;
        public string ContactNumber
        {
            get
            {
                return contactNumbers;
            }
            set
            {
                contactNumbers = value;
            }
        }

        private int vacations;
        public int Vacations
        {
            get { return vacations; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                vacations = value;
            }
        }

        private Employee[] employees;
        public Employee[] Employees
        {
            get
            {
                return employees;
            }
            set
            {
                if (employees == null)
                {

                }
                employees = value;
            }
        }

        private int numOfEmployed;
        public int NumOfEmployed
        {
            get { return numOfEmployed; }
            set { numOfEmployed = value; }
        }

        public Warehouse(string Title, string Address, string ContactNumbers, int Vacations)
        {
            this.Title = Title;
            this.Address = Address;
            //this.ContactNumbers = ContactNumbers; //почему Ошибка?
            this.Vacations = Vacations;
        }
        public Warehouse(string Title, string Address, string ContactNumbers)
        {
            Vacations = 5;
        }

    }
}