using System;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class UserSearchSteps
    {
        [Given(@"endpoint is /api/users")]
        public void GivenEndpointIsApiUsers()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer sets the endpoint with method GET")]
        public void GivenCustomerSetsTheEndpointWithMethodGET()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Several users exist in application")]
        public void GivenSeveralUsersExistInApplication()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer enters valid \?userName=TomNowak")]
        public void GivenCustomerEntersValidUserNameTomNowak()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User with first name ""(.*)"" and last name ""(.*)"" exists in application")]
        public void GivenUserWithFirstNameAndLastNameExistsInApplication(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer enters ""(.*)"" as a query")]
        public void GivenCustomerEntersAsAQuery(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer enters invalid \?username=nieznanaNazwa as a query")]
        public void GivenCustomerEntersInvalidUsernameNieznanaNazwaAsAQuery()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer enters valid \?username= as the query parameter")]
        public void GivenCustomerEntersValidUsernameAsTheQueryParameter()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Customer sends the request to the endpoint")]
        public void WhenCustomerSendsTheRequestToTheEndpoint()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Customer sends the request without any value in the query")]
        public void WhenCustomerSendsTheRequestWithoutAnyValueInTheQuery()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server returns code (.*)")]
        public void ThenTheServerReturnsCode(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"JSON body contains ""(.*)"": ""(.*)""")]
        public void ThenJSONBodyContains(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"JSON body contains (.*) and (.*)")]
        public void ThenJSONBodyContainsAnd(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"JSON body contains (.*)")]
        public void ThenJSONBodyContains(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Error message is shown")]
        public void ThenErrorMessageIsShown()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"JSON contains empty array")]
        public void ThenJSONContainsEmptyArray()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
