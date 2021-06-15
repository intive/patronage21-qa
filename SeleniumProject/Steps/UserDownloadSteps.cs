using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserDownloadSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly UserPage userpage;
        private readonly NavigationPage navigationPage;
        private readonly HomePage homePage;

        public UserDownloadSteps(IWebDriver driver)
        {
            _webdriver = driver;
            userpage = new UserPage(_webdriver);
            navigationPage = new NavigationPage(_webdriver);
            homePage = new HomePage(_webdriver);
        }

        [Given(@"User is on the users page")]
        public void GivenUserIsOnThePage()
        {
            navigationPage.NavigateToHomePage();
            homePage.ClicksOnUsersModule();
        }

        [Given(@"User clicks on search field")]
        public void GivenUserClicksOnSearchField()
        {
            userpage.SearchUserInput.Click();
        }

        [When(@"User typing '(.*)' for find specific person")]
        public void WhenUserTypingForFindSpecificPerson(string userData)
        {
            userpage.SearchUserInput.SendKeys(userData);
        }

        [When(@"User selects a '(.*)'")]
        public void WhenUserSelectsA(string technologyGroup)
        {
            userpage.technologyGroupList.Click();

            if (technologyGroup == userpage.allTechnologyGroup.Text)
            {
                userpage.allTechnologyGroup.Click();
            }
            else
            {
                userpage.Java.Click();
            }
        }

        [Then(@"A user with name and surname is displayed")]
        public void ThenAUserWithNameAndSurnameIsDisplayed()
        {
            Assert.IsTrue(userpage.TomekKowalski.Displayed);
        }

        [When(@"User typing incomplete '(.*)' for find specific person")]
        public void WhenUserTypingIncompleteForFindSpecificPerson(string userData)
        {
            userpage.SearchUserInput.SendKeys(userData);
        }

        [Then(@"Is displayed '(.*)'")]
        public void ThenIsDisplayed(string result)
        {
            Assert.IsTrue(userpage.TomekKowalski.Displayed);
        }

        [When(@"The user selects a '(.*)' in which this user is not located")]
        public void WhenTheUserSelectsAInWhichThisUserIsNotLocated(string technologyGroup)
        {
            userpage.mobileAndroid.Click();
        }

        [Then(@"The message ""(.*)"" is displayed")]
        public void ThenTheMessageIsDisplayed(string message)
        {
            Assert.AreEqual(message, userpage.brakWyników.Text);
        }
    }
}
