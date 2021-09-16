using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Remove_everything_from_startup
{
    class Program
    {
        static void Main(string[] args)
        {

            ManagementClass cls2 = new ManagementClass("Win32_StartupCommand");
            ManagementObjectCollection coll2 = cls2.GetInstances();

            foreach (ManagementObject obj in coll2)
            {
                Console.WriteLine(obj["Location"].ToString());
                Console.WriteLine(obj["Command"].ToString());
                Console.WriteLine(obj["Description"].ToString());
                Console.WriteLine(obj["Name"].ToString());
                Console.WriteLine(obj["Location"].ToString());
                Console.WriteLine(obj["User"].ToString());

            }
            /////////////////
            ManagementClass cls = new ManagementClass("Win32_StartupCommand");
            ManagementObjectCollection coll = cls.GetInstances();

            foreach (ManagementObject obj in coll)
            {
                string name = (obj["Name"].ToString());
                string loc = obj["Location"].ToString();

                Console.WriteLine(name);
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue(name, false);
                }
            }
            Console.WriteLine("\n\n-----------------------------After operation.....\nThis remains (Deafult windows)\n");
            /////////////////////////////////////////////////////////////////////
            ManagementClass cls1 = new ManagementClass("Win32_StartupCommand");
            ManagementObjectCollection coll1 = cls1.GetInstances();

            foreach (ManagementObject obj in coll1)
            {
                Console.WriteLine(obj["Location"].ToString());
                Console.WriteLine(obj["Command"].ToString());
                Console.WriteLine(obj["Description"].ToString());
                Console.WriteLine(obj["Name"].ToString());
                Console.WriteLine(obj["Location"].ToString());
                Console.WriteLine(obj["User"].ToString());

            }
            Console.ReadLine();


        }
    }
}
