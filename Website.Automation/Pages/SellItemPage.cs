using OpenQA.Selenium;

namespace Website.Automation
{
    public class SellItemPage : Page
    {
        public SellItemPage()
            : base("/sell")
        {
        }

        public string Title
        {
            set
            {
                driver.FindElement(By.Id("Title")).Clear();
                driver.FindElement(By.Id("Title")).SendKeys(value);
            }
        }
        public string Description
        {
            set
            {
                driver.FindElement(By.Id("Description")).Clear();
                driver.FindElement(By.Id("Description")).SendKeys(value);
            }
        }

        public double StartingPrice
        {
            set
            {
                driver.FindElement(By.Id("StartingPrice")).Clear();
                driver.FindElement(By.Id("StartingPrice")).SendKeys(value.ToString());
            }
        }

        public AuctionDetailsPage ListItem()
        {
            driver.FindElement(By.Id("list-item")).Click();

            return new AuctionDetailsPage(driver);
        }
    }
}
