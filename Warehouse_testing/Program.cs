using System;
using WarehouseLibrary;
using System.Collections.Generic;
using System.Diagnostics;

namespace WarehouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                var timer = new Stopwatch();
                timer.Start();
                string path = @".\warehouse.dat";
                Logging.Log("Program is running", LogType.Success);
                Warehouse myWarehouse = new Warehouse("Default warehouse", "Default address", "Default number", 5);//Default value
                FileSystemStore.LoadData(path, ref myWarehouse);
                Logging.Log("Load data", LogType.Success);
                WarehouseServices warehouseServices = new WarehouseServices();
                bool isWorking = true;
                while (isWorking)
                {
                    Console.WriteLine("Welcom to Warehouse");
                    Console.WriteLine("\n1. Display warehouse info");
                    Console.WriteLine("2. Update warehouse info");
                    Console.WriteLine("3. Clear all info about Warehouse(re - create Warehouse)");
                    Console.WriteLine("4. Display info about free vacancies");
                    Console.WriteLine("5. Display the list of Employees");
                    Console.WriteLine("6. Add employee");
                    Console.WriteLine("7. Search the employee by Name and Surname");
                    Console.WriteLine("8. Update employee info");
                    Console.WriteLine("9. Quit employee(remove)");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine();
                    int operation = TrySetNumber();
                    switch (operation) //main menu
                    {
                        case 1://Display info(title, address, contact number)
                            {
                                Console.Clear();
                                Console.WriteLine("Information about your warehouse:");
                                DisplayInfo(myWarehouse);
                                Logging.Log("Display warehouse info", LogType.Success);
                                break;
                            }
                        case 2://Update info(for instance, update contact number)
                            {
                                bool proccessor = true;
                                while (proccessor)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter the number of line that you want to change");
                                    Console.WriteLine("1.Title\n2.Address\n3.Contact number\n4.Number of vacation\n5.Finish editting");
                                    int numOfLine = TrySetNumber();
                                    if (numOfLine > 0 && numOfLine < 5)
                                        UpdateWarehouseInfo(myWarehouse, numOfLine);
                                    else
                                    {
                                        proccessor = false;
                                    }
                                }
                                Logging.Log("Update warehouse info", LogType.Success);
                                FileSystemStore.SaveData(path, myWarehouse);
                                Logging.Log("Save data", LogType.Success);
                                break;
                            }
                        case 3://Clear all info about Warehouse(re - create Warehouse)
                            {
                                Console.Clear();
                                warehouseServices.CleareInfo(ref myWarehouse);
                                FileSystemStore.SaveData(path, myWarehouse);
                                Logging.Log("Warehouse clean", LogType.Success);
                                Console.WriteLine("Warehouse clean success!\n");
                                break;
                            }
                        case 4://Display info about free vacancies
                            {
                                Console.Clear();
                                Console.WriteLine($"Free vacation now: {myWarehouse.Vacations - myWarehouse.Employees.Length}\n");
                                Logging.Log("Display info about free vacancies", LogType.Success);
                                break;
                            }
                        case 5://Display the list of Employees
                            {
                                Console.Clear();
                                Console.WriteLine("List of employees:");
                                WarehouseServices.QuickSort<Employee>(myWarehouse.Employees);
                                DisplayEmployeeList(myWarehouse);
                                Logging.Log("Display the list of Employees", LogType.Success);
                                break;
                            }
                        case 6://add employee
                            {
                                Console.Clear();
                                Console.WriteLine("1. Add new employees\n2. Add new employee by cloning");
                                Console.WriteLine("Select your choise: ");
                                int op = TrySetNumber();
                                switch (op)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("How many employees do you want to add?");
                                            int numOfEmployees = TrySetNumber();
                                            AddEmployee(myWarehouse, warehouseServices, numOfEmployees);
                                            AddEmployeeInfo(myWarehouse, numOfEmployees);
                                            FileSystemStore.SaveData(path, myWarehouse);
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (myWarehouse.Employees.Length > 0)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("List of employees:");
                                                DisplayEmployeeList(myWarehouse);
                                                AddEmployee(myWarehouse, warehouseServices, 1);
                                                AddEmployeeByClone(myWarehouse);
                                                PersonFieldsNames();
                                                UpdateEmployeeInfo(myWarehouse.Employees[myWarehouse.Employees.Length - 1]);
                                                FileSystemStore.SaveData(path, myWarehouse);
                                                break;
                                            }
                                            else
                                                Console.WriteLine("You haven't got employee for cloning\n\n\n\n");
                                            break;
                                        }
                                }
                                break;
                            }
                        case 7://Search the employee by Name and Surname
                            {
                                Console.Clear();
                                Console.WriteLine("Enter searcing name");
                                string searcingName = Console.ReadLine();
                                Console.WriteLine("Enter searcing surname");
                                string searchingSurname = Console.ReadLine();
                                DisplayEmployeeList((Employee[])warehouseServices.SearchEmployes(myWarehouse, searcingName, searchingSurname));
                                break;
                            }
                        case 8://Update employee info
                            {
                                Console.Clear();
                                Console.WriteLine("Choose how do you want to find employee for updating info:\n 1. By select number of employee from employees list;\n 2. Find by name and surname;");
                                int selection = TrySetNumber();
                                switch (selection)
                                {
                                    case 1://choose in list
                                        {
                                            Console.Clear();
                                            Console.WriteLine("List of employees:");
                                            DisplayEmployeeList(myWarehouse);
                                            Console.WriteLine("\nEnter number of employee that you want to change: ");
                                            int searchingString = TrySetNumber();
                                            PersonFieldsNames();
                                            for (int i = 0; i < myWarehouse.Employees.Length; i++)//можно улучшить использовав не линейный поиск
                                            {
                                                if (myWarehouse.Employees[i].Id == myWarehouse.Employees[searchingString - 1].Id)
                                                {
                                                    UpdateEmployeeInfo(myWarehouse.Employees[i]);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    case 2://find by name and surname
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Enter searcing name");
                                            string searcingName = Console.ReadLine();
                                            Console.WriteLine("Enter searcing surname");
                                            string searchingSurname = Console.ReadLine();
                                            DisplayEmployeeList((Employee[])warehouseServices.SearchEmployes(myWarehouse, searcingName, searchingSurname));//searching person
                                            Console.WriteLine("\nEnter number of employee that you want to change: ");
                                            int searchingString = TrySetNumber();
                                            PersonFieldsNames();
                                            for (int i = 0; i < myWarehouse.Employees.Length; i++)//можно улучшить использовав не линейный поиск
                                            {
                                                if (myWarehouse.Employees[i].Id == myWarehouse.Employees[searchingString].Id)
                                                {
                                                    UpdateEmployeeInfo(myWarehouse.Employees[i]);
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    default:
                                        Console.Clear();
                                        break;
                                }
                                FileSystemStore.SaveData(path, myWarehouse);
                                break;
                            }
                        case 9://Quit employee(remove)
                            {
                                Console.WriteLine("List of employees:");
                                DisplayEmployeeList(myWarehouse);
                                Console.WriteLine("Enter number of employee from Employees list: ");
                                int numOfEmployeeForQuit = TrySetNumber();
                                if (numOfEmployeeForQuit == 0)
                                {
                                    break;
                                }
                                warehouseServices.QuitEmployee(myWarehouse, numOfEmployeeForQuit);
                                Console.Clear();
                                FileSystemStore.SaveData(path, myWarehouse);
                                break;
                            }
                        case 0: //exit
                            {
                                isWorking = false;
                                break;
                            }
                        default://excaption
                            Console.WriteLine("Wrong selection!");
                            break;
                    }//main menu
                }
                FileSystemStore.SaveData(path, myWarehouse);
                Logging.Log("Program is closing", LogType.Success);
                timer.Stop();
                TimeSpan ts = timer.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                Console.WriteLine("RunTime " + elapsedTime);
            }
            catch (IndexOutOfRangeException ex)
            {
                Logging.Log($"{ex}", LogType.Error);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Logging.Log($"{ex}", LogType.Error);
            }
            catch (ArgumentNullException ex)
            {
                Logging.Log($"{ex}", LogType.Error);
            }
            catch (NullReferenceException ex)
            {
                Logging.Log($"{ex}", LogType.Error);
            }
            catch (Exception ex)
            {
                Logging.Log($"{ex}", LogType.Error);
            }
        }

        static void DisplayEmployeeList(Warehouse myWarehouse)
        {
            if (myWarehouse.Employees.Length + 1 > 0)
            {
                Console.WriteLine($"name    |age    |Job position   |home address   |contact number |education");
                for (int i = 0; i < myWarehouse.Employees.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {myWarehouse.Employees[i].Name} {myWarehouse.Employees[i].Surname}|{myWarehouse.Employees[i].Age}|{myWarehouse.Employees[i].Job}|{myWarehouse.Employees[i].HomeAddress}|{myWarehouse.Employees[i].ContactNumber}|{myWarehouse.Employees[i].Education}");
                }
            }
            else
            {
                Console.WriteLine("Now you have 0 employee with that name.");
            }
            Console.WriteLine("\n");
        }
        static void DisplayEmployeeList(Employee[] employees)
        {
            Array.Sort(employees);
            if (employees.Length + 1 > 0)
            {
                Console.WriteLine($"name    |age    |Job position   |home address   |contact number |education");
                for (int i = 0; i < employees.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {employees[i].Name} {employees[i].Surname}|{employees[i].Age}|{employees[i].Job}|{employees[i].HomeAddress}|{employees[i].ContactNumber}|{employees[i].Education}");
                }
            }
            else
            {
                Console.WriteLine("Now you have 0 employee with that name.");
            }
            Console.WriteLine("\n");
        }
        static void DisplayInfo(Warehouse myWarehouse)
        {
            if (myWarehouse != null)
            {
                Console.WriteLine(myWarehouse.Title);
                Console.WriteLine(myWarehouse.Address);
                Console.WriteLine(myWarehouse.ContactNumber);
                Console.WriteLine($"number of employees: {myWarehouse.Employees.Length}");
                Console.WriteLine($"number of free vacation: {myWarehouse.Vacations - myWarehouse.Employees.Length}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No info about warehouse. For fisrt select warehouse info\n");
            }
        }//Display info about warehouse
        static Warehouse UpdateWarehouseInfo(Warehouse myWarehouse, int lineForChanging)
        {
            if (myWarehouse == null)
            {
                myWarehouse = new Warehouse("", "", "", 0);
            }
            switch (lineForChanging)
            {
                case 1:
                    {
                        Console.WriteLine("You are updating title of warehouse, enter info");
                        Console.ForegroundColor = ConsoleColor.Green;
                        myWarehouse.Title = Console.ReadLine();
                        Console.ResetColor();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You are updating address of warehouse, enter info");
                        Console.ForegroundColor = ConsoleColor.Green;
                        myWarehouse.Address = Console.ReadLine();
                        Console.ResetColor();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("You are updating contact number of warehouse, enter info");
                        Console.ForegroundColor = ConsoleColor.Green;
                        myWarehouse.ContactNumber = Console.ReadLine();
                        Console.ResetColor();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine($"Total vacation now: {myWarehouse.Vacations}");
                        Console.WriteLine($"Total free vacation now: {myWarehouse.Vacations - myWarehouse.Employees.Length}");
                        Console.WriteLine("You are updating vacation of the warehouse, enter info");
                        Console.ForegroundColor = ConsoleColor.Green;
                        myWarehouse.UpdateVacation(int.Parse(Console.ReadLine()));
                        Console.ResetColor();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong line for changing");
                        break;
                    }
            }
            return myWarehouse;
        }//Update info in selected field of warehouse
        static void AddEmployee(Warehouse myWarehouse, IWarehouseServices warehouseServicses, int numOfEmployees)
        {
            try
            {
                if ((myWarehouse.Vacations - myWarehouse.Employees.Length) >= numOfEmployees)
                {
                    warehouseServicses.AddEmployee(myWarehouse, numOfEmployees);
                    Console.WriteLine("Operation being completed and objects are added.\n");
                    for (int i = myWarehouse.Employees.Length; i > myWarehouse.Employees.Length - numOfEmployees; i--)
                    {
                        Logging.Log($"Employee with ID:{myWarehouse.Employees[i-1].Id} was created", LogType.Success);
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                Logging.Log(ex.Message, LogType.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operation cannot be performed.");
                Console.WriteLine($"available free vacation: {myWarehouse.Vacations - myWarehouse.Employees.Length}\n");
                Logging.Log($"{ex}", LogType.Error);
            }
        }
        static void AddEmployeeInfo(Warehouse myWarehouse, int numOfEmployees)
        {
            for (int i = 0; i < myWarehouse.Employees.Length; i++)
            {
                Console.WriteLine($"Enter information for {i + 1} employee");
                Console.WriteLine("Enter employee's name");
                Console.ForegroundColor = ConsoleColor.Green;
                string name = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("Enter employee's surname*");
                Console.ForegroundColor = ConsoleColor.Green;
                string surname = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("Enter employee's age");
                int age = TrySetNumber();
                while (age < 18)
                {
                    Console.WriteLine("Employee age must be more than 17");
                    age = TrySetNumber();
                }
                EnumVacation job = 0;
                Console.ResetColor();
                Console.WriteLine("Select employee's job position:");
                PrintVacations();
                int selection = TrySetNumber();
                switch (selection)
                {
                    case 1:
                        {
                            job = EnumVacation.Accountant;
                            break;
                        }
                    case 2:
                        {
                            job = EnumVacation.Cleaner;
                            break;
                        }
                    case 3:
                        {
                            job = EnumVacation.Director;
                            break;
                        }
                    case 4:
                        {
                            job = EnumVacation.Manager;
                            break;
                        }
                    case 5:
                        {
                            job = EnumVacation.Storekeeper;
                            break;
                        }
                    default:
                        break;
                }
                Console.WriteLine("Enter employee's home address");
                Console.ForegroundColor = ConsoleColor.Green;
                string homeAddress = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("Enter employee's contact number");
                Console.ForegroundColor = ConsoleColor.Green;
                string contactNumber = Console.ReadLine();
                Console.ResetColor();
                Console.WriteLine("Enter employee's education");
                Console.ForegroundColor = ConsoleColor.Green;
                string education = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();
                myWarehouse.Employees[myWarehouse.Employees.Length  - numOfEmployees + i].Name = name;
                myWarehouse.Employees[myWarehouse.Employees.Length  - numOfEmployees + i].Surname = surname;
                myWarehouse.Employees[myWarehouse.Employees.Length  - numOfEmployees + i].Age = age;
                myWarehouse.Employees[myWarehouse.Employees.Length  - numOfEmployees + i].Job = job;
                myWarehouse.Employees[myWarehouse.Employees.Length  - numOfEmployees + i].HomeAddress = homeAddress;
                myWarehouse.Employees[myWarehouse.Employees.Length  - numOfEmployees + i].ContactNumber = contactNumber;
                myWarehouse.Employees[myWarehouse.Employees.Length  - numOfEmployees + i].Education = education;
            }
        }
        static void AddEmployeeByClone(Warehouse myWarehouse)
        {
            Console.WriteLine("Select number of employee that you want to clone:");
            int numOfEmployee = TrySetNumber();
            myWarehouse.Employees[myWarehouse.Employees.Length - 1] = (Employee)myWarehouse.Employees[numOfEmployee - 1].Clone();//TODO Переопределить метод clone, т.к. у каждого объекта есть свой ID
            Console.Clear();
        }
        static void PersonFieldsNames()
        {
            Console.WriteLine("1. Update employee's name");
            Console.WriteLine("2. Update employee's surname");
            Console.WriteLine("3. Update employee's age");
            Console.WriteLine("4. Update employee's job");
            Console.WriteLine("5. Update employee's home address");
            Console.WriteLine("6. Update employee's contact number");
            Console.WriteLine("7. Update employee's education");
            Console.WriteLine("8. Finish editing information");
        }//Display namelist of fields
        static void UpdateEmployeeInfo(Employee employee)
        {
            int numOfLineForChanging;
            bool isWorking = true;
            do
            {
                Console.WriteLine("Enter the number of information that you want to change:");
                numOfLineForChanging = TrySetNumber();
                switch (numOfLineForChanging)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter employee's name");
                            Console.ForegroundColor = ConsoleColor.Green;
                            employee.Name = Console.ReadLine();

                            Console.ResetColor();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter employee's surname");
                            Console.ForegroundColor = ConsoleColor.Green;
                            employee.Surname = Console.ReadLine();
                            Console.ResetColor();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter employee's age");
                            employee.Age = TrySetNumber();
                            break;
                        }
                    case 4:
                        {
                            Console.ResetColor();
                            Console.WriteLine("Select employee's job position:");
                            PrintVacations();
                            int selection = TrySetNumber();
                            switch (selection)
                            {
                                case 1:
                                    {
                                        employee.Job = EnumVacation.Accountant;
                                        break;
                                    }
                                case 2:
                                    {
                                        employee.Job = EnumVacation.Cleaner;
                                        break;
                                    }
                                case 3:
                                    {
                                        employee.Job = EnumVacation.Director;
                                        break;
                                    }
                                case 4:
                                    {
                                        employee.Job = EnumVacation.Manager;
                                        break;
                                    }
                                case 5:
                                    {
                                        employee.Job = EnumVacation.Storekeeper;
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter employee's home address");
                            Console.ForegroundColor = ConsoleColor.Green;
                            employee.HomeAddress = Console.ReadLine();
                            Console.ResetColor();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter employee's contact number");
                            Console.ForegroundColor = ConsoleColor.Green;
                            employee.ContactNumber = Console.ReadLine();
                            Console.ResetColor();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Enter employee's education");
                            Console.ForegroundColor = ConsoleColor.Green;
                            employee.Education = Console.ReadLine();
                            Console.ResetColor();
                            break;
                        }
                    case 8:
                        {
                            isWorking = false;
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong line for changing");
                            break;
                        }
                }
            }
            while (isWorking);
        }//Update info in selected field of employee
        static void PrintVacations()
        {
            int i = 0;
            foreach (var position in Enum.GetNames(typeof(EnumVacation)))
            {
                Console.WriteLine($"{i + 1}. {position}");
                i++;
            }
        }
        static int TrySetNumber()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int value = 0;
            bool process = true;
            while (process)
            {
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    process = false;
                }
                else
                {
                    Console.WriteLine("Input error, default value is 0");
                    process = false;
                }
            }
            Console.ResetColor();
            return value;
        }
    }
}




