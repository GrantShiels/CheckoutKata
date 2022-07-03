using System;
using static System.Environment;
using CheckoutKata_App.Models;

namespace CheckoutKata_App
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
                        char toAddSKU;
                        int toAddQuantity;

                        //Get user input and verify that it is valid
                        try
                        {
                            Console.WriteLine(
                                "You chose (1), please enter the SKU of the item you want to add to your basket: "
                            );

                            toAddSKU = char.Parse(Console.ReadLine());

                            Console.WriteLine(
                                "Please enter the quantity of the item you want to add to your basket: "
                            );

                            toAddQuantity = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input, please try again");
                            break;
                        }

                        //Search for the user input SKU in the available items
                        var foundItem = currentShop.ShopItems.FirstOrDefault(
                            i => i.ItemSKU == toAddSKU
                        );

                        //if an item was found add it to the basket.
                        if (foundItem != null)
                        {
                            //loop through the quantity of items to add
                            for (int i = 0; i < toAddQuantity; i++)
                            {
                                //add the item to the basket
                                currentShop.UserBasket.Add(foundItem);
                            }

                            Console.WriteLine(NewLine);
                            Console.WriteLine("User Basket: ");
                            //after being added print the users basket and total
                            displayItems(currentShop.UserBasket, currentShop.ShopPromotions);
                            Console.WriteLine("Total : " + currentShop.CalculateTotal());
                            Console.WriteLine(NewLine);
                        }
                        //if not found inform the user
                        else
                        {
                            Console.WriteLine("There was no item found with the SKU : " + toAddSKU);
                        }

                        break;
                    //Display items in the basket
                    case 2:
                        Console.WriteLine(
                            "You chose (2), theses are the items in your basket: " + NewLine
                        );
                        displayItems(currentShop.UserBasket, currentShop.ShopPromotions);
                        Console.WriteLine(NewLine);
                        break;
                    //Display the items that are available to purchase
                    case 3:
                        Console.WriteLine(
                            "You chose (3), these are the items available to purchase: " + NewLine
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
            try
            {
                int currentChoice = 0;
                Console.WriteLine(NewLine);
                Console.WriteLine(
                    "Press (0) to exit, (1) to add an item to your basket, (2) to view your basket and total, (3) to view the items available for purchase"
                );

                currentChoice = int.Parse(Console.ReadLine());
                return currentChoice;
            }
            catch
            {
                return 4;
            }
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
