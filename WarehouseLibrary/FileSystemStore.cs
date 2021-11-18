using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseLibrary
{
    public static class FileSystemStore
    {
        public static void SaveData(string path, Warehouse warehouse)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, warehouse);
            }

        }
        public static void LoadData(string path, ref Warehouse warehouse)//TODO добавить проверку на существования файла (try-catch)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {  
                Warehouse deserilizeWarehouse = (Warehouse)formatter.Deserialize(fs);
                warehouse = deserilizeWarehouse;                
            }
        }
    }
}