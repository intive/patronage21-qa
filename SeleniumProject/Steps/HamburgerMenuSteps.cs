using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class HamburgerMenuSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly HomePage homePage;
        private WebDriverWait wait;
        private string homePageUrl, calendarUrl, registrationUrl;

        public HamburgerMenuSteps(IWebDriver driver)
        {
            _webdriver = driver;
            homePageUrl = _webdriver.Url;
            calendarUrl = _webdriver.Url + "kalendarz";
            registrationUrl = _webdriver.Url + "rejestracja";
            wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10));
            homePage = new HomePage(_webdriver);
        }

        [Given(@"User is on '(.*)'")]
        public void GivenUserIsOn(string page)
        {
            if (page == "strona główna")
            {
                _webdriver.Url = _webdriver.Url;
            }
            else
            {
                _webdriver.Url = _webdriver.Url + page;
            }
        }

        [Given(@"User clicks on hamburger menu")]
        public void GivenUserClicksOnHamburgerMenu()
        {
            wait.Until<bool>((_webdriver) =>
            {
                homePage.ClicksOnHamburgerMenu();
                return true;
            });
        }

        [When(@"User clicks on page name in header")]
        public void WhenUserClicksOnPageNameInHeader()
        {
            homePage.ClicksOnLogo();
        }

        [When(@"User clicks on hamburger menu")]
        public void WhenUserClicksOnHamburgerMenu()
        {
            homePage.ClicksOnHamburgerMenu();
        }

        [When(@"User clicks on home page")]
        public void WhenUserClicksOnHomePage()
        {
            homePage.ClicksOnHomePage();
        }

        [When(@"User clicks on calendar")]
        public void WhenUserClicksOnCalendar()
        {
            homePage.ClicksOnCalendar();
            Thread.Sleep(500);
        }

        [When(@"User clicks on registration")]
        public void WhenUserClicksOnRegistration()
        {
            homePage.ClicksOnRegistration();
            Thread.Sleep(500);
        }

        [Then(@"User is transferred to home page")]
        public void ThenUserIsTransferredToHomePage()
        {
            Assert.AreEqual(_webdriver.Url, homePageUrl);
        }

        [Then(@"Hamburger menu shows its options")]
        public void ThenHamburgerMenuShowsItsOptions()
        {
            Assert.That(homePage.ElementsInHamburgerMenuDisplayed(), Is.True);
        }

        [Then(@"User is transferred to calendar")]
        public void ThenUserIsTransferredToCalendar()
        {
            Assert.AreEqual(_webdriver.Url, calendarUrl);
        }

        [Then(@"User is transferred to registration")]
        public void ThenUserIsTransferredToRegistration()
        {
            Assert.AreEqual(_webdriver.Url, registrationUrl);
        }
    }
}