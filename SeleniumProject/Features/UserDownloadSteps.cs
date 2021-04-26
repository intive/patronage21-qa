using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserDownloadSteps
    {
        [Given(@"User is on the ""(.*)"" page")]
        public void GivenUserIsOnThePage(string p0)
        {
            ScenarioContext.Current.Pending();
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
