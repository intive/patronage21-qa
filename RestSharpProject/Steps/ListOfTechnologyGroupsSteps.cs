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
        RestClient client = new RestClient();
        IRestRequest request = new RestRequest();
       
        [Given(@"User sets the proper url")]
        public void GivenUserSetsTheProperUrl()
        {
            client = new RestClient("http://intive-patronage.pl:9101");
        }

        [When(@"User sends GET request")]
        public void WhenUserSendsGETRequest()
        {  
            request = new RestRequest("/api/groups", Method.GET);
        }

        [Then(@"The server returns the code (.*) and JSON body contain a list of technology groups")]
        public void ThenTheServerReturnsTheCodeAndJSONBodyContainAListOfTechnologyGroups(int code)
        {
            IRestResponse response = client.Execute(request);
            var responseMessage = JsonConvert.DeserializeObject<Group>(response.Content);
        
            Assert.AreEqual(code, (int)response.StatusCode);
            Assert.That(responseMessage.groups[0], Is.EqualTo("Java"));
            Assert.That(responseMessage.groups[1], Is.EqualTo("JavaScript"));
            Assert.That(responseMessage.groups[2], Is.EqualTo("QA"));
            Assert.That(responseMessage.groups[3], Is.EqualTo("Mobile (Android)"));
            Assert.That(responseMessage.groups[4], Is.EqualTo("Pearl Advanced"));
        }
    }
}
