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
            if (warehouse==null)
            {
                warehouse = new Warehouse("","","",0);
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, warehouse);
            }
        }
        public static void LoadData(string path, ref Warehouse warehouse)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (!File.Exists(path))
            {
                return;
            }
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {  
                Warehouse deserilizeWarehouse = (Warehouse)formatter.Deserialize(fs);
                warehouse = deserilizeWarehouse;                
            }
        }
    }
}