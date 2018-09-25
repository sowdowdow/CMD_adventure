using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccess
{
    public static class FileVars
    {
        internal static string _gameDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CMD_adventure");
        internal static string _saveName = @"\save.json";
        internal static string _logName = @"\logs.txt";
    }
}
