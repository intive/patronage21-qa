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
    public class AddingProjectsToUserAccountSteps
    {
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;
        private string addProjectUrl = "/users";
       

        public AddingProjectsToUserAccountSteps(RestClient client)
        {
            _client = new RestClient(client.BaseUrl + addProjectUrl);
        }

        [Given(@"Url to add projects is api/users")]
        public void GivenUrlToAddProjectsIsApiUsers()
        {
            _client.BaseUrl = _client.BaseUrl;
        }

        [When(@"User '(.*)' sends the PUT request to add (.*) projects")]
        public void WhenUserSendsThePUTRequestToAddProjects(string username, int count)
        {
            List<Projects> projects = new List<Projects>();
            for (int i = 0; i < count; i++)
            {
                projects.Add(new Projects($"fajny pojekt {i}", "Developer"));
            }

            UserWithProjects user1 = new UserWithProjects(username, "Anna", "Nowak", "ania@wp.pl", "456456456", "https://www.github.com/ssadf", "opis", projects);

            _request = new RestRequest(_client.BaseUrl);
            _request.AddParameter("application/json", JsonConvert.SerializeObject(user1), ParameterType.RequestBody);

            _response = _client.Put(_request);

        }

        [Then(@"Server returns status (.*)")]
        public void ThenServerReturnsStatus(int code)
        {
            Assert.AreEqual(code, (int)_response.StatusCode);
        }

        [Then(@"Server returns status (.*) and error message '(.*)'")]
        public void ThenServerReturnsStatusAndErrorMessage(int code, string message)
        {
            var responseMessage2 = JsonConvert.DeserializeObject<RootResponse>(_response.Content);

            Assert.AreEqual(code, (int)_response.StatusCode);
            Assert.That(message, Is.EqualTo(responseMessage2.violationErrors[0].message));
        }
    }
}