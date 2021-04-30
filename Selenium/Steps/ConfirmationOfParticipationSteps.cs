using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class ConfirmationOfParticipationSteps
    {
        private readonly IWebDriver _webdriver;

        public ConfirmationOfParticipationSteps(IWebDriver driver)
        {
            _webdriver = driver;
        }

        [Given(@"User user sees the registration success message")]
        public void GivenUserUserSeesTheRegistrationSuccessMessage()
        {
            IWebElement successfulRegistrationText = _webdriver.FindElement(By.XPath("//*[text()[contains(.,'Twoja rejestracja przebiegła pomyślnie!')]]"));
            Assert.AreEqual(true, successfulRegistrationText.Displayed);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string p0)
        {
            _webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement mainPageButton = _webdriver.FindElement(By.XPath("//*[text()[contains(.,'Strona główna')]]"));
            mainPageButton.Click();
        }

        [Then(@"User should be trasfered to main side")]
        public void ThenUserShouldBeTrasferedToMainSide()
        {
            IWebElement successfulRegistrationText = _webdriver.FindElement(By.XPath("//span[text()='Patron']"));
            Assert.AreEqual(true, successfulRegistrationText.Displayed);
        }
    }
}
