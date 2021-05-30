using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class ErrorPageSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly ErrorPage_Page errorPage_Page;
        private readonly BasePage basePage;

        public ErrorPageSteps(IWebDriver driver)
        {
            _webdriver = driver;
            errorPage_Page = new ErrorPage_Page(_webdriver);
            basePage = new BasePage(_webdriver);
        }

        [Given(@"Wrong Url redirects user to Error Page")]
        public void GivenWrongUrlRedirectsUserToErrorPage()
        {
            _webdriver.Url = _webdriver.Url + "404";
        }

        [Given(@"User sees information about false url address")]
        public void GivenUserSeesInformationAboutFalseUrlAdress()
        {
            Assert.AreEqual(true, errorPage_Page.wrongAddressText.Displayed);
        }

        [Then(@"User is transferred to main site")]
        public void ThenUserIsTransferredToMainSite()
        {
            Assert.AreEqual(true, errorPage_Page.patronativePage.Displayed);
        }
        
        /*[Then(@"User is transferred to last opened page")]
        public void ThenUserIsTransferredToLastOpenedPage()
        {
            ScenarioContext.Current.Pending();
        }*/
    }
}
