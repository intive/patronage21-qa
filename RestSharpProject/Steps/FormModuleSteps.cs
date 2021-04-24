using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class FormModuleSteps
    {
        RestClient restClient = new RestClient();
        RestRequest restRequest = new RestRequest("http://127.0.0.1:8080/api/register", Method.POST);
        RestResponse restResponse;
        User user;

        string email = User.GenerateEmailAdress();
        string login = User.GenerateLogin();
        string githubLink = User.GenerateGithubLink();

        Nullable<int> phoneNumber = 123456789;
        string password = "randomPassword@";

        [Given(@"User filled data correctly")]
        public void GivenUserFilledJanKowalskiExampleEmail_ComQARandomPasswordRandomLoginGithub_ComExampleCorrectly()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled all data")]
        public void GivenUserFilledAllData()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");
            technologies.Add("JS");
            technologies.Add("Java");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled required data but without data in field Imię")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldImie()
        {
            List<string> technologies = new List<string>();
            technologies.Add("JS");

            user = new User("", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled required data but without data in field Nazwisko")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldNazwisko()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Java");

            user = new User("Jan", "", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled required data but without data in field Adres email")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldAdresEmail()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");

            user = new User("Jan", "Kowalski", "", phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled required data but without data in field Numer telefonu")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldNumerTelefonu()
        {
            List<string> technologies = new List<string>();
            technologies.Add("JS");

            user = new User("Jan", "Kowalski", email, null, technologies, password, login, githubLink);
        }

        [Given(@"User filled required data but without data in field Technologie")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldTechnologie()
        {
            List<string> technologies = new List<string>();

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled required data but without data in field Hasło")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldHaslo()
        {
            List<string> technologies = new List<string>();
            technologies.Add("JS");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, "", login, githubLink);
        }

        [Given(@"User filled required data but without data in field Login")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldLogin()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, "", githubLink);
        }

        [Given(@"User filled required data but without data in field Github link")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldGithubLink()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Java");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, "");
        }

        [Given(@"User interface adds headers")]
        public void GivenUserInterfaceAddsHeaders()
        {
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
        }

        [When(@"User interface sends the request to API")]
        public void WhenUserInterfaceSendsTheRequestToAPI()
        {
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);
        }

        [Then(@"The server should return positive status 200")]
        public void ThenTheServerShouldReturnPositiveStatus()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
        }

        [Then(@"JSON body without sensitive data")]
        public void ThenJSONBodyWithoutSensitiveData()
        {

        }

        [Then(@"The server should return status 400")]
        public void ThenTheServerShouldReturnStatus()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }

        [Then(@"JSON body with message about empty field Imię")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldImie()
        {

        }

        [Then(@"JSON body with message about empty field Nazwisko")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNazwisko()
        {

        }

        [Then(@"JSON body with message about empty field Adres email")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldAdresEmail()
        {

        }

        [Then(@"JSON body with message about empty field Numer telefonu")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerTelefonu()
        {

        }

        [Then(@"JSON body with message about empty field Technologie")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerTechnologie()
        {

        }

        [Then(@"JSON body with message about empty field Hasło")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerHaslo()
        {

        }

        [Then(@"JSON body with message about empty field Login")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerLogin()
        {

        }

        [Then(@"JSON body with message about empty field Github link")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerGithubLink()
        {

        }
    }
}
