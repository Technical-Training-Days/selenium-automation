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




            driver.Quit();
        }
    }
}
