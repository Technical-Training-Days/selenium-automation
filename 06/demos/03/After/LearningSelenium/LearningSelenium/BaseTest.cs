using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LearningSelenium
{    internal abstract class BaseTest
    {
        private IWebDriver driver;

        protected IWebDriver GetDriver()
        {
            return driver;
        }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
