using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public class WarehouseServices : IWarehouseServices, ICommonServises
    {
        public static void QuickSort<T>(T[] list) where T : IComparable<T>
        {
            QuickSortInternal(list, 0, list.Length - 1);
        }
        private static void QuickSortInternal<T>(T[] list, int minIndex, int maxIndex) where T : IComparable<T>
        {
            if (minIndex >= maxIndex)
            {
                return;
            }
            int pivot = GetPivotIndex(list, minIndex, maxIndex);
            QuickSortInternal(list, minIndex, pivot - 1);
            QuickSortInternal(list, pivot + 1, maxIndex);
        }
        private static int GetPivotIndex<T>(T[] list, int minIndex, int maxIndex) where T : IComparable<T>
        {
            T pivot = list[maxIndex];
            // stack items smaller than partition from left to right
            int WallIndex = minIndex;
            for (int i = minIndex; i < maxIndex; i++)
            {
                T item = list[i];
                if (item.CompareTo(pivot) <= 0)
                {
                    list[i] = list[WallIndex];
                    list[WallIndex] = item;

                    WallIndex++;
                }
            }
            // put the wall after all the smaller items
            list[maxIndex] = list[WallIndex];
            list[WallIndex] = pivot;

            return WallIndex;
        }

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
            for (int i = myWarehouse.Employees.Length; i < employees.Length; i++)
            {
                employees[i] = new Employee();
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
        public Person[] SearchEmployes(Warehouse myWarehouse, string searchingName, string searchingSurname)
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


