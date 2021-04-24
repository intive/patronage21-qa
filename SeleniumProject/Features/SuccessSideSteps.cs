using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class SuccessSideSteps
    {
        [Given(@"the user sees the registration success message")]
        public void GivenTheUserSeesTheRegistrationSuccessMessage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks on button (.*)")]
        public void WhenTheUserClicksOnButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the user should be redirected to their page (.*)")]
        public void ThenTheUserShouldBeRedirectedToTheirPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
