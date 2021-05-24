using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly HomePage homePage;

        public HomePageSteps(IWebDriver driver)
        {
            _webdriver = driver;
            homePage = new HomePage(_webdriver);
        }

        [Given(@"User is on home page")]
        public void GivenUserIsOnHomePage()
        {
            _webdriver.Url = _webdriver.Url;
        }

        [Given(@"Kalendarz is on home page")]
        public void GivenKalendarzIsOnHomePage()
        {
            homePage.FindCalendarModule();
        }

        [When(@"User clicks on Kalendarz")]
        public void WhenUserClicksOnKalendarz()
        {
            homePage.ClicksOnCalendar();
            Thread.Sleep(4000);
        }

        [When(@"Grupy technologiczne is on home page")]
        public void WhenTechnologiesGroupsIsOnHomePage()
        {
            homePage.FindTechnologiesGroupsModule();
        }

        [When(@"Użytkownicy is on home page")]
        public void WhenUsersIsOnHomePage()
        {
            homePage.FindUsersModule();
        }

        [When(@"Dzienniczek is on home page")]
        public void WhenDiaryIsOnHomePage()
        {
            homePage.FindUsersModule();
        }

        [When(@"Audyt zdarzeń is on home page")]
        public void WhenAuditOfEventsIsOnHomePage()
        {
            homePage.FindUsersModule();
        }

        [Then(@"User is transferred to page about calendar")]
        public void ThenUserIsTransferredToPageAboutCalendar()
        {
            Assert.That(_webdriver.Url, Is.EqualTo("http://localhost:3000/kalendarz"));
        }

        [Then(@"Grupy technologiczne is inactive")]
        public void ThenTechnologiesGroupsIsInactive()
        {
            Assert.That(homePage.TechnologiesGroupsModuleIsInactive(), Is.True);
        }

        [Then(@"Użytkownicy is inactive")]
        public void ThenUsersIsInactive()
        {
            Assert.That(homePage.UsersModuleIsInactive(), Is.True);
        }

        [Then(@"Dzienniczek is inactive")]
        public void ThenDiaryIsInactive()
        {
            Assert.That(homePage.DiaryModuleIsInactive(), Is.True);
        }

        [Then(@"Audyt zdarzeń is inactive")]
        public void ThenAuditOfEventsIsInactive()
        {
            Assert.That(homePage.AuditOfEventsModuleIsInactive(), Is.True);
        }
    }
}