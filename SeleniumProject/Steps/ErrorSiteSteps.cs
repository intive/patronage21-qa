using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class ErrorSiteSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly ErrorSitePage errorSite;
        private readonly BasePage basePage;

        public ErrorSiteSteps(IWebDriver driver)
        {
            _webdriver = driver;
            errorSite = new ErrorSitePage(_webdriver);
            basePage = new BasePage(_webdriver);
        }

        [Given(@"Wrong Url redirects user to Error Site")]
        public void GivenWrongUrlRedirectsUserToErrorSite()
        {
            _webdriver.Url = _webdriver.Url + "404";
        }

        [Given(@"User sees information about false url address")]
        public void GivenUserSeesInformationAboutFalseUrlAdress()
        {
            Assert.AreEqual(true, errorSite.wrongAddressText.Displayed);
        }
    }
}