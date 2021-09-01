using System;
using WarehouseLibrary;
namespace WarehouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse myWarehouse = new Warehouse();
            myWarehouse.addInfo(myWarehouse);
            Console.WriteLine();
            Console.WriteLine("Information about your warehouse");
            myWarehouse.displayInfo(myWarehouse);
            Console.WriteLine();
            Console.WriteLine("Enter the number of line that you want to change");
            Console.WriteLine("1.Title, 2.Address, 3.Contact Number");
            int numOfLine = int.Parse(Console.ReadLine());
            myWarehouse.updateInfo(myWarehouse,numOfLine);
            Console.WriteLine("Information about your warehouse");
            myWarehouse.displayInfo(myWarehouse);
            

        }
    }
}
