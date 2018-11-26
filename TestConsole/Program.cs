using System;
using StorageLibs.Utility;
using StorageLibs.Classes;
using StorageLibs.Classes.Base;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogMessage += MSG;

        }

        public static void MSG(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
