
using System;
using static System.Environment;
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

            //Display all of the items the user can buy
            displayItems(currentShop.ShopItems, currentShop.ShopPromotions);

            int userInput = 1;

            while (userInput != 0)
            {
                userInput = getUserInput();

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine(
                               "You chose (1), these are the items available to purchase: " + NewLine
                           );
                        displayItems(currentShop.ShopItems, currentShop.ShopPromotions);
                        break;
                    default:
                        Console.WriteLine("Invalid input, try again!");
                        break;

                }
            }








        }

        //Used to fetch the user input from the console
        static public int getUserInput()
        {
            

                int currentChoice = 0;
                Console.WriteLine(NewLine);
                Console.WriteLine(
                    "Press (0) to exit, (1) to view shop items"
                );

                currentChoice = int.Parse(Console.ReadLine());
                return currentChoice;

         

        }

        //Used to display a list of Shop items and their promotions
        static public void displayItems(
            List<ShopItem> shopItems,
            List<ShopPromotion> shopPromotions
        )
        {
            if (shopItems.Count != 0)
            {
                //Display all the available items to the user
                foreach (var i in shopItems)
                {
                    //Search the promotions list for the item SKU
                    var foundPromotion = shopPromotions.FirstOrDefault(p => p.ItemSKU == i.ItemSKU);

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
