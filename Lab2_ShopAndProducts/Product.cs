using System;

namespace Lab2_ShopAndProducts
{
    class Product
    {
        public Guid ID;
        public string Name;
        public Product(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }
    }
}
