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
    }
}
