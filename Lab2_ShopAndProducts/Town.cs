using System;
using System.Collections.Generic;

namespace Lab2_ShopAndProducts
{
    class Town
    {
        private List<Shop> Shops;
        public Town(List<Shop> shops)
        {
            Shops = shops;
        }
        public Shop FindCheapestProduct(Product product)
        {
            Shipment minproduct = new Shipment(product);
            Shop minShop = new Shop();
            foreach(Shop shop in Shops)
            {
                foreach(Shipment Shipment in shop.ProductsInShop)
                {
                    if (Shipment.Product.ID == minproduct.Product.ID)
                    {
                        if(Shipment.Price < minproduct.Price)
                        {
                            minproduct = Shipment;
                            minShop = shop;
                        }
                    }
                }
            }
            return minShop;
        }
        public Shop FindCheapestShipment(List<Shipment> products)
        {   
            Shop minShop = new Shop();
            double minPrice = Double.MaxValue;
            foreach (Shop shop in Shops)
            {
                double Price = 0;
                foreach (Shipment product in products)
                {
                    foreach (Shipment Shipment in shop.ProductsInShop)
                    {
                        if (Shipment.Product.ID == product.Product.ID)
                        {
                            if (Shipment.Amount >= product.Amount)
                            {
                                Price += product.Amount * Shipment.Price;
                                break;
                            }
                            else
                            {
                                Price = 0;
                                break;
                            }
                        }
                    }
                    if (Price == 0)
                    {
                        break;
                    }
                }
                if (minPrice >= Price && Price != 0)
                {
                    minPrice = Price;
                    minShop = shop;
                }
            }
            return minShop;
        }
    }
}
