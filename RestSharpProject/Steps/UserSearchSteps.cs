using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Data.SqlClient;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class UserSearchSteps
    {

        private RestClient client;
        private RestRequest request;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        private RestResponse response;

        [Given(@"Customer sets the endpoint as /api/users with method GET")]
        public void GivenCustomerSetsTheEndpointAsApiUsersWithMethodGET()
        {
            client = new RestClient("htttp://localhost:8080/");
            request = new RestRequest("api/users", Method.GET);
        }

        [Given(@"Several users exist in application")]
        public void GivenSeveralUsersExistInApplication()
        {
            connection = new SqlConnection("dane do połączenia z bazą");
            command = new SqlCommand("SELECT * FROM users albo inne zapytanie SQL", connection);
            reader = command.ExecuteReader();
        }

        [Given(@"Customer enters valid '(.*)' and '(.*)' as a query parameter")]
        public void GivenCustomerEntersValidAndAsAQueryParameter(string name, string value)
        {
            request.AddQueryParameter(name, value);
        }

        [Given(@"User with '(.*)', '(.*)' and '(.*)', '(.*)' exists in application")]
        public void GivenUserWithAndExistsInApplication(string name1, string value1, string name2, string value2)
        {
            connection = new SqlConnection("dane do połączenia z bazą");
            command = new SqlCommand("Jakieś zapytanie SQL", connection);
            reader = command.ExecuteReader();
        }

        [Given(@"Customer enters '(.*)', '(.*)' and '(.*)', '(.*)' as a query parameter")]
        public void GivenCustomerEntersAndAsAQueryParameter(string name1, string value1, string name2, string value2)
        {
            request.AddQueryParameter(name1, value1).AddQueryParameter(name2, value2);
        }

        [Given(@"Customer enters invalid '(.*)' and '(.*)' as a query paraneter")]
        public void GivenCustomerEntersInvalidAndAsAQueryParaneter(string name, string value)
        {
            request.AddQueryParameter(name, value);
        }

        [Given(@"Customer enters valid '(.*)' as the query parameter")]
        public void GivenCustomerEntersValidAsTheQueryParameter(string name)
        {
            request.AddQueryParameter(name, null);
        }

        [When(@"Customer sends the request to the endpoint")]
        public void WhenCustomerSendsTheRequestToTheEndpoint()
        {
            client.Execute(request);
        }

        [When(@"Customer sends the request without any value in the query")]
        public void WhenCustomerSendsTheRequestWithoutAnyValueInTheQuery()
        {
            client.Execute(request);
        }

        [Then(@"The server returns code (.*)")]
        public void ThenTheServerReturnsCode(int code)
        {
            response = (RestResponse)client.Execute(request);
            Assert.AreEqual(code, (int)response.StatusCode);
        }


        [Then(@"JSON body contains valid '(.*)'")]
        public void ThenJSONBodyContainsValid(string nameAndValue)
        {
            response = (RestResponse)client.Execute(request);
            string responseContent = response.ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);
            string jsonHasNameAndValue = (string)parseRestResponse[nameAndValue];
            Assert.AreEqual(nameAndValue, jsonHasNameAndValue);
        }


        [Then(@"Error message '(.*)' is shown")]
        public void ThenErrorMessageIsShown(string message)
        {
            message = "To jest przykładowa wiadomość o błędzie";
            response = (RestResponse)client.Execute(request);
            string responseContent = response.ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);
            string errorMessage = (string)parseRestResponse[message];
            Assert.Equals(message, errorMessage);
        }

        [Then(@"JSON contains empty array")]
        public void ThenJSONContainsEmptyArray()
        {
            response = (RestResponse)client.Execute(request);
            string responseContent = response.ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);
            string emptyJson = (string)parseRestResponse[null];
            Assert.AreEqual(null, emptyJson);
        }
    }
}