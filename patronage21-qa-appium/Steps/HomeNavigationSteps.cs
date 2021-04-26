using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class HomeNavigationSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        public HomeNavigationSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"User is on Home page")]
        public void GivenUserIsOnHomePage()
        {
        }

        [When(@"User clicks on ""(.*)"" button")]
        public void WhenUserClickskOnButton(string buttonId)
        {
            if (buttonId.Equals("Back"))
            {
                _driver.Navigate().Back();
            }
            else
            {
                var button = _driver.FindElementByAccessibilityId(buttonId);
                button.Click();
            }
        }

        [Then(@"User sees ""(.*)"" page")]
        public void ThenUserSeesPage(string pageTitle)
        {
            if (pageTitle.Equals("Home"))
            {
                pageTitle = "Witaj w Patron-a-tive!";
            }
            var xpath = "//android.view.View[@text='" + pageTitle + "']";
            var pageElement = _driver.FindElementByXPath(xpath);
            Assert.IsTrue(pageElement.Displayed);
        }
    }
}
