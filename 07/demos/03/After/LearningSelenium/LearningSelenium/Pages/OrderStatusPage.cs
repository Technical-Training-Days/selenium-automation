
using OpenQA.Selenium;

namespace LearningSelenium.Pages
{
    internal class OrderStatusPage : BasePage
    {
        public OrderStatusPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderSuccessMessage => driver.FindElement(By.Id("order-success"));

        public string GetOrderSuccessMessageText()
        {
            return OrderSuccessMessage.Text;
        }
    }
}
