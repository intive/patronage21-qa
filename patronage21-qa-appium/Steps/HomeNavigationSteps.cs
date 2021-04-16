using NUnit.Framework;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class HomeNavigationSteps : BaseSteps
    {
        [Given(@"User is on Home page")]
        public void GivenUserIsOnHomePage()
        {
            _driver.LaunchApp();
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
        public void ThenUserSeesPage(string pageId)
        {
            var page = _driver.FindElementByAccessibilityId(pageId);
            Assert.IsTrue(page.Displayed);
        }
    }
}
