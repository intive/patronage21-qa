using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class IP2_293FormHandlingSteps
    {
        [Then(@"The user is redirected to the site '(.*)'")]
        public void ThenTheUserIsRedirectedToTheSite(string p0)
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
