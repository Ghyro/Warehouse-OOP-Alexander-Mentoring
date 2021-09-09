using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class WarehouseService
    {
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
                        Console.WriteLine("You are updating title of warehouse, enter info");
                        myWarehouse.Title = Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You are updating address of warehouse, enter info");
                        myWarehouse.Address = Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("You are updating conteact number of warehouse, enter info");
                        myWarehouse.ContactNumber = Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("You are updating vacation of the warehouse, enter info");
                        int i;
                        myWarehouse.UpdateVacation(int.Parse(Console.ReadLine()));
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

        /// <summary>
        /// set params to null
        /// </summary>
        /// <param name="myWarehouse"></param>
        public void CleareInfo(Warehouse myWarehouse)
        {
            myWarehouse = null;
        }

        /// <summary>
        /// search obj by name/surname
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="searchingName"></param>
        /// <param name="searchingSurname"></param>
        /// <returns>array of obj </returns>
        public Employee[] SearchEmployee(Employee[] employee, string searchingName, string searchingSurname)
        {
            Employee[] resultList= new Employee[1];
            int counter = 0;
            for (int i = 0; i < employee.Length-1; i++)
            {
                if (employee[i].Name == searchingName && employee[i].Surname == searchingSurname)
                {
                    resultList[counter] = new Employee(employee[i].Name, employee[i].Surname, employee[i].Age, employee[i].Job, employee[i].HomeAddress, employee[i].ContactNumber, employee[i].Education);
                    Array.Resize(ref resultList, resultList.Length + 1);
                    counter++;
                }
            }
            return resultList;
        }

        /// <summary>
        /// set quit element to null and resize(delete element)
        /// </summary>
        /// <param name="myWarehouse"></param>
        /// <param name="employee"></param>
        /// <param name="numEmployeeInList"></param>
        public void QuitEmployee(Warehouse myWarehouse, Employee[] employee, int numEmployeeInList)//можно ли обратьться к переменной склада "NumOfEmployed" без добавления склада в параметр? 
        {

            if (myWarehouse.NumOfEmployed > 0)
            {
                myWarehouse.NumOfEmployed--;
                employee[numEmployeeInList - 1] = null;
                for (int i = 0; i < employee.Length; i++)
                {
                    employee[numEmployeeInList - 1] = employee[numEmployeeInList];
                }
                Array.Resize(ref employee, employee.Length - 1);
            }
        }
    }
}
