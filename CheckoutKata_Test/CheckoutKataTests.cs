using CheckoutKata_App.Models;

namespace CheckoutKata_Test;

public class CheckoutKataTests
{
    private Shop testShop = new Shop();

    internal void KataConsoleTests()
    {

        List<ShopItem> testShopItems = new List<ShopItem>();
        List<ShopPromotion> testShopPromotions = new List<ShopPromotion>();


        testShopItems.Add(new ShopItem('A', 10));
        testShopItems.Add(new ShopItem('B', 15));
        testShopItems.Add(new ShopItem('C', 40));
        testShopItems.Add(new ShopItem('D', 55));

        testShopPromotions.Add(new ShopPromotion('B', 3, 5, "3 for 40"));
        testShopPromotions.Add(
            new ShopPromotion('D', 2, 27.50M, "25% off for every 2 purchased together")
        );


        testShop.ShopItems = testShopItems;
        testShop.ShopPromotions = testShopPromotions;
        testShop.UserBasket = new List<ShopItem>();
    }






}
