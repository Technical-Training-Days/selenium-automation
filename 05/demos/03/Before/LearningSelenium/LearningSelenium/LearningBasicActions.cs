using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;

namespace LearningSelenium
{
    internal class LearningBasicActions
    {
        [Test]
        public void NavigateTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);

            driver.Navigate().GoToUrl("http://localhost:4200");
            driver.Navigate().GoToUrl(new Uri("http://localhost:4200"));
            driver.Url = "http://localhost:4200";
            driver.Navigate().Refresh();
            driver.Navigate().Back();
            driver.Navigate().Forward();

            Assert.That(driver.Url, Contains.Substring("http://localhost:4200"));

            driver.Quit();
        }

        [Test]
        public void UsingClickTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");

            var addButton = driver.FindElement(By.Id("add-btn"));
            addButton.Click();

            Assert.That(driver.FindElements(By.CssSelector("tbody tr")), Has.Count.EqualTo(1));

            driver.Quit();
        }

        [Test]
        public void UsingDoubleClickTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");

            var addButton = driver.FindElement(By.Id("add-btn"));



            driver.Quit();
        }

        [Test]
        public void CoordinatesClickTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var addButton = driver.FindElement(By.Id("add-btn"));
            


            driver.Quit();
        }
    }
}
