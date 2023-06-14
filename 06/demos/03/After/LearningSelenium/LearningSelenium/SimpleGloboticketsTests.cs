using OpenQA.Selenium;

namespace LearningSelenium
{
    [Parallelizable(ParallelScope.Children)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class SimpleGloboticketsTests : BaseTest
    {
        [Test]
        public void SimpleTest()
        {
            GetDriver().FindElement(By.Id("full-name")).SendKeys("Josh Smith");
            GetDriver().FindElement(By.Id("add-btn")).Click();
        }

        [Test]
        public void UsingRelativeLocatorsTest()
        {
            GetDriver().FindElement(RelativeBy
                .WithLocator(By.TagName("textarea"))
                .Below(By.Id("full-name")))
                .SendKeys("Something Important");

            GetDriver().FindElements(RelativeBy
                .WithLocator(By.CssSelector("input[type='checkbox']"))
                .Below(By.Id("full-name")))
                .First()
                .Click();
        }

        [Test]
        public void SimpleTestWithAssertion()
        {
            GetDriver().FindElement(By.Id("full-name")).SendKeys("Josh Smith");
            GetDriver().FindElement(By.Id("add-btn")).Click();

            var totalPrice = GetDriver().FindElement(By.CssSelector("tfoot tr th:nth-child(3)"));
            Assert.That(totalPrice.Text, Is.EqualTo("$100.00"), "Total price is not valid!");
        }
    }
}
