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

        [Given(@"Set the Endpoint with method POST")]
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

            user = new UserData("man", "Jan", "Kowalski", email, "123456789", "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled all data")]
        [Obsolete]
        public void GivenUserFilledAllData()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";

            user = new UserData("man", "Jan", "Kowalski", email, "123456789", "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data but without field Imię")]
        [Obsolete]
        public void GivenUserFilledRequiredDataButWithoutFieldImie()
        {
            rand = new Random();

            string email = $"example{rand.Next(0, 10000)}@email.com";

            user = new UserData("man", null, "Kowalski", email, "123456789", "randomPassword@");
            ScenarioContext.Current.Add("user", user);
        }
        
        [Given(@"User filled required data but without field Nazwisko")]
        public void GivenUserFilledRequiredDataButWithoutFieldNazwisko()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data but without field Adres e-mail")]
        public void GivenUserFilledRequiredDataButWithoutFieldAdresE_Mail()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data but without field Numer telefonu")]
        public void GivenUserFilledRequiredDataButWithoutField()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data without checked fields: JavaScript, Java, QA, Mobile")]
        public void GivenUserFilledRequiredDataWithoutCheckedFieldsJavaScriptJavaQAMobile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data with checking all about technology groups")]
        public void GivenUserFilledRequiredDataWithCheckingAllAboutTechnologyGroups()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data with checking one field about technology groups")]
        public void GivenUserFilledRequiredDataWithCheckingOneFieldAboutTechnologyGroups()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data with checking three fields from Technologie")]
        public void GivenUserFilledRequiredDataWithCheckingThreeFieldsFromTechnologie()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data without fields: Hasło and Powtórz hasło")]
        public void GivenUserFilledRequiredDataWithoutFieldsHasloAndPowtorzHaslo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data without field Powtórz hasło")]
        public void GivenUserFilledRequiredDataWithoutFieldPowtorzHaslo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data without field Hasło")]
        public void GivenUserFilledRequiredDataWithoutField()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled required data without field Zgoda obowiązkowa")]
        public void GivenUserFilledRequiredDataWithoutFieldZgodaObowiazkowa()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"User filled request to API without data")]
        public void GivenUserFilledRequestToAPIWithoutData()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User interface sends the request to API")]
        [Obsolete]
        public void WhenUserInterfaceSendsTheRequestToAPI()
        {
            var body = ScenarioContext.Current["user"];
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(body);
        }
        
        [Then(@"The server should return status 200 with empty JSON body")]
        public void ThenTheServerShouldReturnStatusWithEmptyJSONBody()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
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
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Adres e-mail")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldAdresE_Mail()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Numer telefonu")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldNumerTelefonu()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about unchecked fields: JavaScript, Java, QA, Mobile")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutUncheckedFieldsJavaScriptJavaQAMobile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about too many technology groups checked")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutTooManyTechnologyGroupsChecked()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should execute request and return status 200 and empty JSON body")]
        public void ThenTheServerShouldExecuteRequestAndReturnStatusAndEmptyJSONBody()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing fields: Hasło and Powtórz hasło")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldsHasloAndPowtorzHaslo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Powtórz hasło")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldPowtorzHaslo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing field Hasło")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingFieldHaslo()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about unmarked field Zgoda obowiązkowa")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutUnmarkedFieldZgodaObowiazkowa()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The server should return status 400 and JSON body with message about missing data")]
        public void ThenTheServerShouldReturnStatusAndJSONBodyWithMessageAboutMissingData()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
