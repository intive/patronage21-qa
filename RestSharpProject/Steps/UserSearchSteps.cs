using System;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class UserSearchSteps
    {
        [Given(@"URL endpoint is /api/users")]
        public void GivenURLEndpointIsApiUsers()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer sets the endpoint with method GET")]
        public void GivenCustomerSetsTheEndpointWithMethodGET()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer enters Imie as a query parameter")]
        public void GivenCustomerEntersImieAsAQueryParameter()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Imie exists in the database")]
        public void GivenImieExistsInTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer enters NieznaneImie as a query parameter")]
        public void GivenCustomerEntersNieznaneImieAsAQueryParameter()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"NieznaneImie doesn't exist in the database")]
        public void GivenNieznaneImieDoesnTExistInTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer sets the endpoint with non-allowed method")]
        public void GivenCustomerSetsTheEndpointWithNon_AllowedMethod()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Customer sends the request to the endpoint")]
        public void WhenCustomerSendsTheRequestToTheEndpoint()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server returns code (.\d+)")]
        public void ThenTheServerReturnsCode(int responseCode)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"JSON body contains Imie")]
        public void ThenJSONBodyContainsImie()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"JSON body contains message ""(.+)""")]
        public void ThenJSONBodyContainsMessage(string errorMessage)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
