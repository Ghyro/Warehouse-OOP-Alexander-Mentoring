using System;
using WarehouseLibrary;

namespace WarehouseApp
{
    class Program
    {
        /*
        НА ДОРАБОТКУ:
        -при увольнении сотрудника, добавить сдвиг массива(если удаляемый сотрудник находиться в середине массива);
        -в методах, где для параметра принимается employees, добавить явное приведение типов (позволит использоваться функцианал методов не только для employees[]);


        */
        static void Main(string[] args)
        {
            Warehouse myWarehouse = new Warehouse("Bag&socks", "Belarus, 1 str.", "+375293628848", 5);
            WarehouseService warehouseService = new WarehouseService();
            Person[] persons = new Employee[0];
            Employee[] employees = (Employee[])persons;
            while (true)
            {
                Console.WriteLine("\n1. Display info(title, address, contact number)");
                Console.WriteLine("2. Update info(for instance, update contact number)");
                Console.WriteLine("3. Clear all info about Warehouse(re - create Warehouse)");
                Console.WriteLine("4. Display info about free vacancies");
                Console.WriteLine("5. Display the list of Employees");
                Console.WriteLine("6. Add employee");
                Console.WriteLine("7. Search the employee by Name and Surname");
                Console.WriteLine("8. Quit employee(remove)");
                Console.WriteLine();
                int operation;
                Console.ForegroundColor = ConsoleColor.Green;
                int.TryParse(Console.ReadLine(), out operation);
                Console.ResetColor();
                switch (operation) //main menu
                {
                    case 1://Display info(title, address, contact number
                        {
                            Console.WriteLine("Information about your warehouse:");
                            DisplayInfo(myWarehouse);
                            break;
                        }
                    case 2://Update info(for instance, update contact number)
                        {
                            Console.WriteLine("Enter the number of line that you want to change");
                            Console.WriteLine("1.Title, 2.Address, 3.Contact number, 4.Vacation");
                            int numOfLine;
                            Console.ForegroundColor = ConsoleColor.Green;                            
                            int.TryParse(Console.ReadLine(), out numOfLine);
                            Console.ResetColor();
                            if (numOfLine == 4)
                            {
                                Console.WriteLine($"Total vacation now: {myWarehouse.Vacations}");
                                Console.WriteLine($"Total free vacation now: {myWarehouse.Vacations - myWarehouse.NumOfEmployed}");
                                UpdateInfo(myWarehouse, numOfLine);
                                break;
                            }
                            UpdateInfo(myWarehouse, numOfLine);
                            break;
                        }
                    case 3://Clear all info about Warehouse(re - create Warehouse)
                        {
                            warehouseService.CleareInfo(myWarehouse);
                            Console.Clear();
                            break;

                        }
                    case 4://Display info about free vacancies
                        {
                            Console.WriteLine($"Free vacation now: {myWarehouse.Vacations - myWarehouse.NumOfEmployed}\n");
                            break;
                        }
                    case 5://Display the list of Employees
                        {
                            Console.WriteLine("List of employees:");
                            DisplayEmployeeList(employees);
                            break;
                        }
                    case 6://add employee info
                        {
                            Console.WriteLine("How many employees do you want to add?");
                            int numOfEmployees;
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out numOfEmployees);
                            Console.ResetColor();
                            AddEmployeesInMainMenu(numOfEmployees);
                            AddEmployeeInfo(numOfEmployees);
                            break;
                        }
                    case 7://Search the employee by Name and Surname
                        {
                            Console.WriteLine("Enter searcing name");
                            string searcingName = Console.ReadLine();
                            Console.WriteLine("Enter searcing surname");
                            string searchingSurname = Console.ReadLine();
                            DisplayEmployeeList(warehouseService.SearchEmployee(employees, searcingName, searchingSurname));
                            break;
                        }
                    case 8://Quit employee(remove)
                        {
                            Console.WriteLine("Enter number of employee from Employees list: ");
                            int numOfEmployeeForQuit;
                            Console.ForegroundColor = ConsoleColor.Green;
                            int.TryParse(Console.ReadLine(), out numOfEmployeeForQuit);
                            Console.ResetColor();
                            warehouseService.QuitEmployee(myWarehouse, employees, numOfEmployeeForQuit);
                            Console.Clear();
                            break;                            
                        }
                    default://excaption
                        Console.WriteLine("Wrong selection!");
                        break;
                }
            }

