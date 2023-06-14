using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Drawing;

namespace LearningSelenium
{
    internal class LearningBasicActions
    {
        [Test]
        public void NavigateTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);

            driver.Navigate().GoToUrl("http://localhost:4200");
            driver.Navigate().GoToUrl(new Uri("http://localhost:4200"));
            driver.Url = "http://localhost:4200";
            driver.Navigate().Refresh();
            driver.Navigate().Back();
            driver.Navigate().Forward();

            Assert.That(driver.Url, Contains.Substring("http://localhost:4200"));

            driver.Quit();
        }

        [Test]
        public void UsingClickTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");

            var addButton = driver.FindElement(By.Id("add-btn"));
            addButton.Click();

            Assert.That(driver.FindElements(By.CssSelector("tbody tr")), Has.Count.EqualTo(1));

            driver.Quit();
        }

        [Test]
        public void UsingDoubleClickTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");

            var addButton = driver.FindElement(By.Id("add-btn"));
            var actions = new Actions(driver);
            actions.DoubleClick(addButton).Perform();

            Assert.That(driver.FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);

            driver.Quit();
        }

        [Test]
        public void CoordinatesClickTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var addButton = driver.FindElement(By.Id("add-btn"));
            var actions = new Actions(driver);
            actions.MoveByOffset(addButton.Location.X + 5, addButton.Location.Y + 5).Click().Perform();
            actions.ContextClick(addButton).Perform();

            Assert.That(driver.FindElement(By.Id("full-name_validation-error")).Displayed, Is.True);

            driver.Quit();
        }

        [Test]
        public void UsingSendKeysAndClearTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var notesTextArea = driver.FindElement(By.Id("notes"));
            notesTextArea.SendKeys("Will arrive a bit late.");
            notesTextArea.Clear();
            notesTextArea.SendKeys("5% discount");

            Assert.That(notesTextArea.GetAttribute("value"), Is.EqualTo("5% discount"));

            var photoInput = driver.FindElement(By.Id("photo"));
            photoInput.SendKeys(Path.GetFullPath(Path.Join("data", "photo.png")));
            photoInput.Clear();

            Assert.That(photoInput.GetAttribute("value"), Is.Empty);

            driver.Quit();
        }

        [Test]
        public void PressingKeysTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var nameInput = driver.FindElement(By.Id("full-name"));
            nameInput.SendKeys("Josh Smith");
            //nameInput.SendKeys(Keys.Control + "A");
            //nameInput.SendKeys(Keys.Delete);

            var actions = new Actions(driver);
            actions.Click(nameInput)
                .SendKeys(Keys.End)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.Home)
                .SendKeys(Keys.Backspace)
                .Perform();

            Assert.That(nameInput.GetAttribute("value"), Is.Empty);

            driver.Quit();
        }

        [Test]
        public void SelectingDropdownOptionTest()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

            var includeLunchDropdown = driver.FindElement(By.Id("include-lunch"));
            var includeLunchSelectElement = new SelectElement(includeLunchDropdown);

            includeLunchSelectElement.SelectByText("Yes");
            Assert.That(includeLunchSelectElement.SelectedOption.GetAttribute("value"), Is.EqualTo("true"));

            includeLunchSelectElement.SelectByValue("false");
            Assert.That(includeLunchSelectElement.SelectedOption.Text, Is.EqualTo("No"));

            driver.Quit();
        }

        [Test]
        public void SelectingCheckboxItems()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1920, 1200);
            driver.Navigate().GoToUrl("http://localhost:4200");

  


            driver.Quit();
        }
    }
}
