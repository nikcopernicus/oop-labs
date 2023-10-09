using System;

namespace Lab2_ShopAndProducts
{
    class Shipment
    {
        public Product Product;
        public int Amount;
        public double Price;
        public Shipment(Product product, int amount, double price)
        {
            Product = product;
            Amount = amount;
            Price = price;
        }
        public Shipment(Product product, int amount)
        {
            Product = product;
            Amount = amount;
            Price = Double.MaxValue;
        }
        public Shipment(Product product)
        {
            Product = product;
            Amount = Int32.MinValue;
            Price = Double.MaxValue;
        }
    }
}
