using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Drawing;

namespace LearningSelenium
{
    internal class SimpleGloboticketsTests
    {
        [Test]
        public void SimpleTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            driver.FindElement(By.Id("full-name")).SendKeys("Josh Smith");
            driver.FindElement(By.Id("add-btn")).Click();

            driver.Quit();
        }

        [Test]
        public void UsingRelativeLocatorsTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            driver.FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.Id("full-name")))
                .SendKeys("Something Important");

            driver.FindElements(RelativeBy
                .WithLocator(By.CssSelector("input[type='checkbox']"))
                .Below(By.Id("full-name")))
                .First()
                .Click();

            driver.Quit();
        }

        [Test]
        public void SimpleTestWithAssertion()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            driver.FindElement(By.Id("full-name")).SendKeys("Josh Smith");
            driver.FindElement(By.Id("add-btn")).Click();

            var totalPrice = driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
            Assert.That(totalPrice.Text, Is.EqualTo("$100.00"), "Total price is not valid!");

            driver.Quit();
        }
    }
}
