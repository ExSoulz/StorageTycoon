using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibs.Classes.Base
{
    public static class Transaction
    {
        public static TransactionStruct GenerateStructure(StorageBase _from, StorageBase _to, Good _goods, int _amount, decimal _moneyTotal, bool _result) 
            => new TransactionStruct(_from, _to, _goods, _amount, _moneyTotal, _result);
    }

    public struct TransactionStruct
    {
       public StorageBase GoodsFrom;
       public StorageBase GoodsTo;
       public Good Goods;
       public int Amount;
       public decimal MoneyTotal;
       public bool Result;

        public TransactionStruct(StorageBase _from, StorageBase _to, Good _goods, int _amount, decimal _moneyTotal, bool _result)
        {
            GoodsFrom = _from;
            GoodsTo = _to;
            Goods = _goods;
            Amount = _amount;
            MoneyTotal = _moneyTotal;
            Result = _result;
        }
    }
}
