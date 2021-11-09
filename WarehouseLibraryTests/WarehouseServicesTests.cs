using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarehouseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary.Tests
{
    [TestClass()]
    public class WarehouseServicesTests
    {
        //TODO Не понимаю почему не срабатывает [ClassInitialize]
        //пришлось в каждом тесте инициализировать объект
        [TestMethod()]
        public void Sort_DigitsWithoutRepit()
        {
            int[] nums = new int[] { 5, 7, -3, -1, 0, 4, 2, 6, 9, 8 };
            int[] expectedNums = new int[] { -3,-1,0, 2, 4, 5, 6, 7, 8, 9 };
            WarehouseServices.QuickSort<int>(nums);
            CollectionAssert.AreEqual(expectedNums, nums);
        }
        [TestMethod()]
        public void Sort_DigitsWithRepit()
        {
            int[] nums = new int[] { 5, 2,7, -3, -1, 0, 4,3, 2, 6, 9, 8 };
            int[] expectedNums = new int[] { -3, -1, 0, 2,2,3, 4, 5, 6, 7, 8, 9 };
            WarehouseServices.QuickSort<int>(nums);
            CollectionAssert.AreEqual(expectedNums, nums);
        }
        [TestMethod()]
        public void Sort_Collection_AreEqual()//не правильно работает сортировка(срабатывает с 2 объектами, на 3+ неправильно сортирует) 
        {
            //arrage
            Warehouse warehouseTest = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseTest.Employees = new Employee[4];
            warehouseTest.Employees[0] = new Employee("Nastya", "", 28, EnumVacation.Accountant, "", "", "");
            warehouseTest.Employees[1] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");
            warehouseTest.Employees[2] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");
            warehouseTest.Employees[3] = new Employee("Max", "", 23, EnumVacation.Manager, "", "", "");


            Warehouse warehouseExpected = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseExpected.Employees = new Employee[4];
            warehouseExpected.Employees[0] = new Employee("Max", "", 23, EnumVacation.Director, "", "", "");
            warehouseExpected.Employees[1] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");
            warehouseExpected.Employees[2] = new Employee("Nastya", "", 28, EnumVacation.Accountant, "", "", "");
            warehouseExpected.Employees[3] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");

            //act
            WarehouseServices.QuickSort<Employee>(warehouseTest.Employees);
            //assert
            CollectionAssert.AreEqual(warehouseExpected.Employees, warehouseTest.Employees, "Sorting result:");
        }
        [TestMethod()]
        public void AddEmployee_AreEqual_ArrayLenght()
        {
            //arrage
            Warehouse warehouseTest = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseTest.Employees = new Employee[3];
            warehouseTest.Employees[0] = new Employee("Nastya", "", 28, EnumVacation.Accountant, "", "", "");
            warehouseTest.Employees[1] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");
            warehouseTest.Employees[2] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");

            int expected = 6;
            //act
            WarehouseServices warehouseServices = new WarehouseServices();
            warehouseServices.AddEmployee(warehouseTest, 3);
            //assert
            Assert.AreEqual(expected, warehouseTest.Employees.Length);
        }
        [TestMethod()]
        public void QuitEmployee_AreEqual_ArrayLenght()
        {
            //arrage
            Warehouse warehouseTest = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseTest.Employees = new Employee[3];
            warehouseTest.Employees[0] = new Employee("Nastya", "", 28, EnumVacation.Accountant, "", "", "");
            warehouseTest.Employees[1] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");
            warehouseTest.Employees[2] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");

            int expected = 2;
            //act
            WarehouseServices warehouseServices = new WarehouseServices();
            warehouseServices.QuitEmployee(warehouseTest, 1);
            //assert

            Assert.AreEqual(expected, warehouseTest.Employees.Length);
        }
        [TestMethod()]
        public void QuitEmployee_Collection_AreEqual()
        {
            //arrage
            Warehouse warehouseTest = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseTest.Employees = new Employee[3];
            warehouseTest.Employees[0] = new Employee("Nastya", "", 28, EnumVacation.Accountant, "", "", "");
            warehouseTest.Employees[1] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");
            warehouseTest.Employees[2] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");

            Warehouse warehouseExpected = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseExpected.Employees = new Employee[2];
            warehouseTest.Employees[1] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");
            warehouseTest.Employees[2] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");
            //act
            WarehouseServices warehouseServices = new WarehouseServices();
            warehouseServices.QuitEmployee(warehouseTest, 1);
            //assert

            CollectionAssert.AreEqual(warehouseExpected.Employees, warehouseExpected.Employees);
        }
        [TestMethod()]//почему не вижу следующего теста?
        public Person[] SearchEmployee_Collection_AreEqual()
        {
            //arrage
            Warehouse warehouseTest = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseTest.Employees = new Employee[3];
            warehouseTest.Employees[0] = new Employee("Nastya", "", 28, EnumVacation.Accountant, "", "", "");
            warehouseTest.Employees[1] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");
            warehouseTest.Employees[2] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");

            Person[] result = new Employee[1];
            Warehouse warehouseExpected = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseExpected.Employees = new Employee[1];
            warehouseExpected.Employees[0] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");
            //act
            WarehouseServices warehouseServices = new WarehouseServices();
            result = warehouseServices.SearchEmployee(warehouseTest, "Andrei", "");
            //assert
            CollectionAssert.AreEqual(warehouseExpected.Employees, result);
            return result;
        }
    }
}