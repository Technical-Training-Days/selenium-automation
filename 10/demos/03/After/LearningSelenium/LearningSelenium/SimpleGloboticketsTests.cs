using LearningSelenium.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Drawing;

namespace LearningSelenium
{
    [Parallelizable(ParallelScope.Children)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class SimpleGloboticketsTests : BaseTest
    {
        private OrderPage orderPage;

        [SetUp]
        public override void SetUp()
        {
            var options = new ChromeOptions();
            SetDriver(new RemoteWebDriver(new Uri("http://localhost:4444"), options));
            GetDriver().Manage().Window.Size = new Size(1920, 1200);
            GetDriver().Navigate().GoToUrl("http://localhost:4200");
            orderPage = new OrderPage(GetDriver());
        }

        [Test]
        [Category("Tests without assertion")]
        public void SimpleTest()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();
        }

        [Test]
        [Category("Tests without assertion")]
        public void UsingRelativeLocatorsTest()
        {
            orderPage.EnterNotes("Something Important");
            orderPage.SelectWorkshop(0);
        }

        [Test]
        [Category("Tests with assertion")]
        [Category("Regression suite")]
        public void SimpleTestWithAssertion()
        {
            orderPage.EnterName("Josh Smith");
            orderPage.ClickAddButton();

            Assert.That(orderPage.GetTotalPrice(), Is.EqualTo("$100.00"), "Total price is not valid!");
        }
    }
}
