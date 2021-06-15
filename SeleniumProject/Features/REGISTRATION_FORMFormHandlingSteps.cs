using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class REGISTRATION_FORMFormHandlingSteps
    {
        [Given(@"The user passed through the form correctly")]
        public void GivenTheUserPassedThroughTheFormCorrectly()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"The user fills the form by correct details")]
        public void GivenTheUserFillsTheFormByCorrectDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The user clicks button '(.*)'")]
        public void WhenTheUserClicksButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Response is successful")]
        public void ThenResponseIsSuccessful()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The user is redirected to the site '(.*)'")]
        public void ThenTheUserIsRedirectedToTheSite(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Response is not successful")]
        public void ThenResponseIsNotSuccessful()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"contains error information")]
        public void ThenContainsErrorInformation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"contains unspecified error")]
        public void ThenContainsUnspecifiedError()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