            void DisplayEmployeeList(Employee[] employees)
            {
                if (myWarehouse.NumOfEmployed > 0)
                {
                    Console.WriteLine($"name|age|Job position|home address|contact number|education");
                    for (int i = 0; i < employees.Length; i++)
                    {
                        Console.WriteLine($"{i+1}. {employees[i].Name} {employees[i].Surname}|{employees[i].Age}|{employees[i].Job}|{employees[i].HomeAddress}|{employees[i].ContactNumber}|{employees[i].Education}");
                    }
                }
                else
                {
                    Console.WriteLine("Now you have 0 employee.");
                }

            }

            /// <summary>
            /// Display object info;
            /// </summary>
            /// <param name="myWarehouse">Array of objects Warehouses</param>
            void DisplayInfo(Warehouse myWarehouse)
            {
                Console.WriteLine(myWarehouse.Title);
                Console.WriteLine(myWarehouse.Address);
                Console.WriteLine(myWarehouse.ContactNumber);
                Console.WriteLine($"number of employees: {myWarehouse.NumOfEmployed}");
                int freeVacations = myWarehouse.Vacations - myWarehouse.NumOfEmployed;
                Console.WriteLine($"number of free vacation: {freeVacations}");
                Console.WriteLine();
            }

            /// <summary>
            /// Change information of object.
            /// </summary>
            /// <param name="myWarehouse">Array of objects Warehouses</param>
            /// <param name="lineForChanging">1.Title, 2.Address, 3. ContactNumber, 4.Vacation</param>
            /// <returns>object with changed information.</returns>
            Warehouse UpdateInfo(Warehouse myWarehouse, int lineForChanging)
            {
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
                            Console.WriteLine("You are updating conteact number of warehouse, enter info");
                            Console.ForegroundColor = ConsoleColor.Green;
                            myWarehouse.ContactNumber = Console.ReadLine();
                            Console.ResetColor();
                            break;
                        }
                    case 4:
                        {
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
            }

            void AddEmployeesInMainMenu(int numOfEmployees)//баг если вводишь не число

            {
                if ((myWarehouse.Vacations - myWarehouse.NumOfEmployed) >= numOfEmployees)
                {
                    warehouseService.AddEmployee(ref employees, numOfEmployees);
                    Console.WriteLine("Operation being completed and objects are added.\n");
                }
                else
                {
                    Console.WriteLine("Operation cannot be performed.");
                    Console.WriteLine("available free vacation: {myWarehouse.Vacations - myWarehouse.NumOfEmployed}\n");
                }

            }
            void AddEmployeeInfo(int numOfEmployees)
            {
                if (numOfEmployees == 1)// solo adding employee
                {                    
                    Console.WriteLine("Enter employee's name");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("Enter employee's surname*");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string surname = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("Enter employee's age");
                    int age;
                    Console.ForegroundColor = ConsoleColor.Green;
                    int.TryParse(Console.ReadLine(), out age);
                    EnumVacation job =0;
                    Console.ResetColor();
                    Console.WriteLine("Select employee's job position:\n1.accountant\n2.cleaner\n3.director\n4.manager\n5.storekeeper");
                    int selection;
                    Console.ForegroundColor = ConsoleColor.Green;
                    int.TryParse(Console.ReadLine(), out selection);
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
                    Console.ResetColor();
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

                    employees[employees.Length-1] = new Employee(name, surname, age, job, homeAddress, contactNumber, education);//adding Employee                    
                    myWarehouse.NumOfEmployed++;
                }
                else if (numOfEmployees > 1)// multy adding employees
                {
                    for (int i = 0; i < employees.Length; i++)
                    {
                        Console.WriteLine("Enter employee's name");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string name = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("Enter employee's surname*");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string surname = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("Enter employee's age");
                        int age;
                        Console.ForegroundColor = ConsoleColor.Green;
                        int.TryParse(Console.ReadLine(), out age);
                        EnumVacation job = 0;
                        Console.ResetColor();
                        Console.WriteLine("Select employee's job position:\n1.accountant\n2.cleaner\n3.director\n4.manager\n5.storekeeper");
                        int selection;
                        Console.ForegroundColor = ConsoleColor.Green;
                        int.TryParse(Console.ReadLine(), out selection);
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
                        Console.ResetColor();
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

                        employees[employees.Length - numOfEmployees + i] = new Employee(name, surname, age, job, homeAddress, contactNumber, education);//adding Employee
                        myWarehouse.NumOfEmployed++;
                    }
                }
            }
        }
    }
}

