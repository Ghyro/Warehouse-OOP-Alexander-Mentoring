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
