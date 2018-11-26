using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibs.Classes.Base
{
    public class Person
    {

        public delegate void PersonEventsDelegate(string message);
        public delegate void PersonWalletEventsDelegate(decimal walletChange);

        public event PersonEventsDelegate StorageAlreadyExistsEvent;
        public event PersonEventsDelegate StorageAdded;
        /// <summary>
        /// Отображает количество "Денег" после изменения баланса
        /// </summary>
        public event PersonWalletEventsDelegate WalletChange;

        public Person(string _name, string _secondName, decimal _accountBalance)
        {
            Name = _name;
            SecondName = _secondName;
            AccountBalance = _accountBalance;
        }

        public string Name { get; private set; }
        public string SecondName { get; private set; }
        public Dictionary<string, StorageBase> StoragesOwned { get; private set; }
        public decimal AccountBalance { get; private set; }


        public bool CanAffordIt(Good _good, int _amount)
        {
            var total = _good.Price * _amount;
            return AccountBalance < total ? false : true;
        }

        public void RiseBalance(decimal _amount)
        {
            AccountBalance += _amount;
            try { WalletChange(AccountBalance); } catch { }
        }

        public void LowerBalance(decimal _amount)
        {
            AccountBalance -= _amount;
            try { WalletChange(AccountBalance); } catch { }
        }
        


        public void NewStorage(StorageBase _storageParams)
        {
            if (!StoragesOwned.ContainsKey(_storageParams.Title))
            {
                StoragesOwned.Add(_storageParams.Title, _storageParams);
                StorageAdded("Склад добавлен");
            }
            else
            {
                StorageAlreadyExistsEvent($"Склад с таким именем уже существует");
            }
        }

    }
}
