using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageLibs.Utility
{
    public static class Randomizer
    {
        public static decimal GetAccountValue()
        {
            Random rnd = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            var body = rnd.Next(2000, 75000);
            var add = rnd.Next(0, 1000) * rnd.NextDouble();
            var AV = body + add;
            Logger.SendLogMessage("Generated value = " + AV.ToString());
            return Convert.ToDecimal(AV);
        }

        public static decimal GetAccountValue(int min, int max)
        {
            Random rnd = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            var body = rnd.Next(min,max);
            var add = rnd.Next(0, 1000) * rnd.NextDouble();
            var AV = body + add;
            Logger.SendLogMessage("Generated value = " + AV.ToString());
            return Convert.ToDecimal(AV);
        }

        public static string GetRandomName()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            string[] Names = { "Bobby's storage", "Щящлик у дяди Вахтанга", "D-Storage", "IKEA", "Space-X", "Еще один склад", "Фантазия кончилась", "Что же делать?"};

            return Names[rnd.Next(0, Names.Length - 1)];
        }
    }
}
