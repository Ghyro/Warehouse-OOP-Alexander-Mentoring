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
        /// Take array of object "Warehouse", and add one new object of class;
        /// </summary>
        /// <param name="allWarehouses"></param>
        /// <returns>Array of object with one new object;</returns>
        public Warehouse[] addInfo(Warehouse[] allWarehouses)
        {
            Array.Resize(ref allWarehouses, allWarehouses.Length + 1);
            allWarehouses[allWarehouses.Length] = new Warehouse;
            return allWarehouses;
        }

        /// <summary>
        /// Display all object in array;
        /// </summary>
        /// <param name="allWarehouses">Array of objects Warehouses</param>
        public void displayInfo(Warehouse[] allWarehouses)
        {
            for (int i = 0; i < allWarehouses.Length; i++)
            {
                Console.WriteLine($"Number of index:{i}");
                Console.WriteLine(allWarehouses[i].Title);
                Console.WriteLine(allWarehouses[i].Address);
                Console.WriteLine(allWarehouses[i].ContactNumber);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Change information of object in array of objects.
        /// </summary>
        /// <param name="allWarehouses">Array of objects Warehouses</param>
        /// <param name="indexOfObject">Number of object in array, that you want to change</param>
        /// <param name="lineForChanging">1.Title, 2.Address, 3. ContactNumber,</param>
        /// <returns>Array of object with changed information.</returns>
        public Warehouse updateInfo(Warehouse[] allWarehouses, int indexOfObject, int lineForChanging)
        {
            switch (lineForChanging)
            {
                case 1:
                    {
                        allWarehouses[indexOfObject].Title = Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        allWarehouses[indexOfObject].Address = Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        allWarehouses[indexOfObject].ContactNumber = Console.ReadLine();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong line for changing");
                        break;
                    }
            }
            return allWarehouses;
        }
    } 
}