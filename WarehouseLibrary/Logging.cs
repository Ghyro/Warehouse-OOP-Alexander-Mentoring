using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WarehouseLibrary
{
    public static class Logging
    {
        private static string path = @".\log.txt";
        public static void Log(string line, LogType logType)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                Guid id = Guid.NewGuid();
                file.WriteLine($"{DateTime.Now} | ID: {id} | {logType}! | {line}.");
            }
        }
    }
}