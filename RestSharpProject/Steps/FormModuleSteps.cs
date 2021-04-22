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
        private string urlPostRegistration = "http://127.0.0.1:8080/api/register";
        RestClient restClient;
        RestRequest restRequest;
        RestResponse restResponse;
        UserData user;

        string email = UserData.GenerateEmailAdress();
        string login = UserData.GenerateLogin();
        string githubLink = UserData.GenerateGithubLink();

        Nullable<int> phoneNumber = 123456789;
        string password = "randomPassword@";

        [Given(@"Endpoint is /api/register")]
        public void GivenEndpointIsApiRegister()
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
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled all data")]
        [Obsolete]
        public void GivenUserFilledAllData()
        {
            string[] technologies = new string[3] { "Java", "QA", "JS" };

            user = new UserData("Pani", "Dorota", "Kowalska", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data but without data in field Imię")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldImie()
        {
            string[] technologies = new string[1] { "QA" };

            user = new UserData("Pan", "", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data but without data in field Nazwisko")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldNazwisko()
        {
            string[] technologies = new string[1] { "JS" };

            user = new UserData("Pani", "Dorota", "", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data but without data in field Adres e-mail")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldAdresE_Mail()
        {
            string[] technologies = new string[1] { "QA" };

            user = new UserData("Pan", "Jan", "Kowalski", "", phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data without data in field login")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutDataInFieldLogin()
        {
            string[] technologies = new string[1] { "Mobile" };

            user = new UserData("Pani", "Dorota", "", email, phoneNumber, technologies, password, "", githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data without checked fields: JavaScript, Java, QA, Mobile")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutCheckedFieldsJavaScriptJavaQAMobile()
        {
            string[] technologies = new string[0];
            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data with checking all technology groups")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithCheckingAllTechnologyGroups()
        {
            string[] technologies = new string[4] { "JS", "Java", "QA", "Mobile" };

            user = new UserData("Pani", "Dorota", "Kowalska", email, 0, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data with checking one field about technology groups")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithCheckingOneFieldAboutTechnologyGroups()
        {
            string[] technologies = new string[1] { "QA" };
            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data with checking three fields from Technologie")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithCheckingThreeFieldsFromTechnologie()
        {
            string[] technologies = new string[3] { "JS", "QA", "Java" };

            user = new UserData("Pani", "Dorota", "Kowalska", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data without data in field github link")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutDataInFieldGithubLink()
        {
            string[] technologies = new string[1] { "QA" };

            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, password, login, "");

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data without data in field Hasło")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutDataInFieldHaslo()
        {
            string[] technologies = new string[1] { "JS" };

            user = new UserData("Pani", "Dorota", "Kowalska", email, phoneNumber, technologies, "", login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User didn't fill data")]
        [Obsolete]
        public void GivenUserDidnTFillData()
        {
            string[] technologies = new string[1];
            Nullable<int> emptyPhoneNumber = null;

            user = new UserData("", "", "", "", emptyPhoneNumber, technologies, "", "", "");

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled request to API with too long phone number")]
        [Obsolete]
        public void GivenUserFilledRequestToAPIWithTooLongPhoneNumber()
        {
            string[] technologies = new string[1] { "QA" };
            int longPhoneNumber = 1234567890;

            user = new UserData("Pan", "Jan", "Kowalski", email, longPhoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled request to API with too short phone number")]
        [Obsolete]
        public void GivenUserFilledRequestToAPIWithTooShortPhoneNumber()
        {
            string[] technologies = new string[1] { "Mobile" };
            int shortPhoneNumber = 12345678;

            user = new UserData("Pani", "Dorota", "Kowalska", email, shortPhoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills field github link with random letters")]
        [Obsolete]
        public void GivenUserFillsFieldGithubLinkWithRandomLetters()
        {
            string[] technologies = new string[1] { "QA" };
            string githubLinkWithRandomLetters = "qazxswedc";

            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLinkWithRandomLetters);

            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills too long first name")]
        [Obsolete]
        public void GivenUserFillsTooLongFirstName()
        {
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "PrzykładBardzoDługiegoImienia", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user); ;
        }
        
        [Given(@"User fills too long last name")]
        [Obsolete]
        public void GivenUserFillsTooLongLastName()
        {
            string[] technologies = new string[1] { "JS" };

            user = new UserData("Pan", "Jan", "PrzykładBardzoDługiegoNazwiska", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user); ;
        }
        
        [Given(@"User fills incorrect email")]
        [Obsolete]
        public void GivenUserFillsIncorrectEmail()
        {
            string[] technologies = new string[1] { "QA" };
            string incorrectEmail = "exampleWrongEmail.com";

            user = new UserData("Pani", "Dorota", "Kowalska", incorrectEmail, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills incorrect password")]
        [Obsolete]
        public void GivenUserFillsIncorrectPassword()
        {
            string[] technologies = new string[1] { "Mobile" };
            string wrongPassword = "wrongpassword";

            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, wrongPassword, login, githubLink);

            ScenarioContext.Current.Add("user", user); ;
        }

        [Given(@"User fills email which is not unique")]
        [Obsolete]
        public void GivenUserFillsNotUniqueEmail()
        {
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "Jan", "Kowalski", "example@email.com", phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User fills login which is not unique")]
        [Obsolete]
        public void GivenUserFillsNotUniqueLogin()
        {
            string[] technologies = new string[1] { "Java" };

            user = new UserData("Pan", "Jan", "Kowalski", email, phoneNumber, technologies, password, "exampleLogin", githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data but without data about title")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutDataAboutTitle()
        {
            string[] technologies = new string[1] { "Mobile" };

            user = new UserData("", "Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [When(@"User interface sends the request to API")]
        [Obsolete]
        public void WhenUserInterfaceSendsTheRequestToAPI()
        {
            var body = ScenarioContext.Current["user"];
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
        }
        
        [Then(@"The server should return positive status 200")]
        [Obsolete]
        public void ThenTheServerShouldReturnPositiveStatus()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(200, (int)restResponse.StatusCode);

            ScenarioContext.Current.Add("response", restResponse.Content);
        }

        [Then(@"JSON body without sensitive data")]
        [Obsolete]
        public void ThenJSONBodyWithoutSensitiveData()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);
            string jsonHasFieldPassword = (string)parseRestResponse["password"];
            Assert.AreEqual(null, jsonHasFieldPassword);
        }

        [Then(@"The server should return status 400")]
        [Obsolete]
        public void ThenTheServerShouldReturnStatus_BadRequest()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);

            ScenarioContext.Current.Add("response", restResponse.Content);
        }

        [Then(@"JSON body with message about empty field Imię")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutEmptyFieldImie()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            string takeErrorFromResponse = (string)parseRestResponse["fields"]["firstName"][0].ToString();
            string errorAboutName = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Imie jest wymagane", errorAboutName);
        }
        
        [Then(@"JSON body with message about empty field Nazwisko")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNazwisko()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            string takeErrorFromResponse = (string)parseRestResponse["fields"]["lastName"][0].ToString();
            string errorAboutLastName = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Nazwisko jest wymagane", errorAboutLastName);
        }
        
        [Then(@"JSON body with message about empty field Adres e-mail")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutEmptyFieldAdresE_Mail()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["email"][0].ToString();
            var errorAboutEmail = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Niepoprawny email", errorAboutEmail);
        }
        
        [Then(@"JSON body with message about empty field Numer telefonu")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerTelefonu()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["phone"][0].ToString();
            var errorAboutPhone = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Numer powinien składać się wyłącznie z cyfr", errorAboutPhone);
        }
        
        [Then(@"JSON body with message about unchecked fields: JavaScript, Java, QA, Mobile")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutUncheckedFieldsJavaScriptJavaQAMobile()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["technologies"][0].ToString();
            var errorAboutTechnologies = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Proszę wybrać conajmniej jedną technologię", errorAboutTechnologies);
        }
        
        [Then(@"JSON body with message about too many technology groups checked")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutTooManyTechnologyGroupsChecked()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["technologies"][0].ToString();
            var errorAboutTechnologies = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Proszę wybrać maksymanie trzy technologie", errorAboutTechnologies);
        }
        
        [Then(@"JSON body with message about incorrect github link")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutIncorrectGithubLink()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["githubLink"][0].ToString();
            var errorAboutGithubLink = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Niepoprawny link", errorAboutGithubLink);
        }
        
        [Then(@"JSON body with message about empty field Hasło")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutEmptyFieldHaslo()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["password"][0].ToString();
            var errorAboutPassword = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Hasło musi składać się z co najmniej ośmiu znaków", errorAboutPassword);
        }
        
        [Then(@"JSON body with message about missing data")]
        public void ThenJSONBodyWithMessageAboutMissingData()
        {
            
        }

        [Then(@"JSON body with error message about too long phone number")]
        [Obsolete]
        public void ThenJSONBodyWithErrorMessageAboutTooLongPhoneNumber()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["phone"][0].ToString();
            var errorAboutPhone = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Numer jest za długi", errorAboutPhone);
        }

        [Then(@"JSON body with error message about too short phone number")]
        [Obsolete]
        public void ThenJSONBodyWithErrorMessageAboutTooShortPhoneNumber()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["phone"][0].ToString();
            var errorAboutPhone = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Numer jest za krótki", errorAboutPhone);
        }

        [Then(@"JSON body with error message about too long first name")]
        [Obsolete]
        public void ThenJSONBodyWithErrorMessageAboutTooLongFirstName()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["firstName"][0].ToString();
            var errorAboutFirstName = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Imię jest za długie", errorAboutFirstName);
        }

        [Then(@"JSON body with error message about too long last name")]
        [Obsolete]
        public void ThenJSONBodyWithErrorMessageAboutTooLongLastName()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["lastName"][0].ToString();
            var errorAboutLastName = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Nazwisko jest za długie", errorAboutLastName);
        }

        [Then(@"JSON body with message about incorrect email")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutIncorrectEmail()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["email"][0].ToString();
            var errorAboutEmail = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Niepoprawny email", errorAboutEmail);
        }

        [Then(@"JSON body with message about incorrect password")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutIncorrectPassword()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["password"][0].ToString();
            var errorAboutPassword = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Hasło musi mieć przynajmniej jedną dużą literę i jeden znak specjalny", errorAboutPassword);
        }

        [Then(@"JSON body with message about not unique email")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutNotUniqueEmail()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["email"][0].ToString();
            var errorAboutEmail = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Email jest już zajęty", errorAboutEmail);
        }

        [Then(@"JSON body with message about incorrect login")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutIncorrectLogin()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["login"][0].ToString();
            var errorAboutLogin = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Login jest wymagany", errorAboutLogin);
        }

        [Then(@"JSON body with message about incorrect title")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutIncorrectTitle()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["title"][0].ToString();
            var errorAboutTitle = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Niedozwolona wartość", errorAboutTitle);
        }

        [Then(@"JSON body with message about not unique login")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutNotUniqueLogin()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);

            var takeErrorFromResponse = parseRestResponse["fields"]["login"][0].ToString();
            var errorAboutEmail = takeErrorFromResponse.TrimStart('{').TrimEnd('}');

            Assert.AreEqual("Login jest już zajęty", errorAboutEmail);
        }
    }
}
