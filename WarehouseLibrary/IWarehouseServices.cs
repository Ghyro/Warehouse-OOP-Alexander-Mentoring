using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public interface IWarehouseServices
    {
        public void CleareInfo(ref Warehouse myWarehouse)
        {
        }
        public void AddEmployee(Warehouse myWarehouse, int numOfAddingEmployees)
        {
        }
        public void QuitEmployee(Warehouse myWarehouse, int numEmployeeInList)
        {
        }
        public Person[] SearchEmployee(Warehouse myWarehouse, string searchingName, string searchingSurname)//todo
        {
            Person[] resultList = new Employee[0];
            int counter = 0;
            for (int i = 0; i < myWarehouse.Employees.Length; i++)
            {
                if (myWarehouse.Employees[i].Name == searchingName && myWarehouse.Employees[i].Surname == searchingSurname)
                {
                    resultList[counter] = myWarehouse.Employees[i];
                    Array.Resize(ref resultList, resultList.Length + 1);
                    counter++;
                }
            }
            return resultList;
        }
    }
}
