using OpenQA.Selenium;

namespace Website.Automation
{
    public class AuctionDetailsPage
    {
        private readonly IWebDriver driver;

        public AuctionDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool Success
        {
            get
            {
                return Browser.IsElementPresent(By.CssSelector("div.alert.alert-success"));
            }
        }

        public string Title
        {
            get { return driver.FindElement(By.Id("auction-title")).Text; }
        }

        public double CurrentPrice
        {
            get
            {
                var priceText = driver.FindElement(By.CssSelector("span.current-price")).Text;
                return double.Parse(priceText.Replace("$", string.Empty));
            }
        }
    }
}