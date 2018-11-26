using System;
using StorageLibs.Utility;
using StorageLibs.Classes;
using StorageLibs.Classes.Base;
using StorageLibs;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.LogMessage += MSG;
            Init();

        }

        public static void MSG(string msg)
        {
            Console.WriteLine(msg);
        }


        public static void Init()
        {
            Person player = new Person("Евгений", "Шевцов", Randomizer.GetAccountValue(100, 100110));
            Person notPlayer = new Person("Hyper", "AI", 5000000);

            MasterStorage master = new MasterStorage();

            StorageBase playerStorage = new StorageBase("Склад 1", 500, player);
            Console.WriteLine(playerStorage.Owner.AccountBalance);

            playerStorage.GoodsRecievedEvent += ToConsole;
            playerStorage.GoodsSoldEvent += ToConsole;
            playerStorage.AddGood(GoodsList.Cars, 25, master);

            StorageBase aiStorage = new StorageBase(notPlayer);

            Console.WriteLine(aiStorage.Owner.Name);
            Console.WriteLine(aiStorage.Owner.AccountBalance);
            
            
            playerStorage.TransferGoods(GoodsList.Cars, 20, aiStorage);
            Console.WriteLine(playerStorage.Owner.AccountBalance);


        }

        private static void ToConsole(TransactionStruct transaction)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" = = = = = = = = = = ");
            Console.WriteLine($"{transaction.GoodsFrom.Title} продал {transaction.GoodsTo.Title} товар {transaction.Goods.Name} в количестве {transaction.Amount}шт. по цене {transaction.Goods.Price} за штуку на общую сумму в {transaction.MoneyTotal} ед. ");
            Console.WriteLine($"Склад: {transaction.GoodsFrom.Title}");
            Console.WriteLine($"Владелец: {transaction.GoodsFrom.Owner.Name} {transaction.GoodsFrom.Owner.SecondName}");
            Console.WriteLine($"Размер склада: {transaction.GoodsFrom.StorageVolumeMax}");
            Console.WriteLine($"Заполненность: {transaction.GoodsFrom.CurentVolume} ({transaction.GoodsFrom.CurentVolume / transaction.GoodsFrom.StorageVolumeMax / 100})");

            if (transaction.GoodsFrom.GetGoodsInStorage.Count > 0)
            {
                Console.WriteLine($"Товары на складе:");
                foreach ( KeyValuePair<Good,int> good in transaction.GoodsFrom.GetGoodsInStorage)
                {
                    Console.WriteLine($"Товар: {good.Key.Name} || Количество на складе {good.Value}шт");
                }
            }

            Console.WriteLine(" = = = = = = = = = = ");
            Console.WriteLine(" ");
        }
    }
}
