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
    public class RegistrationSuccessSiteSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly RegistrationSuccessSitePage registrationSuccessSitePage;
        private readonly BasePage basePage;

        public RegistrationSuccessSiteSteps(IWebDriver driver)
        {
            _webdriver = driver;
            registrationSuccessSitePage = new RegistrationSuccessSitePage(_webdriver);            
        }

        [Given(@"Activated User is redirected to Success Site")]
        public void GivenActivatedUserIsRedirectedToSuccessSite()
        {
            _webdriver.Url = _webdriver.Url + "rejestracja-sukces";
        }

        [Given(@"User sees the registration success message on site")]

        public void GivenUserUserSeesTheRegistrationSuccessMessage()

        {
            Assert.AreEqual(true, registrationSuccessSitePage.successfulRegistrationText.Displayed);
        }

        [Then(@"User should be transferred to main site")]
        public void ThenUserShouldBeTransferredToMainSite()
        {
            var wait = new WebDriverWait(_webdriver, new TimeSpan(0, 0, 10));
                      
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(basePage.mainPageContentElement));

            Assert.AreEqual(true, basePage.mainPageContent.Displayed);
        }
    }
}
