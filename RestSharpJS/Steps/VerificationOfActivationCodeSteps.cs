using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class VerificationOfActivationCodeSteps
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;

        private string userName = "Janina";
        private string userLastName = "Nowak";
        private string email = User.GenerateEmailAdress();
        private string login = User.GenerateLogin();
        private string githubLink = User.GenerateGithubLink();
        private Nullable<int> phoneNumber = 123456789;
        private string password = "randomPassword5@";
        private string activatedUserEmail;
        private string activateUrl = "/activate";
        private string registrationUrl, activationUrl;

        public VerificationOfActivationCodeSteps(RestClient restClient)
        {
            activationUrl = restClient.BaseUrl + "/list";
            registrationUrl = restClient.BaseUrl + "/register";
            _restClient = new RestClient(restClient.BaseUrl + activateUrl);
            _restRequest = new RestRequest(Method.PUT);
        }

        [Given(@"Endpoint is /api/activate")]
        public void GivenEndpointIsApiActivate()
        {
            _restClient.BaseUrl = _restClient.BaseUrl;
        }

        [Given(@"Inactive User is in database")]
        public void GivenInactiveUserIsInDatabase()
        {
            RestClient restClient = new RestClient();
            List<string> technologies = new List<string>();
            technologies.Add("QA");
            RestRequest restRequest = new RestRequest(registrationUrl, Method.POST);
            restRequest.AddJsonBody(new
            {
                technologies = technologies,
                firstName = userName,
                lastName = userLastName,
                email = email,
                login = login,
                phone = phoneNumber,
                password = password,
                githubLink = githubLink,
            });

            restClient.Execute(restRequest);
        }

        [Given(@"User is activated")]
        public void GivenUserIsActivated()
        {
            RestResponse restResponse = new RestResponse();
            RestRequest restRequest = new RestRequest(activationUrl + "?active=true");
            RestClient restClient = new RestClient();
            restResponse = (RestResponse)restClient.Get(restRequest);
            List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(restResponse.Content);
            activatedUserEmail = userList[0].email;
        }

        [When(@"the request is sent to API")]
        public void WhenTheRequestIsSentToAPI()
        {
            _restResponse = _restClient.Put(_restRequest);
        }

        [When(@"Client enters a code and not existing email")]
        public void WhenClientEntersACodeAndNotExistingEmail()
        {
            _restRequest.AddJsonBody(new
            {
                email = "email@email.com",
                activationCode = "12345678"
            });
        }

        [When(@"Client inserts previously used code and the email")]
        public void WhenClientInsertsPreviouslyUsedCodeAndTheEmail()
        {
            _restRequest.AddJsonBody(new
            {
                email = activatedUserEmail,
                activationCode = "12345678"
            });
        }

        [When(@"Client enters (.*) and the email")]
        public void WhenClientEntersAndTheEmail(string code)
        {
            _restRequest.AddJsonBody(new
            {
                email = email,
                activationCode = code
            });
        }

        [When(@"Client enters code and incomplete email")]
        public void WhenClientEntersCodeAndIncompleteEmail(Table table)
        {
            _restRequest.AddJsonBody(new
            {
                email = "example476email.com",
                activationCode = "12345678"
            });
        }

        [Then(@"response contains status '(.*)'")]
        public void ThenResponseContainsStatus(string status)
        {
            Assert.IsTrue(_restResponse.Content.Contains(status));
        }

        [Then(@"Verification is not successful")]
        public void ThenVerificationIsNotSuccessful()
        {
            Assert.That(_restResponse.IsSuccessful, Is.False);
        }

        [Then(@"return Status is (.*)")]
        public void ThenReturnStatusIs(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_restResponse.StatusCode);
        }
    }
}