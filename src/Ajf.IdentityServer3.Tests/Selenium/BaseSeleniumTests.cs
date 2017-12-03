using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Ajf.IdentityServer3.Tests.Selenium
{
    public class BaseSeleniumTests
    {
        private Process _iisProcess;
        public RemoteWebDriver ChromeDriver { get; set; }

        public Uri BaseUri { get; set; }

        private void StartIIS()
        {
            var applicationPath =Path.GetFullPath(@"C:\Projects\Ajf.IdentityServer\src\Ajf.IdentityServer3");
            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            _iisProcess = new Process();
            _iisProcess.StartInfo.FileName = programFiles + @"\IIS Express\iisexpress.exe";
            _iisProcess.StartInfo.Arguments = string.Format("/path:\"{0}\" /port:{1}", applicationPath, 44317 );
            _iisProcess.Start();
        }

        [SetUp]
        public void SetUp()
        {
            if (ConfigurationManager.AppSettings["Environment"] == "Dev")
            {
                StartIIS();
            }
            BaseUri = new Uri(ConfigurationManager.AppSettings["IdentityServerApplicationUrl"]);

            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
            ChromeDriver.Navigate().GoToUrl(BaseUri);
        }

        [TearDown]
        public void TearDown()
        {
            ChromeDriver?.Dispose();
        }

        protected void LoginFrank()
        {
            var emailTextBox = ChromeDriver.FindElementById("Email");
            emailTextBox.Clear();
            emailTextBox.SendKeys("frank@email.dk");

            var passwordTextBox = ChromeDriver.FindElementById("Password");
            passwordTextBox.Clear();
            passwordTextBox.SendKeys("Frank1");

            var logInElement = ChromeDriver.FindElementById("LogIn");
            logInElement.Click();
        }
    }
}