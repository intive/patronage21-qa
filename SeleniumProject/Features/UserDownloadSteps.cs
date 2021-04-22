using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserDownloadSteps
    {
        [When(@"User enters the ""(.*)"" he wants to find in the (.*) field")]
        public void WhenUserEntersTheHeWantsToFindInTheField(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects a technology group")]
        public void WhenUserSelectsATechnologyGroup()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The user selects a technology group in which this user is not located")]
        public void WhenTheUserSelectsATechnologyGroupInWhichThisUserIsNotLocated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The searched user is not displayed")]
        public void ThenTheSearchedUserIsNotDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
