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

        private string contactNumber;
        public string ContactNumber
        {
            get
            {
                return contactNumber;
            }
            set
            {
                contactNumber = value;
            }
        }

        private int vacations;
        public int Vacations
        {
            get { return vacations; }
            private set
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

        public Warehouse(string Title, string Address, string ContactNumber, int Vacations)
        {
            this.Title = Title;
            this.Address = Address;
            this.ContactNumber = ContactNumber;
            this.Vacations = Vacations;
        }
        public void UpdateVacation(int numVacations)
        {
            this.Vacations = numVacations;
        }
    }
}