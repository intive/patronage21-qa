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

        int phoneNumber = 123456789;
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

        [Given(@"User filled required data but without data in field Numer telefonu")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldNumerTelefonu()
        {
            string[] technologies = new string[1] { "JS" };

            user = new UserData("Pani", "Dorota", "Kowalska", email, 0, technologies, password, login, githubLink);

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled required data without checked fields: JavaScript, Java, QA, Mobile")]
        [Obsolete]
        public void GivenUserFilledRequiredDataWithoutCheckedFieldsJavaScriptJavaQAMobile()
        {
            string[] technologies = new string[3];
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

            user = new UserData("", "", "", "", 0, technologies, "", "", "");

            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User filled request to API with too long phone number")]
        [Obsolete]
        public void GivenUserFilledRequestToAPIWithTooLongPhoneNumber()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled request to API with too short phone number")]
        [Obsolete]
        public void GivenUserFilledRequestToAPIWithTooShortPhoneNumber()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills field github link with random letters")]
        [Obsolete]
        public void GivenUserFillsFieldGithubLinkWithRandomLetters()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills too long first name")]
        [Obsolete]
        public void GivenUserFillsTooLongFirstName()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills too long last name")]
        [Obsolete]
        public void GivenUserFillsTooLongLastName()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills incorrect email")]
        [Obsolete]
        public void GivenUserFillsIncorrectEmail()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User fills incorrect password")]
        [Obsolete]
        public void GivenUserFillsIncorrectPassword()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User fills email which is not unique")]
        [Obsolete]
        public void GivenUserFillsNotUniqueEmail()
        {
            string user = "";
            ScenarioContext.Current.Add("user", user);
        }

        [Given(@"User fills login which is not unique")]
        [Obsolete]
        public void GivenUserFillsNotUniqueLogin()
        {
            string user = "";
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
            //restResponse = (RestResponse)restClient.Execute(restRequest);
            //Assert.AreEqual(200, (int)restResponse.StatusCode);

            //ScenarioContext.Current.Add("response", restResponse.Content);
        }

        [Then(@"JSON body without sensitive data")]
        [Obsolete]
        public void ThenJSONBodyWithoutSensitiveData()
        {
            //var responseContent = ScenarioContext.Current["response"].ToString();
            //JObject parseRestResponse = JObject.Parse(responseContent);
            //string jsonHasFieldPassword = (string)parseRestResponse["password"];
            //Assert.AreEqual(null, jsonHasFieldPassword);
        }

        [Then(@"The server should return status 400")]
        [Obsolete]
        public void ThenTheServerShouldReturnStatus_BadRequest()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(400, (int)restResponse.StatusCode);

            ScenarioContext.Current.Add("response", restResponse.Content);
        }

        [Then(@"JSON body with message about missing field Imię")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutMissingFieldImie()
        {
            //var responseContent = ScenarioContext.Current["response"].ToString();
            //JObject parseRestResponse = JObject.Parse(responseContent);
            //string resposneErrorAboutFirstName = (string)parseRestResponse["fields"]["firstName"];
            //Assert.AreNotEqual("Imie jest wymagane", resposneErrorAboutFirstName);
        }
        
        [Then(@"JSON body with message about missing field Nazwisko")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutMissingFieldNazwisko()
        {
            //var responseContent = ScenarioContext.Current["response"].ToString();
            //JObject parseRestResponse = JObject.Parse(responseContent);
            //string resposneErrorAboutLastName = (string)parseRestResponse["fields"]["lastName"];
            //Assert.AreNotEqual("Nazwisko jest wymagane", resposneErrorAboutLastName);
        }
        
        [Then(@"JSON body with message about missing field Adres e-mail")]
        public void ThenJSONBodyWithMessageAboutMissingFieldAdresE_Mail()
        {
            
        }
        
        [Then(@"JSON body with message about missing field Numer telefonu")]
        public void ThenJSONBodyWithMessageAboutMissingFieldNumerTelefonu()
        {
            
        }
        
        [Then(@"JSON body with message about unchecked fields: JavaScript, Java, QA, Mobile")]
        public void ThenJSONBodyWithMessageAboutUncheckedFieldsJavaScriptJavaQAMobile()
        {
            
        }
        
        [Then(@"JSON body with message about too many technology groups checked")]
        public void ThenJSONBodyWithMessageAboutTooManyTechnologyGroupsChecked()
        {
            
        }
        
        [Then(@"JSON body with message about incorrect github link")]
        public void ThenJSONBodyWithMessageAboutIncorrectGithubLink()
        {
            
        }
        
        [Then(@"JSON body with message about missing field Hasło")]
        public void ThenJSONBodyWithMessageAboutMissingFieldHaslo()
        {
            
        }
        
        [Then(@"JSON body with message about missing data")]
        public void ThenJSONBodyWithMessageAboutMissingData()
        {
            
        }
        
        [Then(@"JSON body with message about incorrect phone number")]
        public void ThenJSONBodyWithMessageAboutIncorrectPhoneNumber()
        {
            
        }
        
        [Then(@"JSON body with message about incorrect first name")]
        public void ThenJSONBodyWithMessageAboutIncorrectFirstName()
        {
            
        }
        
        [Then(@"JSON body with message about incorrect last name")]
        public void ThenJSONBodyWithMessageAboutIncorrectLastName()
        {
            
        }
        
        [Then(@"JSON body with message about incorrect email")]
        public void ThenJSONBodyWithMessageAboutIncorrectEmail()
        {
            
        }
        
        [Then(@"JSON body with message about incorrect password")]
        public void ThenJSONBodyWithMessageAboutIncorrectPassword()
        {
            
        }

        [Then(@"JSON body with message about incorrect login")]
        public void ThenJSONBodyWithMessageAboutIncorrectLogin()
        {
            
        }

        [Then(@"JSON body with message about incorrect title")]
        [Obsolete]
        public void ThenJSONBodyWithMessageAboutIncorrectTitle()
        {
            var responseContent = ScenarioContext.Current["response"].ToString();
            JObject parseRestResponse = JObject.Parse(responseContent);
            var resposneErrorAboutFirstName = parseRestResponse["fields"]["title"][0];
            Assert.AreNotEqual("{Niedozwolona wartość}", resposneErrorAboutFirstName);
        }
    }
}
