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
    }
}
