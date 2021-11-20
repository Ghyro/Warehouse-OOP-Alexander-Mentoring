using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public interface ICommonServises
    {
        public static void Sort<T>(T[] list) where T : IComparable<T>
        {
        }
    }
}
