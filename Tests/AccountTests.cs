using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests
{
    [TestFixture]
    public class AccountTests : AutomationTestFixture
    {
        [Test]
        public void ShouldAuthenticateRegisteredUser()
        {
            var username = "testuser";
            var password = "password";

            AuthenticateUser(username, password);
        }
    }
}
