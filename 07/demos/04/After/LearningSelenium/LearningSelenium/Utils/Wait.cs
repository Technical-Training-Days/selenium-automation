﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LearningSelenium.Utils
{
    internal class Wait
    {
        private readonly IWebDriver driver;

        public Wait(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void WaitForTheElementToBecomeVisible(Func<IWebElement> element, TimeSpan timeSpan)
        {
            var wait = new WebDriverWait(driver, timeSpan);
            wait.Until((_) => element.Invoke().Displayed);
        }
    }
}
