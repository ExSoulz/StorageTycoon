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
            Good good = new Good();
            good.Name = "Компот";
            good.Price = 10;
            good.Volume = 2;
            Storage me = new Storage();
            me.Goods = new System.Collections.Generic.Dictionary<Good, int>();
            me.AccountBalance = 10000;
            Client client = new Client();
            me.StorageVolumeMax = 500;
            me.AddGood(good, 10, client);
            
        }

        public static void MSG(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
