using LearningSelenium.Pages;
using OpenQA.Selenium;
using System.Drawing;

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

        [Test]
        public void ManagingWindowsTest()
        {
            var window1 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("Window 1");

            GetDriver().SwitchTo().NewWindow(WindowType.Window);
            GetDriver().Navigate().GoToUrl("http://localhost:4200");
            var window2 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("Window 2");

            GetDriver().SwitchTo().Window(window1);
            Assert.That(orderPage.GetNameValue, Is.EqualTo("Window 1"));

            GetDriver().SwitchTo().Window(window2);
            Assert.That(orderPage.GetNameValue, Is.EqualTo("Window 2"));
        }

        [Test]
        public void ManagingTabsTest()
        {
            var tab1 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("Tab 1");

            GetDriver().SwitchTo().NewWindow(WindowType.Tab);
            GetDriver().Navigate().GoToUrl("http://localhost:4200");
            var tab2 = GetDriver().CurrentWindowHandle;
            orderPage.EnterName("Tab 2");

            GetDriver().SwitchTo().Window(tab1);
            Assert.That(orderPage.GetNameValue, Is.EqualTo("Tab 1"));

            GetDriver().SwitchTo().Window(tab2);
            Assert.That(orderPage.GetNameValue, Is.EqualTo("Tab 2"));
        }
    }
}
