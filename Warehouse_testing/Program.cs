using System;
using WarehouseLibrary;

namespace WarehouseApp
{
    class Program
    {
        /*
        НА ДОРАБОТКУ:
        -в методах, где для параметра принимается employees, добавить явное приведение типов (позволит использоваться функцианал методов не только для employees[]);
        -AddEmployeesInMainMenu - устранить баг;

    *****-day15_task2:
        - Task 2. Virtual class.          Optional task. I’m not quite sure that’s possible but you can try.
        Create a separate base service class with abstract/virtual methods. Inheritance this class on Warehouse services. 
        Try to imagine how you can create general methods as abstract/virtual in your base class.
        -для моего кода, вижу вариант для реализации метода Display, но не делал т.к. \то консольное приложение.



        */
        static void Main(string[] args)
        {
            Warehouse myWarehouse = new Warehouse("Bag&socks", "Belarus, 1 str.", "+375293628848", 5);
            WarehouseService warehouseService = new WarehouseService();
            Person[] persons = new Employee[0];
            Employee[] employees = (Employee[])persons;
            while (true) 
            {
                Console.WriteLine("Welcom to Warehouse");
                Console.WriteLine("\n1. Display info(title, address, contact number)");
                Console.WriteLine("2. Update info(for instance, update contact number)");
                Console.WriteLine("3. Clear all info about Warehouse(re - create Warehouse)");
                Console.WriteLine("4. Display info about free vacancies");
                Console.WriteLine("5. Display the list of Employees");
                Console.WriteLine("6. Add employee");
                Console.WriteLine("7. Search the employee by Name and Surname");
                Console.WriteLine("8. Update employee info");
                Console.WriteLine("9. Quit employee(remove)");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                int operation= TrySetNumber();
                Console.ResetColor();
                switch (operation) //main menu
                {
                    case 1://Display info(title, address, contact number
                        {
                            Console.Clear();
                            Console.WriteLine("Information about your warehouse:");
                            DisplayInfo(myWarehouse);
                            break;
                        }
                    case 2://Update info(for instance, update contact number)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the number of line that you want to change");
                            PrintVacations();
                            Console.ForegroundColor = ConsoleColor.Green;
                            int numOfLine = TrySetNumber();
                            Console.ResetColor();
                            if (numOfLine == 4)
                            {
                                Console.WriteLine($"Total vacation now: {myWarehouse.Vacations}");
                                Console.WriteLine($"Total free vacation now: {myWarehouse.Vacations - myWarehouse.Employees.Length}");
                                UpdateWarehouseInfo(myWarehouse, numOfLine);
                                break;
                            }
                            UpdateWarehouseInfo(myWarehouse, numOfLine);
                            break;
                        }
                    case 3://Clear all info about Warehouse(re - create Warehouse)
                        {
                            Console.Clear();
                            warehouseService.CleareInfo(myWarehouse);
                            break;

                        }
                    case 4://Display info about free vacancies
                        {
                            Console.Clear();
                            Console.WriteLine($"Free vacation now: {myWarehouse.Vacations - myWarehouse.Employees.Length}\n");
                            break;
                        }
                    case 5://Display the list of Employees
                        {
                            Console.Clear();
                            Console.WriteLine("List of employees:");
                            DisplayEmployeeList(employees);
                            break;
                        }
                    case 6://add employee info
                        {
                            Console.Clear();
                            Console.WriteLine("How many employees do you want to add?");
                            Console.ForegroundColor = ConsoleColor.Green;
                            int numOfEmployees = TrySetNumber();
                            Console.ResetColor();
                            AddEmployeesInMainMenu(numOfEmployees);
                            AddEmployeeInfo(numOfEmployees);
                            break;
                        }
                    case 7://Search the employee by Name and Surname
                        {
                            Console.Clear();
                            Console.WriteLine("Enter searcing name");
                            string searcingName = Console.ReadLine();
                            Console.WriteLine("Enter searcing surname");
                            string searchingSurname = Console.ReadLine();
                            DisplayEmployeeList(warehouseService.SearchEmployee(employees, searcingName, searchingSurname));
                            break;
                        }
                    case 8://Update employee info
                        {
                            Console.Clear();
                            Console.WriteLine("Choose how do you want to find employee for updating info:\n 1. By select number of employee from employees list;\n 2. Find by name and surname;");
                            Console.ForegroundColor = ConsoleColor.Green;
                            int selection = TrySetNumber();
                            Console.ResetColor();
                            switch (selection)
                            {
                                case 1://choose in list
                                    {
                                        Console.Clear();
                                        Console.WriteLine("List of employees:");
                                        DisplayEmployeeList(employees);
                                        Console.WriteLine("\nEnter employee's ID that you want to change: ");
                                        string searchingID = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.ResetColor();
                                        PersonFieldsNames();
                                        for (int i = 0; i < employees.Length; i++)//можно улучшить использовав не линейный поиск
                                        {
                                            if (Convert.ToString(employees[i].PersonID) == searchingID)
                                            {
                                                UpdateEmployeeInfo(employees[i]);
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
                                        DisplayEmployeeList(warehouseService.SearchEmployee(employees, searcingName, searchingSurname));//searching person
                                        Console.WriteLine("\nEnter employee's ID that you want to change: ");
                                        string searchingID = Console.ReadLine();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.ResetColor();                                        
                                        PersonFieldsNames();                                        
                                        for (int i = 0; i < employees.Length; i++)//можно улучшить использовав не линейный поиск
                                        {
                                            if (Convert.ToString(employees[i].PersonID) == searchingID)
                                            {
                                                UpdateEmployeeInfo(employees[i]);
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    Console.Clear();
                                    break;
                            }
                            break;
                        }
                    case 9://Quit employee(remove)
                        {
                            Console.WriteLine("Enter number of employee from Employees list: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            int numOfEmployeeForQuit = TrySetNumber();
                            Console.ResetColor();
                            warehouseService.QuitEmployee(myWarehouse, ref employees, numOfEmployeeForQuit);
                            Console.Clear();
                            break;
                        }
                    default://excaption
                        Console.WriteLine("Wrong selection!");
                        break;
                }//main menu
            }
            void DisplayEmployeeList(Employee[] employees)
            {
                Array.Sort(employees);
                if (myWarehouse.Employees.Length > 0)
                {
                    Console.WriteLine($"name|age|Job position|home address|contact number|education|ID");
                    for (int i = 0; i < employees.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {employees[i].Name} {employees[i].Surname}|{employees[i].Age}|{employees[i].Job}|{employees[i].HomeAddress}|{employees[i].ContactNumber}|{employees[i].Education}|{employees[i].PersonID}");
                    }
                }
                else
                {
                    Console.WriteLine("Now you have 0 employee with that name.");
                }
            }
            void DisplayInfo(Warehouse myWarehouse)
            {
                Console.WriteLine(myWarehouse.Title);
                Console.WriteLine(myWarehouse.Address);
                Console.WriteLine(myWarehouse.ContactNumber);
                Console.WriteLine($"number of employees: {myWarehouse.Employees.Length}");
                int freeVacations = myWarehouse.Vacations - myWarehouse.Employees.Length;
                Console.WriteLine($"number of free vacation: {freeVacations}");
                Console.WriteLine();
            }//Display info about warehouse
            Warehouse UpdateWarehouseInfo(Warehouse myWarehouse, int lineForChanging)
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
            }//Update info in selected field of warehouse
            void AddEmployeesInMainMenu(int numOfEmployees)//баг если вводишь не число
            {
                if ((myWarehouse.Vacations - myWarehouse.Employees.Length) >= numOfEmployees)
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    int age = TrySetNumber();
                    EnumVacation job = 0;
                    Console.ResetColor();
                    Console.WriteLine("Select employee's job position:");
                    PrintVacations();
                    Console.ForegroundColor = ConsoleColor.Green;
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
                    Console.Clear();

                    employees[employees.Length - 1] = new Employee(name, surname, age, job, homeAddress, contactNumber, education);
                }
                else if (numOfEmployees > 1)// multy adding employees
                {
                    for (int i = 0; i < employees.Length; i++)
                    {
                        Console.WriteLine($"Enter information for {i+1} employee");
                        Console.WriteLine("Enter employee's name");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string name = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("Enter employee's surname*");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string surname = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("Enter employee's age");
                        Console.ForegroundColor = ConsoleColor.Green;
                        int age = TrySetNumber();
                        EnumVacation job = 0;
                        Console.ResetColor();
                        Console.WriteLine("Select employee's job position:");
                        PrintVacations();
                        Console.ForegroundColor = ConsoleColor.Green;
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
                        Console.Clear();
                        employees[employees.Length - numOfEmployees + i] = new Employee(name, surname, age, job, homeAddress, contactNumber, education);
                    }
                }
            }
            void PersonFieldsNames()
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
            void UpdateEmployeeInfo(Employee employee)
            {
                int numOfLineForChanging;
                bool isWorking = true;
                do
                {
                    Console.WriteLine("Enter the number of information that you want to change:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    numOfLineForChanging = TrySetNumber();
                    Console.ResetColor();
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
                                Console.ForegroundColor = ConsoleColor.Green;
                                employee.Age=TrySetNumber();
                                Console.ResetColor();
                                break;
                            }
                        case 4:
                            {
                               Console.ResetColor();
                                Console.WriteLine("Select employee's job position:");
                                PrintVacations();
                                Console.ForegroundColor = ConsoleColor.Green;
                                int selection=TrySetNumber();
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
                                Console.ResetColor();
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

            void PrintVacations ()
            {
                foreach (var position in Enum.GetNames(typeof(EnumVacation)))
                {
                    Console.WriteLine($"{1+1}. {position}");
                }
            }
            static int TrySetNumber()
            {
                int value = 0;
                bool process = true;
                while (process)
                {
                    if (int.TryParse(Console.ReadLine(),out value))
                    {
                        process = false;
                    }
                    else
                    {
                        Console.WriteLine("Input error, default value is 0");
                    }
                }
                return value;
            }

        }
    }
}



