using System;
namespace CheckoutKata_App.Models
{
    public class Shop
    {


        public List<ShopItem> ShopItems { get; set; }
        public List<ShopItem> UserBasket { get; set; }
        public List<ShopPromotion> ShopPromotions { get; set; }


        public Shop()
        {
            ShopItems = new List<ShopItem>();
            UserBasket = new List<ShopItem>();
            ShopPromotions = new List<ShopPromotion>();
        }
    }
}

