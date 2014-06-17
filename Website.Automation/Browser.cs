using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Website.Automation
{
    public static class Browser
    {
        private static string baseURL = "http://localhost:3401";
        private static IWebDriver driver;

        internal static IWebDriver Driver
        {
            get { return driver; }
        }

        public static string CurrentUser
        {
            get { return driver.FindElement(By.Id("current-user")).Text; }
        }

        public static void Close()
        {
            driver.Close();
            driver.Quit();
        }

        public static void Initialize()
        {
            driver = new ChromeDriver();
        }

        public static void GoToUrl(string path)
        {
            var url = path.Contains("://") ? path : baseURL + path;
            driver.Navigate().GoToUrl(url);
        }

        public static TPage NavigateTo<TPage>() where TPage : Page, new()
        {
            var page = Activator.CreateInstance<TPage>();
            GoToUrl(page.Path);
            return page;
        }

        public static bool IsElementPresent(By @by)
        {
            try
            {
                return driver.FindElement(@by) != null;
            }
            catch
            {
                return false;
            }
        }
    }
}