using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class ConfirmationOfParticipationSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly ConfirmationOfParticipationPage confirmationOfParticipationPage;

        public ConfirmationOfParticipationSteps(IWebDriver driver)
        {
            _webdriver = driver;
            confirmationOfParticipationPage = new ConfirmationOfParticipationPage(_webdriver);            
        }

        [Given(@"Activated User is redirected to Success Site")]
        public void GivenActivatedUserIsRedirectedToSuccessSite()
        {
            _webdriver.Url = _webdriver.Url + "rejestracja-sukces";
        }

        [Given(@"User sees the registration success message on site")]

        public void GivenUserUserSeesTheRegistrationSuccessMessage()

        {
            Assert.AreEqual(true, confirmationOfParticipationPage.successfulRegistrationText.Displayed);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string p0)
        {
            confirmationOfParticipationPage.mainPageButton.Click();
        }

        [Then(@"User should be transferred to main site")]
        public void ThenUserShouldBeTransferredToMainSite()
        {
            var wait = new WebDriverWait(_webdriver, new TimeSpan(0, 0, 10));
                      
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(confirmationOfParticipationPage.mainPageContentElement));

            Assert.AreEqual(true, confirmationOfParticipationPage.mainPageContent.Displayed);
        }
    }
}
