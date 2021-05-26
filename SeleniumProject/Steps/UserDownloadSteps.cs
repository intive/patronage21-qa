using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserDownloadSteps
    {

        private readonly IWebDriver _webdriver;
        private readonly UserPage userpage;

        public UserDownloadSteps(IWebDriver driver)
        {
            _webdriver = driver;
            userpage = new UserPage(_webdriver);
        }

        [Given(@"User is on the ""(.*)"" page")]
        public void GivenUserIsOnThePage(string page)
        {
            if (page == "users")
            {
                _webdriver.Navigate().GoToUrl(userpage.UrlUser);
                Assert.AreEqual("Użytkownicy", userpage.UserHeader.Text);
            }
        }

        [StepDefinition(@"User enters the '(.*)' in the szukaj użytkownika field")]
        public void WhenUserEntersTheInTheSzukajUzytkownikaField(string name)
        {
            userpage.SearchUserInput.SendKeys(name);
        }

        [When(@"User enters the '(.*)' he wants to find in the ""(.*)"" field")]
        public void WhenUserEntersTheHeWantsToFindInTheField(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects '(.*)'")]
        public void WhenUserSelects(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes the user's name and surname in the (.*) field")]
        public void WhenUserWritesTheUserSNameAndSurnameInTheField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User with this name and surname is not displayed")]
        public void ThenUserWithThisNameAndSurnameIsNotDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
