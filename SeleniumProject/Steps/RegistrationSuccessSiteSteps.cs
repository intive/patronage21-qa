using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class RegistrationSuccessSiteSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly RegistrationSuccessSitePage registrationSuccessSitePage;

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
    }
}