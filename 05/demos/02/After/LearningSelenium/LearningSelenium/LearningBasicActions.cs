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
    }
}
