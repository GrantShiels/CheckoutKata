using CheckoutKata_App.Models;

namespace CheckoutKata_Test;

public class CheckoutKataTests
{
    private Shop createTestShop()
    {
        Shop testShop = new Shop();
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

        return testShop;
    }





    //Used to test if the total will be 0 if no items are present
    [Fact]
    public void Empty_basket_returns_zero_total()
    {
        Shop newTestShop = createTestShop();
        Assert.Equal(0, newTestShop.CalculateTotal());
    }




    //Used to test the calculated price of a single item
    [Theory]
    [InlineData('A', 10)]
    [InlineData('B', 15)]
    [InlineData('C', 40)]
    [InlineData('D', 55)]
    public void Single_item_basket_check_price(char toTestSKU, int expectedValue)
    {

        Shop newTestShop = createTestShop();

        //get the item from the shop items
        var testItem = newTestShop.ShopItems.FirstOrDefault(i => i.ItemSKU == toTestSKU);

        if (testItem != null)
        {
            newTestShop.UserBasket.Add(testItem);
        }      

        Assert.Equal(expectedValue, newTestShop.CalculateTotal());
    }




}
