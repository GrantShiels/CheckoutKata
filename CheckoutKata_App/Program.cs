
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

            //display all the items to the user
            foreach(var i in currentShop.ShopItems)
            {
                Console.WriteLine(
                           "Item SKU: "
                               + i.ItemSKU
                               + " | Unit Price: "
                               + i.UnitPrice
                       );
            }




        }


    }
}
