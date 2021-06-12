using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class UserListSteps
    {
        private IRestClient _restClient;
        private IRestRequest _restRequestUserList;
        private IRestResponse _restResponseList;
        private string url = "/list";

        public UserListSteps(RestClient restClient)
        {
            _restClient = new RestClient(restClient.BaseUrl + url);
        }

        [Given(@"Endpoint is api/list")]
        public void GivenEndpointIsApiList()
        {
            _restClient.BaseUrl = _restClient.BaseUrl;
        }

        [When(@"Client sends request to API")]
        public void WhenClientSendsRequestToApi()
        {
            _restRequestUserList = new RestRequest(_restClient.BaseUrl);
            _restResponseList = _restClient.Get(_restRequestUserList);
        }

        [When(@"Client sends request with active parameter set to true")]
        public void WhenClientSendsRequestWithActiveParameterSetToTrue()
        {
            _restRequestUserList = new RestRequest(_restClient.BaseUrl + "?active=true");
            _restResponseList = _restClient.Get(_restRequestUserList);
        }

        [Then(@"Response is successful")]
        public void ThenResponseIsSuccessfull()
        {
            Assert.That(_restResponseList.IsSuccessful, Is.True);
        }

        [Then(@"contains list of all users")]
        public void ThenContainsListOfAllUsers()
        {
            List<UserModel> restResponseAllUserList = JsonConvert.DeserializeObject<List<UserModel>>(_restResponseList.Content);
            Assert.That(restResponseAllUserList.Count > 0, Is.True);
        }

        [Then(@"contains list of active users")]
        public void ThenContainsListOfActiveUsers()
        {
            List<UserModel> restResponseActiveUserList = JsonConvert.DeserializeObject<List<UserModel>>(_restResponseList.Content);
            if (restResponseActiveUserList.Count == 0)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.That(_restResponseList.Content.Contains("\"active\":false"), Is.False);
            }
        }
    }
}