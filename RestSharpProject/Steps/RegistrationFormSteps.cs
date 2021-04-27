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
    public class RegistrationFormSteps
    {
        RestClient restClient = new RestClient();
        RestRequest restRequest = new RestRequest("http://127.0.0.1:8080/api/register", Method.POST);
        RestResponse restResponse;
        User user;
        UserModel userModel;
        Response responseMessage;

        string email = User.GenerateEmailAdress();
        string login = User.GenerateLogin();
        string githubLink = User.GenerateGithubLink();

        Nullable<int> phoneNumber = 123456789;
        int tooLongPhoneNumber = 1234567890;
        int tooShortPhoneNumber = 123;
        string password = "randomPassword@";
        string incorrectEmail = "wrongEmail";
        string incorrectPassword = "wrongpassword";
        string incorrectGithubLink = "wrongLink";
        string tooShortLogin = "l";
        string tooLongLogin = "zaDlugiLoginUzytkownika";

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

        [Given(@"User filled required data with checking all technology groups")]
        public void GivenUserFilledRequiredDataWithCheckingAllTechnologyGroups()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");
            technologies.Add("JS");
            technologies.Add("Java");
            technologies.Add("Mobile");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled required data with checking one field about technology groups")]
        public void GivenUserFilledRequiredDataWithCheckingOneFieldAboutTechnologyGroups()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User didn't fill data")]
        public void GivenUserDidnTFillData()
        {
            List<string> technologies = new List<string>();

            user = new User("", "", "", null, technologies, "", "", "");
        }

        [Given(@"User filled request to API with too long Imię")]
        public void GivenUserFilledRequestToAPIWithTooLongImie()
        {
            List<string> technologies = new List<string>();
            technologies.Add("JS");

            user = new User("NiepoprawnieBardzoDługieImię", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled request to API with too long Nazwisko")]
        public void GivenUserFilledRequestToAPIWithTooLongNazwisko()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");

            user = new User("Jan", "NiepoprawnieBardzoDługieNazwisko", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled request to API with too long Numer telefonu")]
        public void GivenUserFilledRequestToAPIWithTooLongNumerTelefonu()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");

            user = new User("Jan", "Kowalski", email, tooLongPhoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled request to API with too long Login")]
        public void GivenUserFilledRequestToAPIWithTooLongLogin()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, tooLongLogin, githubLink);
        }

        [Given(@"User filled request to API with too short Imię")]
        public void GivenUserFilledRequestToAPIWithTooShortImie()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Java");

            user = new User("J", "Kowalski", email, tooLongPhoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled request to API with too short Nazwisko")]
        public void GivenUserFilledRequestToAPIWithTooShortNazwisko()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");

            user = new User("Jan", "K", email, tooLongPhoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled request to API with too short Numer telefonu")]
        public void GivenUserFilledRequestToAPIWithTooShortNumerTelefonu()
        {
            List<string> technologies = new List<string>();
            technologies.Add("JS");

            user = new User("Jan", "Kowalski", email, tooShortPhoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User filled request to API with too short Login")]
        public void GivenUserFilledRequestToAPIWithTooShortLogin()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, tooShortLogin, githubLink);
        }

        [Given(@"User fills incorrect Adres email")]
        public void GivenUserFillsIncorrectAdresEmail()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Java");

            user = new User("Jan", "Kowalski", incorrectEmail, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User fills incorrect Hasło")]
        public void GivenUserFillsIncorrectHaslo()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, incorrectPassword, login, githubLink);
        }

        [Given(@"User fills incorrect Github link")]
        public void GivenUserFillsIncorrectGithubLink()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, incorrectGithubLink);
        }

        [Given(@"Creates user account")]
        public void GivenCreatesDefaultUserAccount()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);

            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);
            restResponse = (RestResponse)restClient.Execute(restRequest);
        }

        [Given(@"User fills email which is not unique")]
        public void GivenUserFillsEmailWhichIsNotUnique()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [Given(@"User fills login which is not unique")]
        public void GivenUserFillsLoginWhichIsNotUnique()
        {
            List<string> technologies = new List<string>();
            technologies.Add("JS");

            user = new User("Jan", "Kowalski", email, phoneNumber, technologies, password, login, githubLink);
        }

        [When(@"Request sends to API")]
        public void WhenUserInterfaceSendsTheRequestToAPI()
        {
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);
        }

        [Then(@"The server should return positive status 200")]
        public void ThenTheServerShouldReturnPositiveStatus()
        {
            restResponse = (RestResponse)restClient.Execute(restRequest);
            Assert.AreEqual(200, (int)restResponse.StatusCode);
        }

        [Then(@"JSON body without sensitive data")]
        public void ThenJSONBodyWithoutSensitiveData()
        {
            userModel = JsonConvert.DeserializeObject<UserModel>(restResponse.Content);
            Assert.That(userModel.password, Is.EqualTo(null));
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
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.firstName[0], Is.EqualTo("Imię musi mieć co najmniej 3 znaki"));
        }

        [Then(@"JSON body with message about empty field Nazwisko")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNazwisko()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.lastName[0], Is.EqualTo("Nazwisko musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with message about empty field Adres email")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldAdresEmail()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.email[0], Is.EqualTo("Niepoprawny email"));
        }

        [Then(@"JSON body with message about empty field Numer telefonu")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerTelefonu()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.phone[0], Is.EqualTo("Numer powinien składać się wyłącznie z cyfr"));
        }

        [Then(@"JSON body with message about empty field Technologie")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerTechnologie()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.technologies[0], Is.EqualTo("Proszę wybrać conajmniej jedną technologię"));
        }

        [Then(@"JSON body with message about empty field Hasło")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerHaslo()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.password[0], Is.EqualTo("Hasło musi składać się z co najmniej ośmiu znaków"));
        }

        [Then(@"JSON body with message about empty field Login")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with message about empty field Github link")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerGithubLink()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.githubLink[0], Is.EqualTo("Niepoprawny link"));
        }

        [Then(@"JSON body with message about too many technology groups checked")]
        public void ThenJSONBodyWithMessageAboutTooManyTechnologyGroupsChecked()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.technologies[0], Is.EqualTo("Proszę wybrać maksymanie trzy technologie"));
        }

        [Then(@"JSON body with message about missing data")]
        public void ThenJSONBodyWithMessageAboutMissingData()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields, Is.Not.Null);
        }

        [Then(@"JSON body with error message about too long Imię")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongImie()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.firstName[0], Is.EqualTo("Imię jest za długie"));
        }

        [Then(@"JSON body with error message about too long Nazwisko")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongNazwisko()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.lastName[0], Is.EqualTo("Nazwisko jest za długie"));
        }

        [Then(@"JSON body with error message about too long Numer telefonu")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongNumerTelefonu()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.phone[0], Is.EqualTo("Numer jest za długi"));
        }

        [Then(@"JSON body with error message about too long Login")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login musi mieć mniej niż 15 znaków"));
        }

        [Then(@"JSON body with error message about too short Imię")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortImie()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.firstName[0], Is.EqualTo("Imię musi mieć co najmniej 3 znaki"));
        }

        [Then(@"JSON body with error message about too short Nazwisko")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortNazwisko()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.lastName[0], Is.EqualTo("Nazwisko musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with error message about too short Numer telefonu")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortNumerTelefonu()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.phone[0], Is.EqualTo("Numer jest za krótki"));
        }

        [Then(@"JSON body with error message about too short Login")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with message about incorrect Adres email")]
        public void ThenJSONBodyWithMessageAboutIncorrectAdresEmail()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.email[0], Is.EqualTo("Niepoprawny email"));
        }

        [Then(@"JSON body with message about incorrect Hasło")]
        public void ThenJSONBodyWithMessageAboutIncorrectHaslo()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.password[0], Is.EqualTo("Hasło musi mieć przynajmniej jedną dużą literę i jeden znak specjalny"));
        }

        [Then(@"JSON body with message about incorrect Github link")]
        public void ThenJSONBodyWithMessageAboutIncorrectGithubLink()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.githubLink[0], Is.EqualTo("Niepoprawny link"));
        }

        [Then(@"JSON body with message about not unique email")]
        public void ThenJSONBodyWithMessageAboutNotUniqueEmail()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.email[0], Is.EqualTo("Email jest już zajęty"));
        }

        [Then(@"JSON body with message about not unique login")]
        public void ThenJSONBodyWithMessageAboutNotUniqueLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login jest już zajęty"));
        }
    }
}
