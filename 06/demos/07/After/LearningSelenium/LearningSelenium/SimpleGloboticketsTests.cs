using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Drawing;
using LearningSelenium.Pages;

namespace LearningSelenium
{    
    [Parallelizable(ParallelScope.Children)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class SimpleGloboticketsTests : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public new void SetUp()
        {
            orderPage = new OrderPage(GetDriver());
        }

        [Test]
        public void SimpleTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();
        }

        [Test]
        public void UsingRelativeLocatorsTest()
        {
            orderPage.EnterNotes("Something Important");
            orderPage.SelectWorkshop(0);
        }

        [Test]
        public void SimpleTestWithAssertion()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();

            Assert.That(orderPage.GetTotalPrice(), Is.EqualTo("$100.00"), "Total price is not valid!");
        }
    }
}
