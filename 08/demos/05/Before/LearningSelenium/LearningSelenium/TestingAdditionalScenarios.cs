using LearningSelenium.Pages;

namespace LearningSelenium
{
    internal class TestingAdditionalScenarios : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void SetUp()
        {
            orderPage = new OrderPage(GetDriver());
        }

        [Test]
        public void ScrollingToAnElementTest()
        {
            // Order a ticket
            orderPage.EnterName("Josh Smith");
            orderPage.SelectWorkshop(1);
            orderPage.ClickAddButton();

            orderPage.ScrollToTheOrderButton();
            orderPage.ClickOrderButton();

            Assert.That(GetDriver().Url, Contains.Substring("success"));
        }

        [Test]
        public void HandlingAlertsAndConfirmationsTest()
        {
            GetDriver().Navigate().GoToUrl("http://localhost:4200/show-alert");

            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();

            var alertWindow = GetDriver().SwitchTo().Alert();
            alertWindow.Accept();

            orderPage.ScrollToTheTicketRemoveButton(0);
            orderPage.ClickOnTheTicketRemoveButton(0);
            var confirmationWindow = GetDriver().SwitchTo().Alert();
            confirmationWindow.Dismiss();

            Assert.That(orderPage.GetOrderTicketsCount(), Is.EqualTo(1));
        }
    }
}
