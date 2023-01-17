 using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using Expecting = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTask
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]

    class Register
    {
        public IWebDriver Driver;
        public WebDriverWait wait;
        public static Random random = new Random();

        public string SophieURL = "https://qatest-dev.indvp.com/";
        public string name = "Aleksandar";
        public string lastName = "Stojcev";
        public string email = RandomAdress(8) + "@gmail.com";
        public string randomPassword = RandomPassword(10);

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            Driver.Manage().Window.Maximize();
        }

        [Test]
        public void Account()
        {
            Driver.Navigate().GoToUrl(SophieURL);

            Assert.AreEqual(SophieURL, Driver.Url, "User is not on homepage");

            List<IWebElement> ButoonsForLogIn = Driver.FindElements(By.CssSelector("button[aria-label='Open my account']")).ToList();

            IWebElement SingUpButton = ButoonsForLogIn[0];

            SingUpButton.Click();

            IWebElement createAnAccoutButton = Driver.FindElement(By.CssSelector("button[class='Button Button_isHollow']"));

            createAnAccoutButton.Click();

            IWebElement firstNameField = Driver.FindElement(By.CssSelector("input[name='firstname']"));

            firstNameField.SendKeys(name);

            IWebElement lastNameField = Driver.FindElement(By.CssSelector("#lastname"));

            lastNameField.SendKeys(lastName);

            IWebElement emailFiled = Driver.FindElement(By.CssSelector("#email"));

            emailFiled.SendKeys(email);

            IWebElement passwordFiled = Driver.FindElement(By.CssSelector("#password"));

            passwordFiled.SendKeys(randomPassword);

            IWebElement confirPasswordField = Driver.FindElement(By.CssSelector("#confirm_password"));

            confirPasswordField.SendKeys(randomPassword);

            IWebElement singUpButton = Driver.FindElement(By.CssSelector("button[type='submit']"));

            singUpButton.Click();






        }

        [TearDown]
        public void Tear()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        public static string RandomAdress(int lenght)
        {
            const string specal = "aleksandarstojcev00";
            return new string(Enumerable.Repeat(specal, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomPassword(int lenght)
        {
            const string specal = "8SSAAmakedonija90ER";
            return new string(Enumerable.Repeat(specal, lenght).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}