using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Website.Automation;

namespace Tests
{
    [TestFixture]
    public class SellAnItemTests : AutomationTestFixture
    {
        [Test]
        public void AsARegisteredUser_IShouldBeAbleToListAnItemForAuction()
        {
            // Navigate to the Sell an Item page
            var page = Browser.NavigateTo<SellItemPage>();

            // Populate fields
            page.Title = "My new item for sale";
            page.Description = "This is an item for sale";
            page.StartingPrice = 12;

            // Submit the item for sale
            var auction = page.ListItem();

            // Validate that it worked
            Assert.IsTrue(auction.Success);
            Assert.AreEqual("My new item for sale", auction.Title);
            Assert.AreEqual(12, auction.CurrentPrice);
        }
    }
}