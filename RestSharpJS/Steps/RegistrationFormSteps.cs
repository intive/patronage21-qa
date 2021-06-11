using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharpProject.Models;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace RestSharpProject.Steps
{
    [Binding]
    public class RegistrationFormSteps
    {
        private RestClient _restClient;
        private RestRequest _restRequest;
        private RestResponse _restResponse;
        private User user;
        private UserModel userModel;
        private Response responseMessage;
        private string signUpUrl = "/register";

        public RegistrationFormSteps(RestClient restClient)
        {
            _restClient = new RestClient(restClient.BaseUrl + signUpUrl);
            _restRequest = new RestRequest(Method.POST);
        }

        [Given(@"User filled data correctly")]
        public void GivenUserFilledJanKowalskiExampleEmail_ComQARandomPasswordRandomLoginGithub_ComExampleCorrectly()
        {
            user = new User(null, null, null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled all data")]
        public void GivenUserFilledAllData()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");
            technologies.Add("JS");
            technologies.Add("Java");
            user = new User(null, null, null, null, technologies, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Imię")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldImie()
        {
            user = new User("", null, null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Nazwisko")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldNazwisko()
        {
            user = new User(null, "", null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Adres email")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldAdresEmail()
        {
            user = new User(null, null, "", null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Numer telefonu")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldNumerTelefonu()
        {
            user = new User(null, null, null, 0, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Technologie")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldTechnologie()
        {
            List<string> technologies = new List<string>();
            user = new User(null, null, null, null, technologies, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Hasło")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldHaslo()
        {
            user = new User(null, null, null, null, null, "", null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Login")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldLogin()
        {
            user = new User(null, null, null, null, null, null, "", null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data but without data in field Github link")]
        public void GivenUserFilledRequiredDataButWithoutDataInFieldGithubLink()
        {
            user = new User(null, null, null, null, null, null, null, "");
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data with checking all technology groups")]
        public void GivenUserFilledRequiredDataWithCheckingAllTechnologyGroups()
        {
            List<string> technologies = new List<string>();
            technologies.Add("QA");
            technologies.Add("JS");
            technologies.Add("Java");
            technologies.Add("Mobile");
            user = new User(null, null, null, null, technologies, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled required data with checking one field about technology groups")]
        public void GivenUserFilledRequiredDataWithCheckingOneFieldAboutTechnologyGroups()
        {
            List<string> technologies = new List<string>();
            technologies.Add("Mobile");
            user = new User(null, null, null, null, technologies, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User didn't fill data")]
        public void GivenUserDidnTFillData()
        {
            List<string> technologies = new List<string>();
            user = new User("", "", "", 0, technologies, "", "", "");
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too long Imię")]
        public void GivenUserFilledRequestToAPIWithTooLongImie()
        {
            user = new User("userEnteredTooLongUserFirstName", null, null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too long Nazwisko")]
        public void GivenUserFilledRequestToAPIWithTooLongNazwisko()
        {
            user = new User(null, "userEnteredTooLongUserLastNamee", null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too long Numer telefonu")]
        public void GivenUserFilledRequestToAPIWithTooLongNumerTelefonu()
        {
            user = new User(null, null, null, 1234567890, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too long Login")]
        public void GivenUserFilledRequestToAPIWithTooLongLogin()
        {
            user = new User(null, null, null, null, null, null, "tooLongExampleLogin", null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too short Imię")]
        public void GivenUserFilledRequestToAPIWithTooShortImie()
        {
            user = new User("J", null, null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too short Nazwisko")]
        public void GivenUserFilledRequestToAPIWithTooShortNazwisko()
        {
            user = new User(null, "K", null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too short Numer telefonu")]
        public void GivenUserFilledRequestToAPIWithTooShortNumerTelefonu()
        {
            user = new User(null, null, null, 12345678, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User filled request to API with too short Login")]
        public void GivenUserFilledRequestToAPIWithTooShortLogin()
        {
            user = new User(null, null, null, null, null, null, "L", null);
            user = user.CreateUser(user);
        }

        [Given(@"User fills incorrect Adres email")]
        public void GivenUserFillsIncorrectAdresEmail()
        {
            user = new User(null, null, "incorrectEmail.com", null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User fills incorrect Hasło")]
        public void GivenUserFillsIncorrectHaslo()
        {
            user = new User(null, null, null, null, null, "password", null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User fills incorrect Github link")]
        public void GivenUserFillsIncorrectGithubLink()
        {
            user = new User(null, null, null, null, null, null, null, "wrongLink");
            user = user.CreateUser(user);
        }

        [Given(@"Creates user account")]
        public void GivenCreatesDefaultUserAccount()
        {
            user = new User(null, null, null, null, null, null, null, null);
            user = user.CreateUser(user);

            _restRequest.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);
            _restResponse = (RestResponse)_restClient.Execute(_restRequest);
        }

        [Given(@"User fills email which is not unique")]
        public void GivenUserFillsEmailWhichIsNotUnique()
        {
            user = new User(null, null, null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [Given(@"User fills login which is not unique")]
        public void GivenUserFillsLoginWhichIsNotUnique()
        {
            user = new User(null, null, null, null, null, null, null, null);
            user = user.CreateUser(user);
        }

        [When(@"Request sends to API")]
        public void WhenUserInterfaceSendsTheRequestToAPI()
        {
            _restRequest.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);
        }

        [Then(@"The server should return positive status 200")]
        public void ThenTheServerShouldReturnPositiveStatus()
        {
            _restResponse = (RestResponse)_restClient.Execute(_restRequest);
            Assert.AreEqual(200, (int)_restResponse.StatusCode);
        }

        [Then(@"JSON body without sensitive data")]
        public void ThenJSONBodyWithoutSensitiveData()
        {
            userModel = JsonConvert.DeserializeObject<UserModel>(_restResponse.Content);
            Assert.That(userModel.password, Is.EqualTo(null));
        }

        [Then(@"The server should return status 400")]
        public void ThenTheServerShouldReturnStatus()
        {
            _restResponse = (RestResponse)_restClient.Execute(_restRequest);
            Assert.AreEqual(400, (int)_restResponse.StatusCode);
        }

        [Then(@"JSON body with message about empty field Imię")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldImie()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.firstName[0], Is.EqualTo("Imię musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with message about empty field Nazwisko")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNazwisko()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.lastName[0], Is.EqualTo("Nazwisko musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with message about empty field Adres email")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldAdresEmail()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.email[0], Is.EqualTo("Niepoprawny email"));
        }

        [Then(@"JSON body with message about empty field Numer telefonu")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerTelefonu()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.phone[0], Is.EqualTo("Numer jest za krótki"));
        }

        [Then(@"JSON body with message about empty field Technologie")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerTechnologie()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.technologies[0], Is.EqualTo("Proszę wybrać conajmniej jedną technologię"));
        }

        [Then(@"JSON body with message about empty field Hasło")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerHaslo()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.password[0], Is.EqualTo("Hasło musi składać się z co najmniej ośmiu znaków"));
        }

        [Then(@"JSON body with message about empty field Login")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login musi składać się z co najmniej 2 znaków"));
        }

        [Then(@"JSON body with message about empty field Github link")]
        public void ThenJSONBodyWithMessageAboutEmptyFieldNumerGithubLink()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.githubLink[0], Is.EqualTo("Niepoprawny link"));
        }

        [Then(@"JSON body with message about too many technology groups checked")]
        public void ThenJSONBodyWithMessageAboutTooManyTechnologyGroupsChecked()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.technologies[0], Is.EqualTo("Proszę wybrać maksymanie trzy technologie"));
        }

        [Then(@"JSON body with message about missing data")]
        public void ThenJSONBodyWithMessageAboutMissingData()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields, Is.Not.Null);
        }

        [Then(@"JSON body with error message about too long Imię")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongImie()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.firstName[0], Is.EqualTo("Imię jest za długie"));
        }

        [Then(@"JSON body with error message about too long Nazwisko")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongNazwisko()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.lastName[0], Is.EqualTo("Nazwisko jest za długie"));
        }

        [Then(@"JSON body with error message about too long Numer telefonu")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongNumerTelefonu()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.phone[0], Is.EqualTo("Numer jest za długi"));
        }

        [Then(@"JSON body with error message about too long Login")]
        public void ThenJSONBodyWithErrorMessageAboutTooLongLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login może składać się z maksymalnie 15 znaków"));
        }

        [Then(@"JSON body with error message about too short Imię")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortImie()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.firstName[0], Is.EqualTo("Imię musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with error message about too short Nazwisko")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortNazwisko()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.lastName[0], Is.EqualTo("Nazwisko musi mieć co najmniej 2 znaki"));
        }

        [Then(@"JSON body with error message about too short Numer telefonu")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortNumerTelefonu()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.phone[0], Is.EqualTo("Numer jest za krótki"));
        }

        [Then(@"JSON body with error message about too short Login")]
        public void ThenJSONBodyWithErrorMessageAboutTooShortLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login musi składać się z co najmniej 2 znaków"));
        }

        [Then(@"JSON body with message about incorrect Adres email")]
        public void ThenJSONBodyWithMessageAboutIncorrectAdresEmail()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.email[0], Is.EqualTo("Niepoprawny email"));
        }

        [Then(@"JSON body with message about incorrect Hasło")]
        public void ThenJSONBodyWithMessageAboutIncorrectHaslo()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.password[0], Is.EqualTo("Hasło musi zawierać przynajmniej jedną dużą literę, jedną małą literę, jedną cyfrę i jeden znak specjalny"));
        }

        [Then(@"JSON body with message about incorrect Github link")]
        public void ThenJSONBodyWithMessageAboutIncorrectGithubLink()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.githubLink[0], Is.EqualTo("Niepoprawny link"));
        }

        [Then(@"JSON body with message about not unique email")]
        public void ThenJSONBodyWithMessageAboutNotUniqueEmail()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.email[0], Is.EqualTo("Email jest już zajęty"));
        }

        [Then(@"JSON body with message about not unique login")]
        public void ThenJSONBodyWithMessageAboutNotUniqueLogin()
        {
            responseMessage = JsonConvert.DeserializeObject<Response>(_restResponse.Content);
            Assert.That(responseMessage.fields.login[0], Is.EqualTo("Login jest już zajęty"));
        }
    }
}