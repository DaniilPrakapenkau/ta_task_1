using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace task1
{
    public class Tests
    {
        private ChromeDriver chromeDriver;
        private WebDriverWait wait;
        private string continueShoppingButton = "//*[@title='Continue shopping']/span";

        [SetUp]
        public void Setup()
        {
            chromeDriver = new ChromeDriver();
            wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(15));
        }

        [Test]
        public void Test1()
        {
            chromeDriver.Url = "http://automationpractice.com/index.php";
            Regisrt();
            chromeDriver.FindElement(By.XPath("//*[contains(@class, 'sf-menu')]/li/a[@title='Dresses']")).Click();
            chromeDriver.FindElement(By.XPath("//*[contains(@id, 'categories_block_left')]//a[contains(text(), 'Summer Dresses')]")).Click();
            Search("dress");
            AddToCart(chromeDriver.FindElement(By.XPath("//*[@id='best-sellers_block_right']//a[contains(text(), 'Printed Chiffon Dress')]")));
            chromeDriver.Navigate().Back();
            AddToCart(chromeDriver.FindElement(By.XPath("//*[@id='best-sellers_block_right']//a[contains(text(), 'T-shirt')]")));
            chromeDriver.FindElement(By.CssSelector("a[title='View my shopping cart']")).Click();
            Assert.Multiple(() => 
            {
                Assert.IsNotEmpty(chromeDriver.FindElements(By.XPath("//a[contains(text(), 'Printed Chiffon Dress')]")));
                Assert.IsNotEmpty(chromeDriver.FindElements(By.XPath("//tr//a[contains(text(), 'Faded Short Sleeve T-shirts')]")));
            });
        }

        private void Regisrt()
        {
            chromeDriver.FindElement(By.ClassName("login")).Click();
            chromeDriver.FindElement(By.Id("email_create")).SendKeys("dprakapenka_@exadel.by");
            chromeDriver.FindElement(By.Id("SubmitCreate")).Click();
            wait.Until(e => e.FindElement(By.Id("account-creation_form")));
            chromeDriver.FindElement(By.Id("id_gender1")).Click();
            chromeDriver.FindElement(By.Id("customer_firstname")).SendKeys("Daniil");
            chromeDriver.FindElement(By.Id("customer_lastname")).SendKeys("Prokopenkov");
            chromeDriver.FindElement(By.Id("passwd")).SendKeys("Exadel");
            chromeDriver.FindElement(By.Id("days")).SendKeys("2");
            chromeDriver.FindElement(By.Id("months")).SendKeys("April");
            chromeDriver.FindElement(By.Id("years")).SendKeys("2001");
            chromeDriver.FindElement(By.Id("firstname")).SendKeys("Daniil");
            chromeDriver.FindElement(By.Id("lastname")).SendKeys("Prokopenkov");
            chromeDriver.FindElement(By.Id("company")).SendKeys("Exadel");
            chromeDriver.FindElement(By.Id("address1")).SendKeys("2 line");
            chromeDriver.FindElement(By.Id("city")).SendKeys("Orsha");
            chromeDriver.FindElement(By.Id("postcode")).SendKeys("35135");
            chromeDriver.FindElement(By.Id("id_country")).SendKeys("United States");
            chromeDriver.FindElement(By.Id("id_state")).SendKeys("Georgia");
            chromeDriver.FindElement(By.Id("phone_mobile")).SendKeys("+375(29)5457345");
            var aliasAddress = chromeDriver.FindElement(By.Id("alias"));
            aliasAddress.Clear();
            aliasAddress.SendKeys("dprakapenkau@exadel.com");
            chromeDriver.FindElement(By.Id("submitAccount")).Click();
        }

        private void Search(string searchString)
        {
            IWebElement search = chromeDriver.FindElement(By.Id("search_query_top"));
            search.Click();
            search.SendKeys(searchString);
            chromeDriver.FindElement(By.CssSelector("button[name = 'submit_search']")).Click();
        }

        private void AddToCart(IWebElement product)
        {
            product.Click();
            chromeDriver.FindElement(By.CssSelector(".exclusive > span")).Click();
            wait.Until(e => e.FindElement(By.XPath(continueShoppingButton)).Displayed);
            chromeDriver.FindElement(By.XPath(continueShoppingButton)).Click();
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Close();
        }
    }
}