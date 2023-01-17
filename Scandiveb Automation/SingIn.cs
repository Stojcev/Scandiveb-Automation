 using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTask
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]

    class SingIn
    {


        public IWebDriver Driver;

        public string SophieURL = "https://qatest-dev.indvp.com/";
        public string emailAddresForLogin = "astojcev+test@gmail.com";
        public string passwordForLogin = "Saraaco123";

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            Driver.Manage().Window.Maximize();
        }

        [Test]
        public void SingUp()
        {
            Driver.Navigate().GoToUrl(SophieURL);

            Assert.AreEqual(SophieURL, Driver.Url, "User is not on homepage");

            List<IWebElement> ButoonsForLogIn = Driver.FindElements(By.CssSelector("button[aria-label='Open my account']")).ToList();

            IWebElement SingInButton = ButoonsForLogIn[0];

            SingInButton.Click();

            IWebElement emailFiled = Driver.FindElement(By.CssSelector("input[name='email']"));

            emailFiled.SendKeys(emailAddresForLogin);

            IWebElement passwordFiled = Driver.FindElement(By.CssSelector("input[name='password']"));

            passwordFiled.SendKeys(passwordForLogin);

            IWebElement SingINButton = Driver.FindElement(By.CssSelector("button[class='Button']"));

            SingINButton.Click();

            IWebElement dashboardText = Driver.FindElement(By.CssSelector("h1[class='MyAccount-Heading']"));

            string textInDashboard = "Dashboard";

            dashboardText.Text.Contains(textInDashboard);

            string DashboardUrl = "https://qatest-dev.indvp.com/my-account/dashboard";

            Assert.AreEqual(DashboardUrl, Driver.Url, "User is not succesfull loged in");

        }

        [TearDown]
        public void Tear()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}