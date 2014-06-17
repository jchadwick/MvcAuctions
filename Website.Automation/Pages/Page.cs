using OpenQA.Selenium;

namespace Website.Automation
{
    public abstract class Page
    {
        protected readonly IWebDriver driver = Browser.Driver;

        public virtual string Path { get; private set; }

        protected Page(string path)
        {
            Path = path;
        }
    }
}