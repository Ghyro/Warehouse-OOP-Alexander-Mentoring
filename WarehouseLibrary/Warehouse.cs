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

        /// <summary>
        /// Take object "Warehouse" and add info on it;
        /// </summary>
        /// <param name="myWarehouses"></param>
        /// <returns>Object with info;</returns>
        public Warehouse addInfo(Warehouse myWarehouse) // изначально я хотел метод который принимает массив объектов и добавляет в него объект.
        {
            Console.WriteLine("Enter title of your warehouse");
            myWarehouse.Title = Console.ReadLine();
            Console.WriteLine("Enter address of your warehouse");
            myWarehouse.Address = Console.ReadLine();
            Console.WriteLine("Enter contact number of your warehouse");
            myWarehouse.ContactNumber = Console.ReadLine();
            return myWarehouse;
        }

        /// <summary>
        /// Display object info;
        /// </summary>
        /// <param name="myWarehouse">Array of objects Warehouses</param>
        public void displayInfo(Warehouse myWarehouse)
        {
            Console.WriteLine(myWarehouse.Title);
            Console.WriteLine(myWarehouse.Address);
            Console.WriteLine(myWarehouse.ContactNumber);
            Console.WriteLine();

        }

        /// <summary>
        /// Change information of object.
        /// </summary>
        /// <param name="myWarehouse">Array of objects Warehouses</param>
        /// <param name="lineForChanging">1.Title, 2.Address, 3. ContactNumber,</param>
        /// <returns>object with changed information.</returns>
        public Warehouse updateInfo(Warehouse myWarehouse, int lineForChanging)
        {
            switch (lineForChanging)
            {
                case 1:
                    {
                        Console.Write("You are updating title of warehouse, enter info");
                        myWarehouse.Title = Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        Console.Write("You are updating address of warehouse, enter info");
                        myWarehouse.Address = Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        Console.Write("You are updating conteact number of warehouse, enter info");
                        myWarehouse.ContactNumber = Console.ReadLine();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong line for changing");
                        break;
                    }
            }
            return myWarehouse;
        }
    }
}