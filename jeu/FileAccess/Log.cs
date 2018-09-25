using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public static class Log
    {
        public static void Add(string error)
        {
            Directory.CreateDirectory(FileVars._gameDirectory);
            Directory.CreateDirectory(FileVars._gameDirectory);

            string log = DateTime.Now.Date + ", " + DateTime.Now.TimeOfDay + "; " + error;
            File.AppendAllText(FileVars._gameDirectory + FileVars._logName, log);
        }
    }
}
