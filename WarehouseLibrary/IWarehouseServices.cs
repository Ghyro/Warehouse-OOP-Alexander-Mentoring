using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public interface IWarehouseServices
    {
        void CleareInfo(ref Warehouse myWarehouse);
        void AddEmployee(Warehouse myWarehouse, int numOfAddingEmployees);
        void QuitEmployee(Warehouse myWarehouse, int numEmployeeInList);
        Person[] SearchEmployes(Warehouse myWarehouse, string searchingName, string searchingSurname);
    }
}
