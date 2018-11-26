using StorageLibs.Utility;

namespace StorageLibs.Classes.Base
{
    public class Good
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }


        public Good(string _name, int _volume, decimal _pricePerUnit)
        {
            Name = _name;
            Volume = _volume;
            Price = _pricePerUnit;
        }
    }
}
