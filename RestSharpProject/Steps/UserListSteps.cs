using NUnit.Framework;
using RestSharp;
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

        [When(@"Client send request with active parameter set to false")]
        public void WhenClientSendRequestWithActiveParameterSetToFalse()
        {
            restRequestUserList = new RestRequest(url + "?active=false");
            restResponseList = restClient.Get(restRequestUserList);
        }

        [When(@"Client send request with active parameter set to true")]
        public void WhenClientSendRequestWithActiveParameterSetToTrue()
        {
            restRequestUserList = new RestRequest(url + "?active=true");
            restResponseList = restClient.Get(restRequestUserList);
        }

        [Then(@"Response is successfull")]
        public void ThenResponseIsSuccessfull()
        {
            Assert.That(restResponseList.IsSuccessful, Is.True);
        }

        [Then(@"contains list of all users")]
        public void ThenContainsListOfAllUsers()
        {
            Assert.That(restResponseList.Content.Contains("\"active\":false"), Is.True);
            Assert.That(restResponseList.Content.Contains("\"active\":true"), Is.True);
        }

        [Then(@"contains list of active users")]
        public void ThenContainsListOfActiveUsers()
        {
            Assert.That(restResponseList.Content.Contains("\"active\":true"), Is.True);
        }
    }
}