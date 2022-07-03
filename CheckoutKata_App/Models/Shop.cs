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
            decimal basketSaving = 0;

            //loop through the users basket
            foreach (var product in UserBasket)
            {
                basketTotal += product.UnitPrice;
            }


            //loop through the promotions
            foreach (var promotion in ShopPromotions)
            {
                basketSaving += CalculateSaving(promotion, UserBasket);
            }



            //Return the basket total with the discount removed
            return basketTotal - basketSaving;
        }

        //Used to calculate the total saving for one promotion
        private decimal CalculateSaving(ShopPromotion promotion, List<ShopItem> basket)
        {
            int numOfItems = 0;
            decimal saving = 0;

            //Find the number of items in the basket that fit in the current promotion
            numOfItems = basket.Count(item => item.ItemSKU == promotion.ItemSKU);
            //Calculate the saving based of num of items / how many needed for the promotion. Then * saving amount
            saving = (numOfItems / promotion.ItemCount) * promotion.PriceSaving;

            return saving;
        }
    }
}

