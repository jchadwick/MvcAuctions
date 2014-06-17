using OpenQA.Selenium;

namespace Website.Automation
{
    public class LoginPage : Page
    {
        public LoginPage()
            : base("/login")
        {
        }

        public string Username
        {
            set
            {
                driver.FindElement(By.Id("UserName")).Clear();
                driver.FindElement(By.Id("UserName")).SendKeys(value);
            }
        }

        public string Password
        {
            set
            {
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys(value);
            }
        }

        public void AuthenticateUser()
        {
            driver.FindElement(By.Id("authenticate-user")).Click();
        }
    }
}