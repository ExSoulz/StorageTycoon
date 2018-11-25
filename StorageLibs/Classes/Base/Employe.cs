using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibs.Classes.Base
{
    public class Employe
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public decimal Salary { get; set; }
        public bool StillWorking { get; private set; }

        public decimal AccountBalance { get; private set; }

        public decimal RecieveMoney(decimal amount)
        {
            AccountBalance += amount;
            return AccountBalance;
        }

        public decimal SpendMoney(decimal amount)
        {
            AccountBalance -= amount;
            return AccountBalance;
        }

        public bool FireOff()
        {
            StillWorking = false;
            return StillWorking;
        }

        public Employe(int _age, string _name)
        {
            Age = _age;
            Name = _name;
            Salary = StorageLibs.Utility.Randomizer.GetAccountValue();
        }
    }
}
