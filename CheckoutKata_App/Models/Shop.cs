using System;
namespace CheckoutKata_App.Models
{
    public class Shop
    {
        public List<ShopItem> ShopItems { get; set; }
        public List<ShopPromotion> ShopPromotions { get; set; }
        public List<ShopItem> UserBasket { get; set; }

        public Shop()
        {
            ShopItems = new List<ShopItem>();
            UserBasket = new List<ShopItem>();
            ShopPromotions = new List<ShopPromotion>();
        }

        //Used to calculate to total of the users basket
        public decimal CalculateTotal()
        {
            decimal basketTotal = 0;


            //loop through the users basket
            foreach (var product in UserBasket)
            {
                basketTotal += product.UnitPrice;
            }



            //Return the basket total
            return basketTotal;
        }

        //TODO add the ability to calculate the toal with the promotions in mind

    }
}

