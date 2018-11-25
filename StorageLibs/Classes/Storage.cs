using System.Collections.Generic;
using StorageLibs.Classes;
using StorageLibs.Classes.Base;
using StorageLibs.Utility;

namespace StorageLibs.Classes
{
    public class Storage
    {
        public string Title { get; set; }
        public int StorageVolumeMax { get; set; }
        public int CurentVolume { get; set; }
        public Dictionary<Good,int> Goods { get; set; }
        public decimal AccountBalance { get; set; }

        public bool AddGood(Good good, int units, Storage sender)
        {
            if ((good.Volume * units + CurentVolume) > StorageVolumeMax)
            {
                if (good.Price * units > AccountBalance)
                {
                    Logger.SendLogMessage("Наша казна пуста, мой лорд");
                    return false;
                }
                Logger.SendLogMessage("Наши склады полны, мой лорд");
                return false;
            }
            else
            {
                if (Goods.ContainsKey(good))
                {
                    Goods[good] += units;
                    
                }
                else
                {
                    Goods.Add(good, units);
                }
                Logger.SendLogMessage($"Нам прислали {good.Name} в количестве {units} ед. , мой лорд");
                StorageVolumeMax += units;
                this.AccountBalance -= good.Price * units;
                sender.AccountBalance += good.Price * units;

                return true;
            }
        }

        public bool SendGoods(Good good, int units, Client client)
        {
            var result = client.AddGood(good, units,this);
            if (result)
            {
                Logger.SendLogMessage("Товары доставлены, мой лорд");
                return result;
            }
            else
            {
                Logger.SendLogMessage("У холопов недостаточно места, мой лорд");
                return result;
            }
        }
    }
}
