using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BP_LicenseAudit
{
    static class Log
    {
        private static string dir = "Log";
        private static string file = "log.log";
        private static string path = String.Format("{0}\\{1}", dir, file);

        private static bool checkSize(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            if (fi.Length > 10000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void WriteLog(String towrite)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(path))
            {
                if (checkSize(path))
                {
                    string newfile = String.Format("{0}\\{1}{2}", dir, DateTime.Now.ToString("yyyyMMddHHmmss"), file);
                    File.Move(path, newfile);
                }
            }
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(towrite);
            sw.Close();
        }
    }
}
