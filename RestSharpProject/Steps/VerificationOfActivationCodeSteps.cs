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
    [Scope(Feature = "Verification of activation code")]
    public class VerificationOfActivationCodeSteps
    {
        private IRestClient restClient = new RestClient();
        private IRestRequest restRequest;
        private IRestResponse restResponse = new RestResponse();

        private string userName = "Janina";
        private string userLastName = "Nowak";
        private string email = User.GenerateEmailAdress();
        private string login = User.GenerateLogin();
        private string githubLink = User.GenerateGithubLink();
        private Nullable<int> phoneNumber = 123456789;
        private string password = "randomPassword5@";
        private string activatedUserEmail;

        [Given(@"Endpoint is /api/activate")]
        public void GivenEndpointIsApiActivate()
        {
            restRequest = new RestRequest("http://127.0.0.1:8080/api/activate");
        }

        [Given(@"Inactive User is in database")]
        public void GivenInactiveUserIsInDatabase()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");
            IRestRequest restRequestRegister = new RestRequest("http://127.0.0.1:8080/api/register");
            restRequestRegister.AddJsonBody(new
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

            IRestResponse restResponseRegister = new RestResponse();
            restResponseRegister = restClient.Post(restRequestRegister);
        }

        [Given(@"User is activated")]
        public void GivenUserIsActivated()
        {
            IRestRequest restRequestList = new RestRequest("http://127.0.0.1:8080/api/list?active=true");
            IRestResponse restResponseList = new RestResponse();
            restResponseList = restClient.Get(restRequestList);
            List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(restResponseList.Content);
            activatedUserEmail = userList[0].email;
        }

        [When(@"Client enters false code and the email")]
        public void WhenClientEntersFalseCodeAndTheEmail()
        {
            restRequest.AddJsonBody(new
            {
                email = email,
                activationCode = "12345678"
            });
        }

        [When(@"the request is sent to API")]
        public void WhenTheRequestIsSentToAPI()
        {
            restResponse = restClient.Put(restRequest);
        }

        [When(@"Client enters a code and not existing email")]
        public void WhenClientEntersACodeAndNotExistingEmail()
        {
            restRequest.AddJsonBody(new
            {
                email = "email@email.com",
                activationCode = "12345678"
            });
        }

        [When(@"Client enters previously used code and the email")]
        public void WhenClientEntersPreviouslyUsedCodeAndTheEmail()
        {
            restRequest.AddJsonBody(new
            {
                email = activatedUserEmail,
                activationCode = "12345678"
            });
        }

        [When(@"Client enters (.*) and the email")]
        public void WhenClientEntersAndTheEmail(string code)
        {
            restRequest.AddJsonBody(new
            {
                email = email,
                activationCode = code
            });
        }

        [When(@"Client enters code and incomplete email")]
        public void WhenClientEntersCodeAndIncompleteEmail(Table table)
        {
            restRequest.AddJsonBody(new
            {
                email = "example476email.com",
                activationCode = "12345678"
            });
        }

        [Then(@"response contains status '(.*)'")]
        public void ThenResponseContainsStatus(string status)
        {
            Assert.That(restResponse.Content.Contains(status));
        }

        [Then(@"Verification is not successful")]
        public void ThenVerificationIsNotSuccessful()
        {
            Assert.That(restResponse.IsSuccessful, Is.False);
        }

        [Then(@"return Status is (.*)")]
        public void ThenReturnStatusIs(int statusCode)
        {
            Assert.AreEqual((int)restResponse.StatusCode, statusCode);
        }

        [Then(@"response contains Niepoprawny kod aktywacyjny")]
        public void ThenResponseContainsNiepoprawnyKodAktywacyjny()
        {
            Assert.IsTrue(restResponse.Content.Contains("Niepoprawny kod aktywacyjny"));
        }
    }
}