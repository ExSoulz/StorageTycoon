using System;
using StorageLibs.Utility;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogMessage += MSG;
            StorageLibs.Classes.Base.Employe emp = new StorageLibs.Classes.Base.Employe(25, "Vazgen");
        }

        public static void MSG(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
