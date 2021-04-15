using NUnit.Framework;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class HomeNavigationSteps : BaseSteps
    {
        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            _driver.LaunchApp();
        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string buttonId)
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

        [Then(@"I see ""(.*)"" page")]
        public void ThenISeePage(string pageId)
        {
            var page = _driver.FindElementByAccessibilityId(pageId);
            Assert.IsTrue(page.Displayed);
        }
    }
}
