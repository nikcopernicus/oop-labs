using System;
using System.Collections.Generic;

namespace Lab2_ShopAndProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop s1 = new Shop("Lenta", "address1");
            Shop s2 = new Shop("Diksi", "address2");
            Shop s3 = new Shop("Perekrestok", "address3");
            Product p1 = new Product("Apple");
            Product p2 = new Product("Pear");
            Product p3 = new Product("Pineapple");
            Product p4 = new Product("Tomato");
            Product p5 = new Product("Banana");
            Product p6 = new Product("Lemon");
            Product p7 = new Product("Mango");
            Product p8 = new Product("Orange");
            Product p9 = new Product("Meat");
            Product p10 = new Product("Fish");
            s1.AddProducts(
                new List<Shipment>{
                    new Shipment(p1, 10, 10),
                    new Shipment(p2, 2, 1),
                    new Shipment(p3, 10, 10),
                    new Shipment(p4, 3, 10),
                    new Shipment(p5, 4, 25),
                    new Shipment(p6, 10, 10),
                    new Shipment(p7, 2, 1),
                    new Shipment(p8, 10, 10),
                    new Shipment(p9, 4, 10),
                    new Shipment(p10, 6, 25)
                }
                );
            s2.AddProducts(
                new List<Shipment>{
                    new Shipment(p1, 10, 15),
                    new Shipment(p2, 2, 1),
                    new Shipment(p3, 10, 15),
                    new Shipment(p4, 3, 10),                    
                    new Shipment(p6, 10, 15),                    
                    new Shipment(p8, 10, 15),
                    new Shipment(p9, 3, 15),
                    new Shipment(p10, 4, 15)
                }
                );
            s3.AddProducts(
                new List<Shipment>{
                    new Shipment(p1, 10, 4),
                    new Shipment(p2, 2, 1),
                    new Shipment(p3, 10, 5),
                    new Shipment(p5, 3, 10),
                    new Shipment(p7, 10, 1),
                    new Shipment(p8, 10, 1),
                    new Shipment(p9, 5, 10),
                    new Shipment(p10, 8, 38)
                }
                );
            List<Shipment> purcashe100 = s1.PurcashingPossibility(100);
            foreach(Shipment purcashe in purcashe100)
            {
                Console.WriteLine("Можно купить " + purcashe.Product.Name + " в количестве " + purcashe.Amount + " шт ");
            }
            s2.AddProducts(
                new List<Shipment>{
                    new Shipment(p1, 10, 14),
                    new Shipment(p2, 20, 1)
                }
            );
            int amount = 15;
            double buy = s2.BuyProduct(p2, amount);
            if (buy == -1)
            {
                Console.WriteLine("Shop " + s2.Name + " dosn't have enough " + p2.Name);
            }
            else
            {
                Console.WriteLine("You spend " + buy + " money for buying " + amount + " of " + p2.Name + " in " + s2.Name);
            }
            buy = s3.BuyProduct(p2, amount);
            if (buy == -1)
            {
                Console.WriteLine("Shop " + s3.Name + " dosn't have enough " + p2.Name);
            }
            else
            {
                Console.WriteLine("You spend " + buy + " money for buying " + amount + " of " + p2.Name + " in " + s2.Name);
            }
            Town town=new Town(new List<Shop>{s1,s2,s3});
            Shop cheapestp1 = town.FindCheapestProduct(p1),
                cheapestp8_p10 = town.FindCheapestShipment(new List<Shipment>
                {
                    new Shipment(p8,10),
                    new Shipment(p9,4),
                    new Shipment(p10,5)
                });
            if (cheapestp1.ID == Guid.Empty)
            {
                Console.WriteLine("Shops doesn't have "+p1.Name);
            }
            else
            {
                Console.WriteLine(cheapestp1.Name + " is shop where is the cheapest " + p1.Name);
            }
            if (cheapestp8_p10.ID == Guid.Empty)
            {
                Console.WriteLine("Shops doesn't have enough products");
            }
            else
            {
                Console.WriteLine(cheapestp8_p10.Name + " is shop where is the cheapest shipment of products");
            }
        }
    }
}
