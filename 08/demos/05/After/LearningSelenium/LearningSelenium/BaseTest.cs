﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Drawing;

namespace LearningSelenium
{
    internal class BaseTest
    {
        private IWebDriver driver;

        protected IWebDriver GetDriver()
        {
            return driver;
        }

        [SetUp]
        public void SetUp()
        {
            driver = CreateDriver(ConfigurationProvider.Configuration["browser"]);
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
        private IWebDriver CreateDriver(String browserName)
        {
            switch (browserName.ToLowerInvariant())
            {
                case "chrome":
                    return new ChromeDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                default:
                    throw new Exception("Provided browser is not supported.");
            }
        }
    }
}
