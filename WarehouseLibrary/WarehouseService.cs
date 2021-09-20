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
            Employee[] resultList= new Employee[0];
            int counter = 0;
            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i].Name == searchingName && employee[i].Surname == searchingSurname)
                {
                    resultList[counter] = new Employee(employee[i].Name, employee[i].Surname, employee[i].Age, employee[i].Job, employee[i].HomeAddress, employee[i].ContactNumber, employee[i].Education);
                    Array.Resize(ref resultList, resultList.Length +1);
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
        public void QuitEmployee(Warehouse myWarehouse, ref Employee[] employee, int numEmployeeInList)//можно ли обратьться к переменной склада "NumOfEmployed" без добавления склада в параметр? 
        {
            Employee[] employees = new Employee[employee.Length - 1];
            if (myWarehouse.NumOfEmployed > 0)
            {
                myWarehouse.NumOfEmployed--;
                for (int i = 0; i < numEmployeeInList - 1; i++)//надо добавить сдвиг массива, если удаляется элемент из середины и начала массива.
                {
                    employees[i] = employee[i];
                }
                for (int i = numEmployeeInList; i < employee.Length; i++)
                {
                    employees[i-1] = employee[i];
                }
                employee = employees;
            }
            else
            {
                Console.WriteLine("Number of employeed person is 0");
            }
        }
        public Employee [] AddEmployee(ref Employee[] employees, int numOfAddingEmployees)
        {
            Array.Resize(ref employees, employees.Length+numOfAddingEmployees);
            return employees;
        }
    }
}
