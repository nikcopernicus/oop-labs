using System;
using System.Collections.Generic;

namespace Lab2_ShopAndProducts
{
    class Shop
    {
        public Guid ID;
        public string Name, Address;
        public List<Shipment> ProductsInShop;
        public Shop()
        {
            ID = Guid.Empty;
            Name = "";
            Address = "";
            ProductsInShop = new List<Shipment>();
        }
        public Shop(string name, string address)
        {
            ID = Guid.NewGuid();
            Name = name;
            Address = address;
            ProductsInShop = new List<Shipment>();
        }
        public void AddProducts(List<Shipment> Shipment)
        {
            foreach (Shipment p in Shipment)
            {
                bool found = false;
                foreach (Shipment product in ProductsInShop)
                {
                    if (product.Product.ID == p.Product.ID)
                    {
                        found = true;
                        product.Amount += p.Amount;
                        product.Price = p.Price;
                        break;
                    }
                }
                if(!found)
                    ProductsInShop.Add(p);
            }
            return;
        }
        public List<Shipment> PurcashingPossibility(double money)
        {
            List<Shipment> shipments = new List<Shipment>();
            foreach (Shipment product in ProductsInShop)
            {
                double price = product.Price;
                int amount = product.Amount, answcount = 0;
                while (money - product.Price > 0 && amount > 0)
                {
                    money -= price;
                    amount--;
                    answcount++;
                }
                if (answcount > 0)
                {
                    shipments.Add(new Shipment(product.Product, answcount, product.Price));
                }
            }
            return shipments;
        }
        public double BuyProduct(Product product, int amount)
        {
            foreach(Shipment Shipment in ProductsInShop)
            {
                if (product.ID == Shipment.Product.ID)
                {
                    if(amount <= Shipment.Amount)
                    {
                        Shipment.Amount -= amount;
                        return amount * Shipment.Price;
                    }
                }
            }
            return -1;
        }
    }
}
