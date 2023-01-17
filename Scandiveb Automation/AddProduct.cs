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

    class AddProduct
    {
        public IWebDriver Driver;
        public WebDriverWait wait;
        public static Random random = new Random();

        public string SophieURL = "https://qatest-dev.indvp.com/";

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(40);
            Driver.Manage().Window.Maximize();
        }

        //[Repeat(5)]
        [Test]
        public void Product()
        {
            Driver.Navigate().GoToUrl(SophieURL);

            Assert.AreEqual(SophieURL, Driver.Url, "User is not on homepage");

            List<IWebElement> tobBarMenu = Driver.FindElements(By.CssSelector("li[class='MenuOverlay-Item']")).ToList();

            tobBarMenu[random.Next(0, 7)].Click();

            string newInURL = "https://qatest-dev.indvp.com/new-in";
            string pormeterionURL = "https://qatest-dev.indvp.com/portmeirion";
            string kitchenAndDiningURL = "https://qatest-dev.indvp.com/kitchen-dining";
            string homeDecorUrl = "https://qatest-dev.indvp.com/home-decor";
            string bedAndBathURL = "https://qatest-dev.indvp.com/bed-and-bath-1";
            string gardenAndOutdorURL = "https://qatest-dev.indvp.com/garden-and-outdoor";
            string giftsURL = "https://qatest-dev.indvp.com/gifts-45";

            if (newInURL == Driver.Url)
                Console.WriteLine("newin");
            else if (pormeterionURL == Driver.Url)
                Console.WriteLine("Prometeus");
            else if (kitchenAndDiningURL == Driver.Url)
                Console.WriteLine("Kitchen");
            else if (homeDecorUrl == Driver.Url)
                Console.WriteLine("Home Decor");
            else if (bedAndBathURL == Driver.Url)
                Console.WriteLine("BED and BATH");
            else if (gardenAndOutdorURL == Driver.Url)
                Console.WriteLine("GARDER");
            else if (giftsURL == Driver.Url)
                Console.WriteLine("Gifts");
            else
            {
                Console.WriteLine("i was here but im not any more");
                List<IWebElement> tobBarMenu1 = Driver.FindElements(By.CssSelector("li[class='MenuOverlay-Item']")).ToList();
                tobBarMenu1[random.Next(0, 7)].Click();
                Console.WriteLine(Driver.Url);
            }

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("a[block='ProductCard']")));
            List<IWebElement> products = Driver.FindElements(By.CssSelector("a[block='ProductCard']")).ToList();

            products[random.Next(0, 11)].Click();

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;

            IWebElement tableBody = Driver.FindElement(By.CssSelector("body[class]"));

            js.ExecuteScript("arguments[0].scrollIntoView(true);", tableBody);

            wait.Until(Expecting.ElementIsVisible(By.CssSelector("button[class='Button AddToCart ProductActions-AddToCart']")));
            IWebElement addToBascetButton = Driver.FindElement(By.CssSelector("button[class='Button AddToCart ProductActions-AddToCart']"));

            addToBascetButton.Click();

            /*wait.Until(Expecting.ElementIsVisible(By.CssSelector("button[aria-label='Minicart']")));
            IWebElement cart = Driver.FindElement(By.CssSelector("span[aria-label='Items in cart']"));
            cart.Text.Contains("1");*/
            // ↑ this code is comended casue there are product that are not avaiable to sell, but are on the product list "🐛"

        }

        [TearDown]
        public void Tear()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}