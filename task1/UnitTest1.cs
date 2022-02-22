using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace task1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var chromeDriver = new ChromeDriver();
            chromeDriver.Url = "http://automationpractice.com/index.php";
            chromeDriver.FindElement(By.ClassName("login")).Click();
            chromeDriver.FindElement(By.Id("email_create")).SendKeys("dprakapenkau@exadel.by");
            chromeDriver.FindElement(By.Id("SubmitCreate")).Click();

            WebDriverWait wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(15));
            wait.Until(e=>e.FindElement(By.Id("account-creation_form")));
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

            chromeDriver.FindElement(By.XPath("//*[contains(@class, 'sf-menu')]/li/a[@title='Dresses']")).Click();
            chromeDriver.FindElement(By.XPath("//*[contains(@id, 'categories_block_left')]//a[contains(text(), 'Summer Dresses')]")).Click();
            IWebElement search = chromeDriver.FindElement(By.Id("search_query_top"));
            search.Click();
            search.SendKeys("dress");
            chromeDriver.FindElement(By.CssSelector("button[name = 'submit_search']")).Click();
            chromeDriver.FindElement(By.XPath("//*[@id='best-sellers_block_right']//a[contains(text(), 'Printed Chiffon Dress')]")).Click();
            chromeDriver.FindElement(By.CssSelector(".exclusive > span")).Click();
            wait.Until(e => e.FindElement(By.XPath("//*[@title='Continue shopping']/span")).Displayed);
            chromeDriver.FindElement(By.XPath("//*[@title='Continue shopping']/span")).Click();
            chromeDriver.Navigate().Back();
            chromeDriver.FindElement(By.XPath("//*[@id='best-sellers_block_right']//a[contains(text(), 'T-shirt')]")).Click();
            chromeDriver.FindElement(By.CssSelector(".exclusive > span")).Click();
            wait.Until(e => e.FindElement(By.XPath("//*[@title='Continue shopping']/span")).Displayed);
            chromeDriver.FindElement(By.XPath("//*[@title='Continue shopping']/span")).Click();
            chromeDriver.FindElement(By.CssSelector("a[title='View my shopping cart']")).Click();
            Assert.IsNotEmpty(chromeDriver.FindElements(By.XPath("//a[contains(text(), 'Printed Chiffon Dress')]")));
            Assert.IsNotEmpty(chromeDriver.FindElements(By.XPath("//tr//a[contains(text(), 'Faded Short Sleeve T-shirts')]")));
            chromeDriver.Close();
        }
    }
}