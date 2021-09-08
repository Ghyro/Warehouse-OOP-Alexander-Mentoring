using System;
using WarehouseLibrary;

namespace WarehouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse myWarehouse = new Warehouse("Store", "Belarus", "+375293628848", 5);
            WarehouseService warehouseService = new WarehouseService();
            Employee[] employees = new Employee[1];
            int freeVacation = myWarehouse.Vacations - (employees.Length - 1);
            while (true)
            {
                Console.WriteLine("1. Display info(title, address, contact number");
                Console.WriteLine("2. Update info(for instance, update contact number");
                Console.WriteLine("3. Clear all info about Warehouse(re - create Warehouse");
                Console.WriteLine("4. Display info about free vacancies");
                Console.WriteLine("5. Keep the list of Employees");
                Console.WriteLine("6. Add employee");
                Console.WriteLine("7. Search the employee by Name and Surname");
                Console.WriteLine("8. Quit employee(remove)");


                int operation = int.Parse(Console.ReadLine());
                switch (operation) //main menu
                {
                    case 1://Display info(title, address, contact number
                        {
                            Console.WriteLine("Information about your warehouse");
                            warehouseService.DisplayInfo(myWarehouse);
                            break;
                        }
                    case 2://Update info(for instance, update contact number
                        {
                            Console.WriteLine("Enter the number of line that you want to change");
                            Console.WriteLine("1.Title, 2.Address, 3.Contact number, 4.Vacation");
                            int numOfLine = int.Parse(Console.ReadLine());
                            if (numOfLine == 4)
                            {
                                Console.WriteLine($"Total vacation now: {myWarehouse.Vacations}");
                                Console.WriteLine($"Total free vacation now: {freeVacation}");
                                warehouseService.UpdateInfo(myWarehouse, numOfLine);
                                break;
                            }
                            warehouseService.UpdateInfo(myWarehouse, numOfLine);
                            break;
                        }
                    case 3://Clear all info about Warehouse(re - create Warehouse
                        {
                            warehouseService.CleareInfo(myWarehouse);
                            break;
                        }
                    case 4://Display info about free vacancies
                        {
                            Console.WriteLine($"Total free vacation now: {freeVacation}");
                            break;
                        }
                    case 5://Keep the list of Employees
                        {
                            Console.WriteLine("List of employees:");
                            Console.WriteLine($"name|age|Job position|home address|contact number|education");
                            KeepEmployeeList(employees);
                            break;
                        }
                    case 6://add employee
                        {
                            Console.WriteLine("Fields with * are required");
                            Console.WriteLine("Enter you name");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Enter you surname*");
                            string Surname = Console.ReadLine();
                            Console.WriteLine("Enter you age");
                            int Age = int.Parse(Console.ReadLine());
                            EnumVacation Job = 0;
                            Console.WriteLine("Select your job position:\n1.accountant\n2.cleaner\n3.director\n4.manager\n5.storekeeper");
                            int selection = int.Parse(Console.ReadLine());
                            switch (selection)
                            {
                                case 1:
                                    {
                                        Job = EnumVacation.accountant;
                                        break;
                                    }
                                case 2:
                                    {
                                        Job = EnumVacation.cleaner;
                                        break;
                                    }
                                case 3:
                                    {
                                        Job = EnumVacation.director;
                                        break;
                                    }
                                case 4:
                                    {
                                        Job = EnumVacation.manager;
                                        break;
                                    }
                                case 5:
                                    {
                                        Job = EnumVacation.storekeeper;
                                        break;
                                    }
                                default:
                                    break;

                            }
                            Console.WriteLine("Enter you home address*");
                            string HomeAddress = Console.ReadLine();
                            Console.WriteLine("Enter you contact address*");
                            string ContactNumber = Console.ReadLine();
                            Console.WriteLine("Enter you education");
                            string Education = Console.ReadLine();
                            employees[employees.Length - 1] = new Employee(Name, Surname, Age, Job, HomeAddress, ContactNumber, Education);
                            break;
                        }
                    case 7://Search the employee by Name and Surname
                        {
                            Console.WriteLine("Enter searcing name");
                            string searcingName = Console.ReadLine();
                            Console.WriteLine("Enter searcing surname");
                            string searchingSurname = Console.ReadLine();
                            KeepEmployeeList(warehouseService.SearchEmployee(employees, searcingName, searchingSurname));
                            break;
                        }
                    case 8://Quit employee(remove)
                        {
                            Console.WriteLine("Enter number of employee from Employees list: ");
                            int numOfEmployeeForQuit = int.Parse(Console.ReadLine());
                            warehouseService.QuitEmployee(employees, numOfEmployeeForQuit);
                            break;
                        }
                    default://excaption
                        Console.WriteLine("Wrong selection!");
                        break;
                }
                void KeepEmployeeList(Employee[] employees) //перенёс в програм, т.к. получается ошибка от сюда. почему?
                {
                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine($"{0}. {employee.Name} {employee.Surname}|{employee.Age}|{employee.Job}|{employee.HomeAddress}|{employee.ContactNumber}|{employee.Education}",+1);
                    }
                }
            }
        }
    }
}

