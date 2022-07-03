using System;
namespace CheckoutKata_App.Models
{   
    public class ShopPromotion
    {
        //Base properties of every promotion
        public char ItemSKU { get; set; }
        public int ItemCount { get; set; }
        public decimal PriceSaving { get; set; }
        public string PromotionText { get; set; }

        public ShopPromotion(
            char newSKU,
            int newCount,
            decimal newPriceSaving,
            string newPromotionText
        )
        {
            ItemSKU = newSKU;
            ItemCount = newCount;
            PriceSaving = newPriceSaving;
            PromotionText = newPromotionText;
        }
    }
    

}

