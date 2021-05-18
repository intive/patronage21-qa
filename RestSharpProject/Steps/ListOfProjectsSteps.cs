using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class ListOfProjectsSteps
    {
        RestClient client = new RestClient();
        IRestRequest request = new RestRequest();


        [Given(@"User sets the url")]
        public void GivenUserSetsTheUrl()
        {
            client = new RestClient("http://intive-patronage.pl:9101");
        }

        [When(@"User sends a GET request")]
        public void WhenUserSendsAGETRequest()
        {
            request = new RestRequest("/api/projects?year=2021", Method.GET);
        }

        [Then(@"Server returns the code (.*) and JSON body contain a list of projects")]
        public void ThenServerReturnsTheCodeAndJSONBodyContainAListOfProjects(int code)
        {
            IRestResponse response = client.Execute(request);
            var responseMessage = JsonConvert.DeserializeObject<Project>(response.Content);

            Assert.AreEqual(code, (int)response.StatusCode);
            Assert.That(responseMessage.projects[0], Is.EqualTo("Projekt I"));
            Assert.That(responseMessage.projects[1], Is.EqualTo("Projekt II"));
            Assert.That(responseMessage.projects[2], Is.EqualTo("Projekt III"));
        }
    }
}
