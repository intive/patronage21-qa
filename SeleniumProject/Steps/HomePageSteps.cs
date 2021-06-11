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
    public class HomePageSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly HomePage homePage;
        private WebDriverWait wait;
        private string homePageUrl, calendarUrl;
        private string usersUrl = TestContext.Parameters["javaUsersPage"];

        public HomePageSteps(IWebDriver driver)
        {
            _webdriver = driver;
            homePageUrl = _webdriver.Url;
            calendarUrl = _webdriver.Url + "kalendarz";
            if (string.IsNullOrEmpty(usersUrl))
                usersUrl = "http://localhost:3000/";
            wait = new WebDriverWait(_webdriver, TimeSpan.FromSeconds(10));
            homePage = new HomePage(_webdriver);
        }

        [Given(@"User is on home page")]
        public void GivenUserIsOnHomePage()
        {
            _webdriver.Url = homePageUrl;
        }

        [Given(@"Kalendarz is on home page")]
        public void GivenKalendarzIsOnHomePage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(homePage.calendar));
        }

        [Given(@"Users module is on home page")]
        public void GivenUsersModuleIsOnHomePage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(homePage.users));
        }

        [When(@"User clicks on users module")]
        public void WhenUserClicksOnUsersModule()
        {
            homePage.ClicksOnUsersModule();
        }

        [When(@"User clicks on Kalendarz")]
        public void WhenUserClicksOnKalendarz()
        {
            homePage.ClicksOnCalendarModule();
            Thread.Sleep(500);
        }

        [When(@"Grupy technologiczne is on home page")]
        public void WhenTechnologiesGroupsIsOnHomePage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(homePage.technologiesGroups));
        }

        [When(@"Dzienniczek is on home page")]
        public void WhenDiaryIsOnHomePage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(homePage.diary));
        }

        [When(@"Audyt zdarzeń is on home page")]
        public void WhenAuditOfEventsIsOnHomePage()
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(homePage.auditOfEvents));
        }

        [Then(@"User is transferred to page about calendar")]
        public void ThenUserIsTransferredToPageAboutCalendar()
        {
            Assert.AreEqual(_webdriver.Url, calendarUrl);
        }

        [Then(@"Grupy technologiczne is inactive")]
        public void ThenTechnologiesGroupsIsInactive()
        {
            Assert.That(homePage.TechnologiesGroupsModuleIsActive(), Is.False);
        }

        [Then(@"Dzienniczek is inactive")]
        public void ThenDiaryIsInactive()
        {
            Assert.That(homePage.DiaryModuleIsActive(), Is.False);
        }

        [Then(@"Audyt zdarzeń is inactive")]
        public void ThenAuditOfEventsIsInactive()
        {
            Assert.That(homePage.AuditOfEventsModuleIsActive(), Is.False);
        }

        [Then(@"User is transferred to page about users")]
        public void ThenUserIsTransferredToPageAboutUsers()
        {
            Assert.AreEqual(_webdriver.Url, usersUrl);
        }
    }
}