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
        RestClient client;
        RestRequest request;
        IRestResponse response;


        [Given(@"User sets the url")]
        public void GivenUserSetsTheUrl()
        {
            client = new RestClient("http://intive-patronage.pl");
        }

        [When(@"User sends a GET request with a valid '(.*)'")]
        public void WhenUserSendsAGETRequestWithAValid(string year)
        {
            request = new RestRequest("/api/projects?year=" + year, Method.GET);
        }

        [When(@"User sends a GET request with an invalid '(.*)'")]
        public void WhenUserSendsAGETRequestWithAnInvalid(string year)
        {
            request = new RestRequest("/api/projects?year=" + year, Method.GET);
        }

        [When(@"User sends a GET request without any year")]
        public void WhenUserSendsAGETRequestWithoutAnyYear()
        {
            request = new RestRequest("/api/projects?year=", Method.GET);
        }

        [Then(@"Server returns the code (.*)")]
        public void ThenServerReturnsTheCode(int code)
        {
            response = client.Execute(request);
            Assert.AreEqual(code, (int)response.StatusCode);
        }

        [Then(@"JSON body contain a list of projects from proper year")]
        public void ThenJSONBodyContainAListOfProjectsFromProperYear()
        {
            var responseMessage = JsonConvert.DeserializeObject<ProjectList>(response.Content);
            Assert.IsNotNull(responseMessage);
        }

        [Then(@"JSON body contain a list of projects from current year")]
        public void ThenJSONBodyContainAListOfProjectsFromCurrentYear()
        {
            var responseMessage = JsonConvert.DeserializeObject<ProjectList>(response.Content);
            Assert.That(responseMessage.projects.Count, Is.EqualTo(3));
        }
    }
}

