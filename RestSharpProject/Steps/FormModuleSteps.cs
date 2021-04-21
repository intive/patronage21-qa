using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using System;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class FormModuleSteps
    {
        private string urlPostRegistration = "http://127.0.0.1:8080/api/register";
        RestClient restClient;
        RestRequest restRequest;
        RestResponse restResponse;
        Random rand;
        UserData user;

        [Given(@"Endpoint is /api/register")]
        public void GivenSetTheEndpointWithMethodPOST()
        {
            restClient = new RestClient();
            restRequest = new RestRequest(urlPostRegistration, Method.POST);
        }
        
        [Given(@"Add Headers")]
        public void GivenAddHeaders()
        {
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
        }
        
        [Given(@"User filled required data")]
        [Obsolete]
        public void GivenUserFilledRequiredData()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            int phoneNumber = 123456789;
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, "randomPassword@", login, githubLink);
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled all data")]
        [Obsolete]
        public void GivenUserFilledAllData()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[3] { "Java", "QA", "JavaScript" };

            user = new UserData("Pan", "Jan", "Kowalski", email, 123456789, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data but without field Imię")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutFieldImie()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", null, "Kowalski", email, 123456789, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data but without field Nazwisko")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutFieldNazwisko()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "Jan", null, email, 123456789, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data but without field Adres e-mail")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutFieldAdresE_Mail()
        {
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "Jan", "Kowalski", null, 123456789, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data but without field Numer telefonu")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutField()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "Jan", "Kowalski", email, 0, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data without checked fields: JavaScript, Java, QA, Mobile")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutCheckedFieldsJavaScriptJavaQAMobile()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";

            user = new UserData("Pan", "Jan", "Kowalski", email, 123456789, null, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data with checking all technology groups")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithCheckingAllAboutTechnologyGroups()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[4] { "Java", "QA", "JavaScript", "Mobile" };

            user = new UserData("Pan", "Jan", "Kowalski", email, 123456789, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data with checking one field about technology groups")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithCheckingOneFieldAboutTechnologyGroups()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "QA" };

            user = new UserData("Pan", "Jan", "Kowalski", email, 123456789, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data with checking three fields from Technologie")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithCheckingThreeFieldsFromTechnologie()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[3] { "Java", "QA", "JavaScript" };

            user = new UserData("Pan", "Jan", "Kowalski", email, 123456789, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data without field github link")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutFieldsHasloAndPowtorzHaslo()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string[] technologies = new string[3] { "Java", "QA", "JavaScript" };

            user = new UserData("Pan", "Jan", "Kowalski", email, 123456789, technologies, login, null, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data without field Hasło")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutField()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "QA" };

            user = new UserData("Pan", "Jan", "Kowalski", email, 123456789, technologies, login, githubLink, null);
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled request to API without data")]
        [Obsolete]
        public void GivenUserFilledRequestToAPIWithoutData()
        {
            user = new UserData(null, null, null, null, 0, null, null, null, null);
            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled request to API with too long phone number")]
        [Obsolete]
        public void GivenUserFilledRequestToAPIWithTooLongPhoneNumber()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "https://github.com";
            string[] technologies = new string[1] { "QA" };
            int wrongPhoneNumber = 1234567890;

            user = new UserData("Pan", "Jan", "Kowalski", email, wrongPhoneNumber, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User fills field github link with random letters")]
        [Obsolete]
        public void GivenUserFillsFieldWithRandomLetters()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";
            string login = $"exampleLogin{rand.Next(0, 10000)}";
            string githubLink = "qazbji";
            string[] technologies = new string[1] { "QA" };
            int wrongPhoneNumber = 1234567890;

            user = new UserData("Pan", "Jan", "Kowalski", email, wrongPhoneNumber, technologies, login, githubLink, "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled request to API with too short phone number")]
        public void GivenUserFilledRequestToAPIWithTooShortPhoneNumber()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"User interface sends the request to API")]
        [Obsolete]
        public void WhenUserInterfaceSendsTheRequestToAPI()
        {
            var body = ScenarioContext.Current["user"];
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(new { body }), ParameterType.RequestBody);
        }
        
        [Then(@"The server should return status 200 with empty JSON body")]
        public void ThenTheServerShouldReturnStatusWithEmptyJSONBody()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Console.WriteLine(restResponse.Content);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Imię")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldImie()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Nazwisko")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldNazwisko()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Adres e-mail")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldAdresE_Mail()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Numer telefonu")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldNumerTelefonu()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about unchecked fields: JavaScript, Java, QA, Mobile")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutUncheckedFieldsJavaScriptJavaQAMobile()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about too many technology groups checked")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutTooManyTechnologyGroupsChecked()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should execute request and return status 200 and empty JSON body")]
        public void ThenTheServerShouldExecuteRequestAndReturnStatusAndEmptyJSONBody()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about incorrect github link")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldsHasloAndPowtorzHaslo()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Hasło")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldHaslo()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing data")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingData()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }

        [Then(@"The server should return status 400 and JSON body with message about incorrect phone number")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutIncorrectPhoneNumber()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);
        }

    }
}
