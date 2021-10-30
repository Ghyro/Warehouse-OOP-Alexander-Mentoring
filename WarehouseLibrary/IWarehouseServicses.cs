﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public interface IWarehouseServicses
    {
        public void CleareInfo(ref Warehouse myWarehouse)
        {
            myWarehouse = null;
        }
        public void AddEmployee(Warehouse myWarehouse, int numOfAddingEmployees)
        {
            Person[] employees = new Employee[myWarehouse.Employees.Length + numOfAddingEmployees];
            for (int i = 0; i < myWarehouse.Employees.Length; i++)
            {
                employees[i] = myWarehouse.Employees[i];
            }
            myWarehouse.Employees = (Employee[])employees;
        }
        public void QuitEmployee(Warehouse myWarehouse, int numEmployeeInList)
        {
            Person[] employees = new Employee[myWarehouse.Employees.Length - 1];
            if (myWarehouse.Employees.Length > 0)
            {
                for (int i = 0; i < numEmployeeInList - 1; i++)
                {
                    employees[i] = myWarehouse.Employees[i];
                }
                for (int i = numEmployeeInList; i < myWarehouse.Employees.Length; i++)
                {
                    employees[i - 1] = myWarehouse.Employees[i];
                }
                myWarehouse.Employees = (Employee[])employees;
            }
            else
            {
                Console.WriteLine("Number of employeed person is 0");
            }
        }
        public Person[] SearchEmployee(Warehouse myWarehouse, string searchingName, string searchingSurname)
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