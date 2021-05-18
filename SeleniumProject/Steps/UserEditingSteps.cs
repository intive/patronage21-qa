using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserEditingSteps
    {
        [When(@"User is writing his description")]
        public void WhenUserIsWritingHisDescription()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects a project from the list")]
        public void WhenUserSelectsAProjectFromTheList()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes a valid email address")]
        public void WhenUserWritesAValidEmailAddress()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes email address without @")]
        public void WhenUserWritesEmailAddressWithout()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes a valid phone number")]
        public void WhenUserWritesAValidPhoneNumber()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes more or less than (.*) numbers")]
        public void WhenUserWritesMoreOrLessThanNumbers(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes a valid github link")]
        public void WhenUserWritesAValidGithubLink()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes an incorrect link")]
        public void WhenUserWritesAnIncorrectLink()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Project has been changed successfuly")]
        public void ThenProjectHasBeenChangedSuccessfuly()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The address has been changed successfuly")]
        public void ThenTheAddressHasBeenChangedSuccessfuly()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The phone number has been changed successfuly")]
        public void ThenThePhoneNumberHasBeenChangedSuccessfuly()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Github link has been changed successfuly")]
        public void ThenGithubLinkHasBeenChangedSuccessfuly()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
