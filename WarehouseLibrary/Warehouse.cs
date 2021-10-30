using System;

namespace WarehouseLibrary
{
    public class Warehouse : IComparable<Warehouse>, IHasId,IWarehouseServicses,ICommonServises
    {
        public int CompareTo(Warehouse w)
        {
            return this.Title.CompareTo(w.Title);
        }

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
                employees = value;
            }
        }

        private Guid id;
        public Guid Id
        {
            get { return id; }
            internal set { id = value; }
        }

        public Warehouse(string Title, string Address, string ContactNumber, int Vacations)
        {
            this.Title = Title;
            this.Address = Address;
            this.ContactNumber = ContactNumber;
            this.Vacations = Vacations;
            this.Employees = new Employee[0];
        }
        public void UpdateVacation(int numVacations)
        {
            this.Vacations = numVacations;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Warehouse w = obj as Warehouse;
            if (w as Warehouse == null)
            {
                return false;
            }
            return w.Title == this.Title;
        }
        public bool Equals(Warehouse warehouse)
        {
            if (warehouse == null)
            {
                return false;
            }
            return warehouse.Title == this.Title;
        }
        public override int GetHashCode()
        {
            int unitCode;
            if (Title.Length < 10)
                unitCode = 1;
            else unitCode = 2;
            return Title.Length + unitCode;
        }
    }
}