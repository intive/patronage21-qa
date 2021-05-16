using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class UserSearchSteps
    {

        RestClient client;
        RestRequest request;
        RestResponse response;

        [Given(@"Customer sets the endpoint as /frontend-api/users with method GET")]
        public void GivenCustomerSetsTheEndpointAsFrontend_ApiUsersWithMethodGET()
        {
            client = new RestClient("http://localhost:8080/");
            request = new RestRequest("frontend-api/users", Method.GET);
        }
        
        [Given(@"Customer enters '(.*)' and '(.*)' as a query parameter")]
        public void GivenCustomerEntersAndAsAQueryParameter(string key, string value)
        {
            request.AddQueryParameter(key, value);
        }
        
        [When(@"Customer sends the request to the endpoint")]
        public void WhenCustomerSendsTheRequestToTheEndpoint()
        {
            response = (RestResponse)client.Execute<Model.Users>(request);
        }
        
        [When(@"Customer sends the firstName value as '(.*)' and lastName value as '(.*)'")]
        public void WhenCustomerSendsTheFirstNameValueAsAndLastNameValueAs(string firstNameValue, string lastNameValue)
        {
            request.AddJsonBody(new Model.Users() { firstName = firstNameValue, lastName = lastNameValue });
        }
       
        
        [When(@"Customer sends the lastName value as '(.*)'")]
        public void WhenCustomerSendsTheLastNameValueAs(string lastNameValue)
        {
            request.AddJsonBody(new Model.Users() { lastName = lastNameValue });
        }
        
        [When(@"Customer sends the request without any query parameter")]
        public void WhenCustomerSendsTheRequestWithoutAnyQueryParameter()
        {
            response = (RestResponse)client.Execute(request);
        }
        
        [Then(@"The server returns code (.*)")]
        public void ThenTheServerReturnsCode(int code)
        {
            Assert.AreEqual(code, response.StatusCode);
        }
        
        [Then(@"JSON body contains '(.*)' ")]
        public void ThenJSONBodyContainsAnd(List<string> list)
        {
            // nie wiem, jakiej wartości użyć za length
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(list);
            }
        }
        
        [Then(@"JSON body contains valid '(.*)'")]
        public void ThenJSONBodyContainsValid(string value)
        {
            //tu chciałem użyć response.Data, ale nie da się jej użyć
            //Assert.AreEqual(value, response.Data);
        }
        
        [Then(@"JSON body contains rejectedValue '(.*)'")]
        public void ThenJSONBodyContainsRejectedValue(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"JSON body contains array")]
        public void ThenJSONBodyContainsArray()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
