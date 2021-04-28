using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.Hooks;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class ConfirmationOfParticipationSteps : SetupSuccesSite
    {
        [Given(@"User user sees the registration success message")]
        public void GivenUserUserSeesTheRegistrationSuccessMessage()
        {
            IWebElement successfulRegistrationText = driver.FindElement(By.XPath("//*[text()[contains(.,'Twoja rejestracja przebiegła pomyślnie!')]]"));
            Assert.AreEqual(true, successfulRegistrationText.Displayed);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string p0)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement mainPageButton = driver.FindElement(By.XPath("//*[text()[contains(.,'Strona główna')]]"));
            mainPageButton.Click();
        }

        [Then(@"User should be trasfered to main side")]
        public void ThenUserShouldBeTrasferedToMainSide()
        {
            IWebElement successfulRegistrationText = driver.FindElement(By.XPath("//span[text()='Patron']"));
            Assert.AreEqual(true, successfulRegistrationText.Displayed);
        }
    }
}
