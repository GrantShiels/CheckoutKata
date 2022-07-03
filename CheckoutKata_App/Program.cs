
using System;
using CheckoutKata_App.Models;

namespace KataConsole
{
    public class Program
    {

        static void Main(string[] args)
        {

            //Create a new Shop item on start
            Shop currentShop = new Shop();

            //Load in the default shop items from the word document
            currentShop.ShopItems.Add(new ShopItem('A', 10));
            currentShop.ShopItems.Add(new ShopItem('B', 15));
            currentShop.ShopItems.Add(new ShopItem('C', 40));
            currentShop.ShopItems.Add(new ShopItem('D', 55));

            //create the default shop promotions
            currentShop.ShopPromotions.Add(new ShopPromotion('B', 3, 5, "3 for 0"));
            currentShop.ShopPromotions.Add(
                new ShopPromotion('D', 2, 27.50M, "25% off for every 2 purchased together")
            );

            if (currentShop.ShopItems.Count != 0)
            {
                //Display all the available items to the user
                foreach (var i in currentShop.ShopItems)
                {
                    //Search the promotions list for the item SKU
                    var foundPromotion = currentShop.ShopPromotions.FirstOrDefault(p => p.ItemSKU == i.ItemSKU);

                    //if a promotion was found display the promotion text
                    if (foundPromotion != null)
                    {
                        Console.WriteLine(
                            "Item SKU: "
                                + i.ItemSKU
                                + " | Unit Price: "
                                + i.UnitPrice
                                + " | Promotion: "
                                + foundPromotion.PromotionText
                        );
                    }
                    //If no promotion was found just display item info
                    else
                    {
                        Console.WriteLine(
                            "Item SKU: " + i.ItemSKU + " | Unit Price: " + i.UnitPrice + " |"
                        );
                    }
                }
            }
            else
            {
                Console.WriteLine("No Items found.");
            }







        }


    }
}
