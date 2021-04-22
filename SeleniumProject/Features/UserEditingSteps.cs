using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserEditingSteps
    {
        [Given(@"User is on the page of his user account")]
        public void GivenUserIsOnThePageOfHisUserAccount()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User clicks the (.*) button")]
        public void GivenUserClicksTheButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User edits his user description")]
        public void GivenUserEditsHisUserDescription()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User changes the project")]
        public void GivenUserChangesTheProject()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User changes email adress")]
        public void GivenUserChangesEmailAdress()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User changes phone number")]
        public void GivenUserChangesPhoneNumber()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User changes github link")]
        public void GivenUserChangesGithubLink()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User clicks on the (.*) field")]
        public void WhenUserClicksOnTheField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User clicks on the  (.*)  field")]
        public void WhenUserClicksOnTheField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The user description is saved")]
        public void ThenTheUserDescriptionIsSaved()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The message invalid email address appears")]
        public void ThenTheMessageInvalidEmailAddressAppears()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The message invalid phone number appears")]
        public void ThenTheMessageInvalidPhoneNumberAppears()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The message invalid link github appears")]
        public void ThenTheMessageInvalidLinkGithubAppears()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
