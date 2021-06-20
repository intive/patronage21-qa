using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{ 
    [Binding]
    public class ListOfTechnologyGroupsSteps
    {
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;
        private string grouptUrl = "/groups";

        public ListOfTechnologyGroupsSteps(RestClient client)
        {
            _client = new RestClient(client.BaseUrl + grouptUrl);
        }

        [Given(@"User sets the proper url")]
        public void GivenUserSetsTheProperUrl()
        {
            _client.BaseUrl = _client.BaseUrl;
        }

        [When(@"User sends GET request")]
        public void WhenUserSendsGETRequest()
        {
            _request = new RestRequest(_client.BaseUrl);
        }

        [Then(@"The server returns the code (.*)")]
        public void ThenTheServerReturnsTheCode(int code)
        {
            _response = _client.Get(_request);

            Assert.AreEqual(code, (int)_response.StatusCode);
        }

        [Then(@"JSON body contain a list of technology groups")]
        public void ThenJSONBodyContainAListOfTechnologyGroups()
        { 
            var responseMessage = JsonConvert.DeserializeObject<Group>(_response.Content);
       
            Assert.That(responseMessage.groups.Contains("Java"), Is.True);
            Assert.That(responseMessage.groups.Contains("JavaScript"), Is.True);
            Assert.That(responseMessage.groups.Contains("QA"), Is.True);
            Assert.That(responseMessage.groups.Contains("Mobile (Android)"), Is.True);
            Assert.That(responseMessage.groups.Count, Is.EqualTo(4));
        }
    }
}
