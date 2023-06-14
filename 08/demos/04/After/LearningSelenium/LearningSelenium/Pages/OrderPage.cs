using OpenQA.Selenium;

namespace LearningSelenium.Pages
{
    internal class OrderPage : BasePage
    {
        public OrderPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement Name => driver.FindElement(By.Id("full-name"));
        private IWebElement AddButton => driver.FindElement(By.Id("add-btn"));
        private IWebElement TotalPrice => driver.FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));

        private List<IWebElement> Workshops => driver.FindElements(RelativeBy
                .WithLocator(By.CssSelector("input[type='checkbox']"))
                .Below(Name))
                .ToList();

        private IWebElement Notes => driver.FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(Name));

        private IWebElement OrderButton => driver.FindElement(By.Id("order-btn"));

        private List<IWebElement> OrderTableItems => driver.FindElements(By.CssSelector(".order-summary tbody tr")).ToList();

        public void EnterName(string name)
        {
            Name.SendKeys(name);
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public string GetTotalPrice()
        {
            return TotalPrice.Text;
        }

        public void EnterNotes(string notes)
        {
            Notes.SendKeys(notes);
        }

        public void SelectWorkshop(int workshopIndex)
        {
            Workshops[workshopIndex].Click();
        }

        public void ScrollToTheOrderButton()
        {
            ScrollToElement(OrderButton);
        }

        public void ClickOrderButton()
        {
            OrderButton.Click();
        }

        public int GetOrderTicketsCount()
        {
            return OrderTableItems.Count;
        }

        public void ScrollToTheTicketRemoveButton(int index)
        {
            ScrollToElement(OrderTableItems[0]);
        }

        public void ClickOnTheTicketRemoveButton(int index)
        {
            OrderTableItems[index].FindElement(By.TagName("button")).Click();
        }
    }
}
