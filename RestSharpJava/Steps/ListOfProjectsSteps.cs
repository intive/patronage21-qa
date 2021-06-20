using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using TechTalk.SpecFlow;

namespace RestSharpProject.Features
{
    [Binding]
    public class ListOfProjectsSteps
    {
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;
        private string projectUrl = "/projects?year=";


        public ListOfProjectsSteps(RestClient client)
        {
            _client = new RestClient(client.BaseUrl + projectUrl);
        }

        [Given(@"User sets the url")]
        public void GivenUserSetsTheUrl()
        {
            _client.BaseUrl = _client.BaseUrl;
        }

        [When(@"User sends a GET request with a valid '(.*)'")]
        public void WhenUserSendsAGETRequestWithAValid(string year)
        {
            _request = new RestRequest(_client.BaseUrl + year);
        }

        [When(@"User sends a GET request with an invalid '(.*)'")]
        public void WhenUserSendsAGETRequestWithAnInvalid(string year)
        {
            _request = new RestRequest(_client.BaseUrl + year);
        }

        [When(@"User sends a GET request without any year")]
        public void WhenUserSendsAGETRequestWithoutAnyYear()
        {
            _request = new RestRequest(_client.BaseUrl);
        }

        [Then(@"Server returns the code (.*)")]
        public void ThenServerReturnsTheCode(int code)
        { 
            _response = _client.Get(_request);
            Assert.AreEqual(code, (int)_response.StatusCode);
        }

        [Then(@"JSON body contain a list of projects from proper year")]
        public void ThenJSONBodyContainAListOfProjectsFromProperYear()
        {
            var responseMessage = JsonConvert.DeserializeObject<ProjectList>(_response.Content);
            Assert.IsNotNull(responseMessage);
        }

        [Then(@"JSON body contain a list of projects from current year")]
        public void ThenJSONBodyContainAListOfProjectsFromCurrentYear()
        {
            var responseMessage = JsonConvert.DeserializeObject<ProjectList>(_response.Content);
            Assert.That(responseMessage.projects.Count, Is.EqualTo(3));
        }
    }
}

