using LearningSelenium.Pages;

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
    }
}