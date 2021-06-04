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
        RestClient client;
        RestRequest request;
        IRestResponse response;

        [Given(@"Url is set")]
        public void GivenUrlIsSet()
        {
            client = new RestClient("http://intive-patronage.pl");
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

            request = new RestRequest("/api/users", Method.PUT);
            request.AddParameter("application/json", JsonConvert.SerializeObject(user1), ParameterType.RequestBody);

            response = client.Execute(request);
        }

        [Then(@"Server returns status (.*)")]
        public void ThenServerReturnsStatus(int code)
        {
            Assert.AreEqual(code, (int)response.StatusCode);
        }

        [Then(@"Server returns status (.*) and error message '(.*)'")]
        public void ThenServerReturnsStatusAndErrorMessage(int code, string message)
        {
            var responseMessage2 = JsonConvert.DeserializeObject<RootResponse>(response.Content);

            Assert.AreEqual(code, (int)response.StatusCode);
            Assert.That(message, Is.EqualTo(responseMessage2.violationErrors[0].message));

        }
    }
