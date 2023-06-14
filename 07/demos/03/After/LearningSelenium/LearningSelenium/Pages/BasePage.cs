using OpenQA.Selenium;

namespace LearningSelenium.Pages
{
    internal class BasePage
    {
        protected readonly IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }
    }
}
