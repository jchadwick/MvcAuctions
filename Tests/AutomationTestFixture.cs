using NUnit.Framework;
using OpenQA.Selenium;
using Website.Automation;

namespace Tests
{
    public class AutomationTestFixture
    {
        [SetUp]
        public void Setup()
        {
            var username = "testuser";
            var password = "password";

            AuthenticateUser(username, password);
        }

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            Browser.Initialize();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            Browser.Close();
        }

        protected void AuthenticateUser(string username, string password)
        {
            var loginPage = Browser.NavigateTo<LoginPage>();
            loginPage.Username = username;
            loginPage.Password = password;
            loginPage.AuthenticateUser();

            Assert.AreEqual(username, Browser.CurrentUser);
        }
    }
}