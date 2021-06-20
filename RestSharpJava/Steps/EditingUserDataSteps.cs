using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestSharpProject.Features
{
    [Binding]
    public class EditingUserDataSteps
    {
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;
        private string editUsertUrl = "/users";
        RootPUT responseMessage;
        UserPUT updatedUser;

        public EditingUserDataSteps(RestClient client)
        {
            _client = new RestClient(client.BaseUrl + editUsertUrl);
        }

        [Given(@"User exists in the database")]
        public static void GivenUserExistsInTheDatabase(Table table)
        {
            var someUser = table.CreateInstance<UserPUT>();
        }

        [When(@"User sends a PUT request")]
        public void WhenUserSendsAPUTRequest(Table table)
        {
            updatedUser = table.CreateInstance<UserPUT>();
            _client.BaseUrl = _client.BaseUrl;
            _request = new RestRequest(_client.BaseUrl);
            _request.AddParameter("application/json", JsonConvert.SerializeObject(updatedUser), ParameterType.RequestBody);

            _response = _client.Put(_request);
        }

        [Then(@"Server returns status (.*) and Json body contain updated parameters")]
        public void ThenServerReturnsStatusAndJsonBodyContainUpdatedParameters(int code)
        {
            Assert.AreEqual(code, (int)_response.StatusCode);

            var getRequest = new RestRequest(_client.BaseUrl + "/kowalski87");
            var getResponse = _client.Get(getRequest);
            responseMessage = JsonConvert.DeserializeObject<RootPUT>(getResponse.Content);

            Assert.That(responseMessage.user.login, Is.EqualTo(updatedUser.login));
            Assert.That(responseMessage.user.firstName, Is.EqualTo(updatedUser.firstName));
            Assert.That(responseMessage.user.lastName, Is.EqualTo(updatedUser.lastName));
            Assert.That(responseMessage.user.email, Is.EqualTo(updatedUser.email));
            Assert.That(responseMessage.user.phoneNumber, Is.EqualTo(updatedUser.phoneNumber));
            Assert.That(responseMessage.user.gitHubUrl, Is.EqualTo(updatedUser.gitHubUrl));
            Assert.That(responseMessage.user.bio, Is.EqualTo(updatedUser.bio));
        }

        [Then(@"Server returns status (.*) and message '(.*)'")]
        public void ThenServerReturnsStatusAndMessage(int code, string message)
        {
            Assert.AreEqual(code, (int)_response.StatusCode);

            var responseMessage2 = JsonConvert.DeserializeObject<RootResponse>(_response.Content);

            Assert.That(message, Is.EqualTo(responseMessage2.violationErrors[0].message));
        }
    }
}
