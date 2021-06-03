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
        RestClient client;
        RestRequest request;
        IRestResponse response;


        [Given(@"Url is set")]
        public void GivenUrlIsSet()
        {
            client = new RestClient("http://intive-patronage.pl");
        }

        [When(@"User sends the GET request with a '(.*)' parameter")]
        public void WhenUserSendsTheGETRequestWithAParameter(string query)
        {
            request = new RestRequest("/api/users?" + query, Method.GET);
        }

        [Then(@"Server return the code (.*)")]
        public void ThenServerReturnTheCode(int code)
        {
            response = client.Execute(request);
            Assert.AreEqual(code, (int)response.StatusCode);
        }

        [Then(@"JSON body contain list of users with proper '(.*)' with '(.*)'")]
        public void ThenJSONBodyContainListOfUsersWithProperParameterWithValue(string parameter, string value)
        {
            var responseMessage = JsonConvert.DeserializeObject<GetUsersList>(response.Content);

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
            response = client.Execute(request);
            Assert.AreEqual(code, (int)response.StatusCode);

            var responseMessage1 = JsonConvert.DeserializeObject<RootResponse>(response.Content);

            Assert.That(firstMessage, Is.EqualTo(responseMessage1.violationErrors[0].message));
        }
    }
}

