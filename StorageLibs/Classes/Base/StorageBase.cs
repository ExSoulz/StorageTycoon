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
        #endregion

        #region Fields

        int StorageVolumeMax { get; set; }
        bool IsStorageFull { get { return CurentVolume == StorageVolumeMax; } }

        Dictionary<Good, int> Goods { get; set; }


        public string Title { get; private set; }
        public Person Owner { get; private set; }
        public int CurentVolume { get; private set; }

        #endregion

        #region Constructors

        public StorageBase(string _title, int _maxVolume, Person _owner)
        {
            Title = _title;
            StorageVolumeMax = _maxVolume;
            Owner = _owner;
            Goods = new Dictionary<Good, int>();
        }

        public StorageBase(Person _owner)
        {

            Goods = new Dictionary<Good, int>();
        }


        #endregion

        public Dictionary<Good, int> GetGoodsInStorage => Goods;

        public int GetAmountOfGoodInStorage(Good _good) => Goods[_good];

        public bool TransferGoods(Good _good, int _amount, StorageBase _storageTo)
        {
            var price = _good.Price * _amount;
            if (!_storageTo.IsStorageFull && _storageTo.Owner.CanAffordIt(_good, _amount))
            {
                _storageTo.AddGood(_good, _amount, this);
                _storageTo.Owner.LowerBalance(price);
                this.Owner.RiseBalance(price);
                GoodsSoldEvent(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, true));
                return true;
            }
            else
            {
                if (!_storageTo.IsStorageFull) _storageTo.NotEnoughtFreeSpaceEvent(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, false));
                if (!_storageTo.Owner.CanAffordIt(_good, _amount)) _storageTo.NotEnoughtMoneyEvent(Transaction.GenerateStructure(this, _storageTo, _good, _amount, price, false));
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
            GoodsRecievedEvent(Transaction.GenerateStructure(_storageFrom, this, _good, _amount, price, false));
        }

        public void DismissGood(Good _good, int _amount) => Goods[_good] -= _amount;

        private bool IsGoodAlreadyExists(Good _good) => Goods.ContainsKey(_good);


    }
}
