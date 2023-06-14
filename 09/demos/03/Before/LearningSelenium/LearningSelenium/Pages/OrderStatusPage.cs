
using LearningSelenium.Utils;
using OpenQA.Selenium;

namespace LearningSelenium.Pages
{
    internal class OrderStatusPage : BasePage
    {
        public OrderStatusPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderSuccessMessage => driver.FindElement(By.Id("order-success"));

        public void WaitForTheOrderSuccessMessageToBecomeVisible(TimeSpan timeSpan)
        {
            new Wait(driver).WaitForTheElementToBecomeVisible(() => OrderSuccessMessage, timeSpan);
        }

        public string GetOrderSuccessMessageText()
        {
            return OrderSuccessMessage.Text;
        }
    }
}
