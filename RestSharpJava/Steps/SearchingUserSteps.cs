using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using TechTalk.SpecFlow;

namespace RestSharpProject.Features
{
    [Binding]
    public class SearchingUserSteps
    {

        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;
        private string searchUsertUrl = "/users?";
       

        public SearchingUserSteps(RestClient client)
        {
            _client = new RestClient(client.BaseUrl + searchUsertUrl);
        }

        [Given(@"Url is set")]
        public void GivenUrlIsSet()
        {
            _client.BaseUrl = _client.BaseUrl;
        }

        [When(@"User sends the GET request with a '(.*)' parameter")]
        public void WhenUserSendsTheGETRequestWithAParameter(string query)
        {
            _request = new RestRequest(_client.BaseUrl + query);
        }

        [Then(@"Server return the code (.*)")]
        public void ThenServerReturnTheCode(int code)
        {
            _response = _client.Get(_request);
            Assert.AreEqual(code, (int)_response.StatusCode);
        }

        [Then(@"JSON body contain list of users with proper '(.*)' with '(.*)'")]
        public void ThenJSONBodyContainListOfUsersWithProperWith(string parameter, string value)
        {
            var responseMessage = JsonConvert.DeserializeObject<GetUsersList>(_response.Content);

            if (parameter == "firstName")
            {
                for (var i = 0; i < responseMessage.users.Count; i++)
                {
                    Assert.AreEqual(value, responseMessage.users[i].firstName);
                }
            }
            else if (parameter == "lastName")
            {
                for (var i = 0; i < responseMessage.users.Count; i++)
                {
                    Assert.AreEqual(value, responseMessage.users[i].lastName);
                }
            }
            else if (parameter == "login")
            {
                for (var i = 0; i < responseMessage.users.Count; i++)
                {
                    Assert.AreEqual(value, responseMessage.users[i].login);
                }
            }
            else if (parameter == "other")
            {
                for (var i = 0; i < responseMessage.users.Count; i++)
                {
                    var name = responseMessage.users[i].firstName.Contains(value);
                    var surname = responseMessage.users[i].lastName.Contains(value);
                    var username = responseMessage.users[i].login.Contains(value);

                    if (name || surname || username)
                    {
                        Assert.IsTrue(true);
                    }
                }
            }
            else
            {
                Assert.NotNull(responseMessage);
            }
        }

        [Then(@"Server returns the code (.*) and the message '(.*)'")]
        public void ThenServerReturnsTheCodeAndTheMessage(int code, string firstMessage)
        {
            _response = _client.Get(_request);
            Assert.AreEqual(code, (int)_response.StatusCode);

            var responseMessage1 = JsonConvert.DeserializeObject<RootResponse>(_response.Content);

            Assert.That(firstMessage, Is.EqualTo(responseMessage1.violationErrors[0].message));
        }
    }
}

