using System.Collections.Generic;
using StorageLibs.Classes;
using StorageLibs.Classes.Base;
using StorageLibs.Utility;

namespace StorageLibs.Classes
{
    public class StorageBase
    {
        #region Events
        public delegate void StorageEventDelegate(TransactionStruct transaction);
        public event StorageEventDelegate NotEnoughtFreeSpaceEvent;
        public event StorageEventDelegate NotEnoughtMoneyEvent;
        public event StorageEventDelegate GoodsSoldEvent;
        public event StorageEventDelegate GoodsRecievedEvent;
        public event StorageEventDelegate NotEnoughtGoods;
        #endregion

        #region Fields

        public int StorageVolumeMax { get; private set; }
        bool IsStorageFull { get { return CurentVolume == StorageVolumeMax; } }

        public Dictionary<Good, int> Goods { get; set; }


        public string Title { get; set; }
        public Person Owner { get; set; }
        public int CurentVolume { get; set; }

        #endregion

        #region Constructors

        public StorageBase(string _title, int _maxVolume, Person _owner)
        {
            Title = _title;
            StorageVolumeMax = _maxVolume;
            Owner = _owner;
            Goods = new Dictionary<Good, int>();
            CurentVolume = 0;
        }

        public StorageBase(Person _owner)
        {
            Owner = _owner;
            Goods = new Dictionary<Good, int>();
            Title = Randomizer.GetRandomName();
            StorageVolumeMax = 9999999;
            Goods = new Dictionary<Good, int>();
            CurentVolume = 0;
        }

        public StorageBase()
        { }

        #endregion
        //  
        public Dictionary<Good, int> GetGoodsInStorage => Goods;

        public int GetAmountOfGoodInStorage(Good _good) => Goods[_good];

        public bool TransferGoods(Good _good, int _amount, StorageBase _storageTo)
        {
            var price = _good.Price * _amount;
            if (!_storageTo.IsStorageFull && _storageTo.Owner.CanAffordIt(_good, _amount) && (this.Goods[_good] > _amount))
            {
                _storageTo.AddGood(_good, _amount, this);
                _storageTo.Owner.LowerBalance(price);
                this.Owner.RiseBalance(price);
                try { GoodsSoldEvent(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, true)); } catch { }
                return true;
            }
            else
            {
                if (_storageTo.IsStorageFull) _storageTo.NotEnoughtFreeSpaceEvent(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, false));
                if (!_storageTo.Owner.CanAffordIt(_good, _amount)) _storageTo.NotEnoughtMoneyEvent(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, false));
                if (this.Goods[_good] < _amount) this.NotEnoughtGoods(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, false));
                GoodsSoldEvent(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, false));
                return false;
            }
        }

        public void AddGood(Good _good, int _amount, StorageBase _storageFrom)
        {
            
            var price = _good.Price * _amount;
            if (IsGoodAlreadyExists(_good))
            {
                Goods[_good] += _amount;
            }
            else
            {
                Goods.Add(_good, _amount);
            }
            _storageFrom.DismissGood(_good, _amount);
            if (_storageFrom.Title != "MASTER STORAGE") try { GoodsRecievedEvent(Transaction.GenerateStructure(_storageFrom, this, _good, _amount, price, false)); } catch { }

        }

        public void DismissGood(Good _good, int _amount) => Goods[_good] -= _amount;

        private bool IsGoodAlreadyExists(Good _good) => Goods.ContainsKey(_good);


    }
}
