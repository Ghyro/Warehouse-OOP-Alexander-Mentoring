using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class WarehouseService
    {
        /*/// <summary>
        /// Take object "Warehouse" and add info on it;
        /// </summary>
        /// <param name="myWarehouses"></param>
        /// <returns>Object with info;</returns>
        public Warehouse AddInfo(Warehouse myWarehouse) // изначально я хотел метод который принимает массив объектов и добавляет в него объект.
        {
            Console.WriteLine("Enter title of your warehouse");
            myWarehouse.Title = Console.ReadLine();
            Console.WriteLine("Enter address of your warehouse");
            myWarehouse.Address = Console.ReadLine();
            Console.WriteLine("Enter contact number of your warehouse");
            myWarehouse.ContactNumber = Console.ReadLine();
            Console.WriteLine("Enter number of vacation");
            myWarehouse.Vacations = int.Parse(Console.ReadLine());
            return myWarehouse;
        }*/

        /// <summary>
        /// Display object info;
        /// </summary>
        /// <param name="myWarehouse">Array of objects Warehouses</param>
        public void DisplayInfo(Warehouse myWarehouse)
        {
            Console.WriteLine(myWarehouse.Title);
            Console.WriteLine(myWarehouse.Address);
            Console.WriteLine(myWarehouse.ContactNumber);
            Console.WriteLine($"number of employees{myWarehouse.Employees.Length}");
            int freeVacationgs = myWarehouse.Vacations - myWarehouse.Employees.Length;
            Console.WriteLine($"number of free vacation{freeVacationgs}");

            Console.WriteLine();
        }

        /// <summary>
        /// Change information of object.
        /// </summary>
        /// <param name="myWarehouse">Array of objects Warehouses</param>
        /// <param name="lineForChanging">1.Title, 2.Address, 3. ContactNumber, 4.Vacation</param>
        /// <returns>object with changed information.</returns>
        public Warehouse UpdateInfo(Warehouse myWarehouse, int lineForChanging)
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
                case 4:
                    {
                        Console.Write("You are updating vacation of the warehouse, enter info");
                        myWarehouse.Vacations = int.Parse(Console.ReadLine());
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

        public void CleareInfo(Warehouse myWarehouse)// возможно реф параметр
        {
            myWarehouse = null;
        }
        
        public Employee SearchEmployee(Employee[] employee, string searchingName, string searchingSurname)
        {
            Employee[] resultList = new Employee[1];
            int counter = 0;
            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i].Name==searchingName&&employee[i].Surname==searchingSurname)
                {
                    resultList[counter].Name = employee[i].Name;
                    resultList[counter].Surname=employee[i].Surname;




                }
            }

            return resultList;
        }
        public void QuitEmployee(Employee[] employee)
        {
            employee = null;
        }
    }
}
