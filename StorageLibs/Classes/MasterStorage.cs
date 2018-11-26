using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibs.Classes.Base
{
    public class MasterStorage : StorageBase
    {
        public MasterStorage()
        {
            Title = "MASTER STORAGE";
            Owner = new Person("MASTER", "OWNER", 999999999);
            Goods = new Dictionary<Good, int>();
            Goods.Add(GoodsList.Cars, 999999);
            Goods.Add(GoodsList.Electronics, 9999999);
            Goods.Add(GoodsList.Grossery, 9999999);
            Goods.Add(GoodsList.Humans, 9999999);
            Goods.Add(GoodsList.Materials, 9999999);
            Goods.Add(GoodsList.Medicine, 9999999);
            Goods.Add(GoodsList.Weapons, 9999999);
        }
    }
}
