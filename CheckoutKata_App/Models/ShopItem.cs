using System;
namespace CheckoutKata_App.Models
{
    public class ShopItem
    {
        //Base properties of every item
        public char ItemSKU { get; set; }
        public decimal UnitPrice { get; set; }

        //Create new item from supplied parameters
        public ShopItem(char newSKU, decimal newPrice)
        {
            ItemSKU = newSKU;
            UnitPrice = newPrice;
        }

   
    }
}



