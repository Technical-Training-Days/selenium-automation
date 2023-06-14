using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace LearningSelenium
{    
    internal class LearningBasicActions : BaseTest
    {
        [Test]
        public void NavigateTest()
        {
            GetDriver().Navigate().GoToUrl("http://localhost:4200");
            GetDriver().Navigate().GoToUrl(new Uri("http://localhost:4200"));
            GetDriver().Url = "http://localhost:4200";
            GetDriver().Navigate().Refresh();
            GetDriver().Navigate().Back();
            GetDriver().Navigate().Forward();

            Assert.That(GetDriver().Url, Contains.Substring("http://localhost:4200"));
        }

        [Test]
        public void UsingClickTest()
        {
            var nameInput = GetDriver().FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");

            var addButton = GetDriver().FindElement(By.Id("add-btn"));
            addButton.Click();

            Assert.That(GetDriver().FindElements(By.CssSelector("tbody tr")), Has.Count.EqualTo(1));         
        }

        [Test]
        public void UsingDoubleClickTest()
        {
            var nameInput = GetDriver().FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");

            var addButton = GetDriver().FindElement(By.Id("add-btn"));
            var actions = new Actions(GetDriver());
            actions.DoubleClick(addButton).Perform();

            Assert.That(GetDriver().FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);     
        }

        [Test]
        public void CoordinatesClickTest()
        {
            var addButton = GetDriver().FindElement(By.Id("add-btn"));
            var actions = new Actions(GetDriver());
            actions.MoveByOffset(addButton.Location.X + 5, addButton.Location.Y + 5).Click().Perform();
            actions.ContextClick(addButton).Perform();

            Assert.That(GetDriver().FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);       
        }

        [Test]
        public void UsingSendKeysAndClearTest()
        {
            var notesTextArea = GetDriver().FindElement(By.Id("notes"));
            notesTextArea.SendKeys("Will arrive a bit late.");
            notesTextArea.Clear();
            notesTextArea.SendKeys("5% discount");

            Assert.That(notesTextArea.GetAttribute("value"), Is.EqualTo("5% discount"));

            var photoInput = GetDriver().FindElement(By.Id("photo"));
            photoInput.SendKeys(Path.GetFullPath(Path.Join("data", "photo.png")));
            photoInput.Clear();

            Assert.That(photoInput.GetAttribute("value"), Is.Empty); 
        }

        [Test]
        public void PressingKeysTest()
        {
            var nameInput = GetDriver().FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");
            //nameInput.SendKeys(Keys.Control + "A");
            //nameInput.SendKeys(Keys.Delete);

            var actions = new Actions(GetDriver());
            actions.Click(nameInput)
                .SendKeys(Keys.End)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.Home)
                .SendKeys(Keys.Backspace)
                .Perform();

            Assert.That(nameInput.GetAttribute("value"), Is.Empty);
        }

        [Test]
        public void SelectingDropdownOptionTest()
        {
            var includeLunchDropdown = GetDriver().FindElement(By.Id("include-lunch"));
            var includeLunchSelectElement = new SelectElement(includeLunchDropdown);

            includeLunchSelectElement.SelectByText("Yes");
            Assert.That(includeLunchSelectElement.SelectedOption.GetAttribute("value"), Is.EqualTo("true"));

            includeLunchSelectElement.SelectByValue("false");
            Assert.That(includeLunchSelectElement.SelectedOption.Text, Is.EqualTo("No"));      
        }

        [Test]
        public void SelectingCheckboxItems()
        {
            var workshop1 = GetDriver().FindElement(By.Id("workshop-1"));
            if (!workshop1.Selected)
            {
                workshop1.Click();
            }

            Assert.That(workshop1.Selected, Is.True);        
        }
    }
}
