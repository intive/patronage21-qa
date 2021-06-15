using System;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using patronage21_qa_appium.Models;
using patronage21_qa_appium.Screens;
using RestSharp;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "EDIT_PROFILE_SCREEN Data From Api")]
    public class EditUserScreenDataFromApiSteps
    {
        private string _url;
        private RestClient _client;
        private RestRequest _requestGet;
        private GetUserResponse _response;
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly JavaDatabase _javaDatabase = new();

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly UsersScreen _usersScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();

        public EditUserScreenDataFromApiSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _url = "https://64z31.mocklab.io";
            _client = new RestClient(_url);
            _requestGet = new RestRequest("/api/users/kowalski87", Method.GET);
            _response = JsonConvert.DeserializeObject<GetUserResponse>(_client.Execute(_requestGet).Content);
        }

        [BeforeScenario]
        public void Setup()
        {
            _driver.LaunchApp();
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string screenName)
        {
            switch (screenName)
            {
                case "Edycja użytkownika":
                    _loginScreen.ClickElement(_driver, "Rejestracja");
                    _registerScreen.Wait(_driver);
                    _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "Kowalski", "test@email.com", "123456789",
                        true, false, false, false, "Username", "Deactivate11!", "Deactivate11!", "", true, true, true);
                    string code = "99999999";
                    _activationScreen.Wait(_driver);
                    _activationScreen.WriteTextToField(_driver, code, "Kod");
                    _activationScreen.ClickElement(_driver, "Zatwierdź kod");
                    _activationScreen.Wait(_driver);
                    _registerSubmitScreen.ClickElement(_driver, "Zamknij");
                    _homeScreen.Wait(_driver);
                    _homeScreen.ClickElement(_driver, "Użytkownicy");
                    _usersScreen.Wait(_driver);
                    _usersScreen.ClickElement(_driver, "Liderzy lista bez widocznych uczestników");
                    _userDetailsScreen.SearchForElement(_driver, "Edytuj profil").Click();
                    break;
            }
        }
        
        [Then(@"User sees correct user data")]
        public void ThenUserSeesCorrectUserData()
        {
            Assert.AreEqual(BaseScreen.GetElementFromScreen(_driver, "Imię", "Edycja użytkownika").Text, _response.user.firstName);
            Assert.AreEqual(BaseScreen.GetElementFromScreen(_driver, "Nazwisko", "Edycja użytkownika").Text, _response.user.lastName);
            Assert.AreEqual(BaseScreen.GetElementFromScreen(_driver, "Email", "Edycja użytkownika").Text, _response.user.email);
            Assert.AreEqual(BaseScreen.GetElementFromScreen(_driver, "Numer telefonu", "Edycja użytkownika").Text, _response.user.phoneNumber);
            Assert.AreEqual(BaseScreen.GetElementFromScreen(_driver, "Github", "Edycja użytkownika").Text, _response.user.gitHubUrl);
            Assert.AreEqual(BaseScreen.GetElementFromScreen(_driver, "Bio", "Edycja użytkownika").Text, _response.user.bio);
        }
    }
}
