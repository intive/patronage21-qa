using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class HamburgerMenuSteps
    {
        private readonly IWebDriver _webdriver;
        private By patronageLogo = By.XPath(".//*[@class='logo__Text-sc-1ubblt8-2 jkbUZv']");
        private By hamburgerMenu = By.XPath(".//*[@d='M3 18h18v-2H3v2zm0-5h18v-2H3v2zm0-7v2h18V6H3z']");
        private By itemsInHamburgerMenu = By.XPath(".//*[@class='MuiPaper-root MuiMenu-paper MuiPopover-paper MuiPaper-elevation8 MuiPaper-rounded']");
        private By fisrtItemInHamburgerMenu = By.XPath(".//*[contains(text(),'Strona główna')]");
        private By secondItemInHamburgerMenu = By.XPath(".//*[contains(text(),'Kalendarz')]");
        private By thirdItemInHamburgerMenu = By.XPath(".//*[contains(text(),'Rejestracja')]");

        public HamburgerMenuSteps(IWebDriver driver)
        {
            _webdriver = driver;
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
            _webdriver.FindElement(hamburgerMenu).Click();
            Thread.Sleep(4000);
        }

        [When(@"User clicks on page name in header")]
        public void WhenUserClicksOnPageNameInHeader()
        {
            _webdriver.FindElement(patronageLogo).Click();
            Thread.Sleep(4000);
        }

        [When(@"User clicks on hamburger menu")]
        public void WhenUserClicksOnHamburgerMenu()
        {
            _webdriver.FindElement(hamburgerMenu).Click();
            Thread.Sleep(4000);
        }

        [When(@"User clicks on home page")]
        public void WhenUserClicksOnHomePage()
        {
            _webdriver.FindElement(fisrtItemInHamburgerMenu).Click();
            Thread.Sleep(4000);
        }

        [When(@"User clicks on calendar")]
        public void WhenUserClicksOnCalendar()
        {
            _webdriver.FindElement(secondItemInHamburgerMenu).Click();
            Thread.Sleep(4000);
        }

        [When(@"User clicks on registration")]
        public void WhenUserClicksOnRegistration()
        {
            _webdriver.FindElement(thirdItemInHamburgerMenu).Click();
            Thread.Sleep(4000);
        }

        [Then(@"User is transferred to home page")]
        public void ThenUserIsTransferredToHomePage()
        {
            Assert.That(_webdriver.Url, Is.EqualTo("http://localhost:3000/"));
        }

        [Then(@"Hamburger menu shows its options")]
        public void ThenHamburgerMenuShowsItsOptions()
        {
            Assert.That((_webdriver.FindElement(itemsInHamburgerMenu).Displayed), Is.True);
        }

        [Then(@"User is transferred to calendar")]
        public void ThenUserIsTransferredToCalendar()
        {
            Assert.That(_webdriver.Url, Is.EqualTo("http://localhost:3000/kalendarz"));
        }

        [Then(@"User is transferred to registration")]
        public void ThenUserIsTransferredToRegistration()
        {
            Assert.That(_webdriver.Url, Is.EqualTo("http://localhost:3000/rejestracja"));
        }
    }
}