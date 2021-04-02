using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class VerificationOfEmailAddressSteps
    {
        [Given(@"User is on registration site")]
        public void GivenUserIsOnRegistrationSite()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"is in possession of code")]
        public void GivenIsInPossessionOfCode()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"doesn't have code")]
        public void GivenDoesnTHaveCode()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User is entering the code")]
        public void WhenUserIsEnteringTheCode()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User enters false code")]
        public void WhenUserEntersFalseCode()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User enters incorrect code")]
        public void WhenUserEntersIncorrectCode()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Button ""(.*)"" becomes active, can be clicked")]
        public void ThenButtonBecomesActiveCanBeClicked(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"redirects User on another page")]
        public void ThenRedirectsUserOnAnotherPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User should receive code one more time")]
        public void ThenUserShouldReceiveCodeOneMoreTime()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User should be moved on the site, where ""(.*)"" is visible\.")]
        public void ThenUserShouldBeMovedOnTheSiteWhereIsVisible_(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Button ""(.*)"" should remain inactive")]
        public void ThenButtonShouldRemainInactive(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
