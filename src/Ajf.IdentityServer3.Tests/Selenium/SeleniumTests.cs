using NUnit.Framework;

namespace Ajf.IdentityServer3.Tests.Selenium
{
    [TestFixture]
    [Category("Selenium")]
    public class SeleniumTests : BaseSeleniumTests
    {
        [Test]
        public void ThatMainPageCanBeShown()
        {
            var findElementByClassName = ChromeDriver.FindElementByClassName("icon");
            
            Assert.IsNotNull(findElementByClassName);
            Assert.AreEqual(findElementByClassName.TagName,"img");
        }
    }
}