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
        IRestResponse response;

        [Given(@"User sets the proper url")]
        public void GivenUserSetsTheProperUrl()
        {
            client = new RestClient("http://intive-patronage.pl");
        }

        [When(@"User sends GET request")]
        public void WhenUserSendsGETRequest()
        {  
            request = new RestRequest("/api/groups", Method.GET);
        }

        [Then(@"The server returns the code (.*)")]
        public void ThenTheServerReturnsTheCode(int code)
        {
            response = client.Execute(request);

            Assert.AreEqual(code, (int)response.StatusCode);
        }

        [Then(@"JSON body contain a list of technology groups")]
        public void ThenJSONBodyContainAListOfTechnologyGroups()
        { 
            var responseMessage = JsonConvert.DeserializeObject<Group>(response.Content);
       
            Assert.That(responseMessage.groups.Contains("Java"), Is.True);
            Assert.That(responseMessage.groups.Contains("JavaScript"), Is.True);
            Assert.That(responseMessage.groups.Contains("QA"), Is.True);
            Assert.That(responseMessage.groups.Contains("Mobile (Android)"), Is.True);
            Assert.That(responseMessage.groups.Count, Is.EqualTo(4));
        }
    }
}
