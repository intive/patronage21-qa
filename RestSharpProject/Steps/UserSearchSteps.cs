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
        
        [Given(@"Customer enters \?userName=nazwaUzytkownika as a query parameter")]
        public void GivenCustomerEntersUserNameNazwaUzytkownikaAsAQueryParameter()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"\?userName=nazwaUzytkownika exists in the database")]
        public void GivenUserNameNazwaUzytkownikaExistsInTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Customer enters \?username=nieznanaNazwaUzytkownika as a query parameter")]
        public void GivenCustomerEntersUsernameNieznanaNazwaUzytkownikaAsAQueryParameter()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"\?username=nieznanaNazwaUzytkownika doesn't exist in the database")]
        public void GivenUsernameNieznanaNazwaUzytkownikaDoesnTExistInTheDatabase()
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
        
        [Then(@"JSON body contains \?userName=nazwaUzytkownika")]
        public void ThenJSONBodyContainsUserNameNazwaUzytkownika()
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
