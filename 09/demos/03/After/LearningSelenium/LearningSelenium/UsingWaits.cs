using LearningSelenium.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LearningSelenium
{
    internal class UsingWaits : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void SetUp()
        {
            orderPage = new OrderPage(GetDriver());
            GetDriver().Navigate().GoToUrl("http://localhost:4200/order-delay");
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void ImplicitlyWaitingForTheOrderToProcessTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.SelectWorkshop(1);
            orderPage.ClickAddButton();

            orderPage.ScrollToTheOrderButton();
            var orderStatusPage = orderPage.ClickOrderButton();

            Assert.That(orderStatusPage.GetOrderSuccessMessageText(),
                Is.EqualTo("Your order has been successfully created!"));
        }

        [Test]
        public void ExplicitlyWaitingForTheOrderToProcessTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.SelectWorkshop(1);
            orderPage.ClickAddButton();

            orderPage.ScrollToTheOrderButton();
            var orderStatusPage = orderPage.ClickOrderButton();

            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            orderStatusPage.WaitForTheOrderSuccessMessageToBecomeVisible(TimeSpan.FromSeconds(15));

            Assert.That(orderStatusPage.GetOrderSuccessMessageText(),
                Is.EqualTo("Your order has been successfully created!"));
        }
    }
}
