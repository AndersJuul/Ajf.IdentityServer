using NUnit.Framework;

namespace Ajf.IdentityServer3.Tests.Selenium
{
    [TestFixture]
    [Category("Selenium")]
    public class SeleniumTests : BaseSeleniumTests
    {
        [Test]
        public void ThatFrankCanLogin()
        {
            //LoginFrank();

            //Assert.AreEqual("Hovedside - Samkørsel", ChromeDriver.Title);
        }

        [Test]
        public void ThatApiReturnsEvents()
        {
            //ChromeDriver.Navigate().GoToUrl(new Uri(BaseUri,"api/event"));

            //Assert.AreEqual("Hovedside - Samkørsel", ChromeDriver.Title);
        }
    }
}