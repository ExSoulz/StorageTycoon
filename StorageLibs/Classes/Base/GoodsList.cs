using StorageLibs.Classes.Base;

namespace StorageLibs
{
    public static class GoodsList
    {
        public static Good Cars = new Good("Машины", 3, 500);
        public static Good Electronics = new Good("Электроника", 1, 50);
        public static Good Materials = new Good("Стройматериалы", 1, 25);
        public static Good Grossery = new Good("Продукты питания", 1, 10);
        public static Good Medicine = new Good("Мед.Препараты", 1, 250);
        public static Good Weapons = new Good("Оружие", 2, 1500);
        public static Good Humans = new Good("Люди", 10, 5000);
    }
}
