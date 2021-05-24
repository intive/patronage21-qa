using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public sealed class IP2_293FormHandling
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
