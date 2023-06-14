using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Drawing;

namespace LearningSelenium
{
    internal abstract class BaseTest
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
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments(GetBrowserArguments());
                    return new ChromeDriver(chromeOptions);
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArguments(GetBrowserArguments());
                    return new FirefoxDriver(firefoxOptions);
                case "edge":
                    var edgeOptions = new EdgeOptions();
                    edgeOptions.AddArguments(GetBrowserArguments());
                    return new EdgeDriver(edgeOptions);
                default:
                    throw new Exception("Provided browser is not supported.");
            }
        }

        private string[] GetBrowserArguments()
        {
            if (ConfigurationProvider.Configuration["browserArguments"] != null)
            {
                return ConfigurationProvider.Configuration["browserArguments"].Split(",");
            }
            return Array.Empty<string>(); 
        }
    }
}
