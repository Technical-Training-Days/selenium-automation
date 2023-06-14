using OpenQA.Selenium;

namespace LearningSelenium.Pages
{
    internal class OrderPage
    {
        private readonly IWebDriver driver;

        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
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
    }
}
