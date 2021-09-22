using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class WarehouseService
    {        
        public void CleareInfo(Warehouse myWarehouse)
        {
            myWarehouse = null;
        }
        public Employee[] AddEmployee(ref Employee[] employees, int numOfAddingEmployees)
        {
            Array.Resize(ref employees, employees.Length + numOfAddingEmployees);
            return employees;
        }
        public void QuitEmployee(Warehouse myWarehouse, ref Employee[] employee, int numEmployeeInList)
        {
            Employee[] employees = new Employee[employee.Length - 1];
            if (myWarehouse.NumOfEmployed > 0)
            {
                myWarehouse.NumOfEmployed--;
                for (int i = 0; i < numEmployeeInList - 1; i++)
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
        public Employee[] SearchEmployee(Employee[] employee, string searchingName, string searchingSurname)
        {
            Employee[] resultList = new Employee[0];
            int counter = 0;
            for (int i = 0; i < employee.Length; i++)
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
    }
}
