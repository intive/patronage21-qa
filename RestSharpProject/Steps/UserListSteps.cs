using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    [Scope(Feature = "User list")]
    public class UserListSteps
    {
        private IRestClient restClient = new RestClient();
        private IRestRequest restRequestUserList;
        private IRestResponse restResponseList = new RestResponse();
        private string url;

        [Given(@"Endpoint is api/list")]
        public void GivenEndpointIsApiList()
        {
            url = "http://127.0.0.1:8080/api/list";
        }

        [When(@"Client sends request to API")]
        public void WhenClientSendsRequestToApi()
        {
            restRequestUserList = new RestRequest(url);
            restResponseList = restClient.Get(restRequestUserList);
        }

        [When(@"Client sends request with active parameter set to true")]
        public void WhenClientSendsRequestWithActiveParameterSetToTrue()
        {
            restRequestUserList = new RestRequest(url + "?active=true");
            restResponseList = restClient.Get(restRequestUserList);
        }

        [Then(@"Response is successful")]
        public void ThenResponseIsSuccessfull()
        {
            Assert.That(restResponseList.IsSuccessful, Is.True);
        }

        [Then(@"contains list of all users")]
        public void ThenContainsListOfAllUsers()
        {
            List<UserModel> restResponseAllUserList = JsonConvert.DeserializeObject<List<UserModel>>(restResponseList.Content);
            Assert.That(restResponseAllUserList.Count > 0, Is.True);
        }

        [Then(@"contains list of active users")]
        public void ThenContainsListOfActiveUsers()
        {
            List<UserModel> restResponseActiveUserList = JsonConvert.DeserializeObject<List<UserModel>>(restResponseList.Content);
            if (restResponseActiveUserList.Count == 0)
            {
                //'[]' is also positive result
                Assert.IsTrue(true);
            }
            else
            {
                Assert.That(restResponseList.Content.Contains("\"active\":false"), Is.False);
            }
        }
    }
}