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
                _webdriver.Navigate().GoToUrl(userpage.envUrl);
                Assert.AreEqual("Użytkownicy", userpage.UserHeader.Text);
            }
        }
        
        [When(@"User enters the '(.*)' he wants to find in the ""(.*)"" field")]
        public void WhenUserEntersTheHeWantsToFindInTheField(string userData, string searchUser)
        {
        
        }
        
        [When(@"User selects '(.*)'")]
        public void WhenUserSelects(string technologyGroup)
        {
          
        }

        [Then(@"A user with name and surname equal '(.*)' is displayed")]
        public void ThenAUserWithNameAndSurnameEqualIsDisplayed(string userData)
        {

        }
        
    }
}
