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
    public class FileSystemStoreTests
    {
        [TestMethod()]
        public void Save_And_Load_Data_Are_Equal()
        {
            //arrage
            Warehouse warehouseTest = CreateWarehouse();
            Warehouse expectWarehouse = CreateWarehouse();
            string path = @".\TestWarehouse.dat";
            //act
            FileSystemStore.SaveData(path, warehouseTest);
            warehouseTest = null;
            FileSystemStore.LoadData(path, ref warehouseTest);
            //assert
            Assert.AreEqual(expectWarehouse, warehouseTest);
        }

        private Warehouse CreateWarehouse()
        {
            Warehouse warehouseTest = new Warehouse("MyCompany", "Minsk, Radujnaya str.", "375293628848", 5);
            warehouseTest.Employees = new Employee[4];
            warehouseTest.Employees[0] = new Employee("Nastya", "", 28, EnumVacation.Accountant, "", "", "");
            warehouseTest.Employees[1] = new Employee("Alex", "", 30, EnumVacation.Director, "", "", "");
            warehouseTest.Employees[2] = new Employee("Andrei", "", 26, EnumVacation.Manager, "", "", "");
            warehouseTest.Employees[3] = new Employee("Max", "", 23, EnumVacation.Manager, "", "", "");

            return warehouseTest;
        }
    }
}