using System;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Models;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
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
        private static JavaApi _javaApi = new();
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly Topbar _topbar= new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();

        public EditUserScreenDataFromApiSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _url = "http://intive-patronage.pl";
            _client = new RestClient(_url);
            _requestGet = new RestRequest("/api/users/" + _testKey, Method.GET);
        }

        [BeforeScenario]
        public void Setup()
        {
            _driver.LaunchApp();
        }

        [AfterScenario]
        public void TearDown()
        {
            _javaApi.DeactivateUsersByLogin(_testKey);
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string screenName)
        {
            switch (screenName)
            {
                case "Edycja użytkownika":
                    _loginScreen.ClickElement(_driver, "Rejestracja");
                    _registerScreen.Wait(_driver);
                    _registerScreen.SubmitRegisterForm(_driver, _testKey, "Pan", "test", "[unique]", "[unique]@ema.il", "123456789",
                        true, false, false, false, "[unique]", "Deactivate11!", "Deactivate11!", "https://www.github.com/[unique]", true, true, true);
                    string code = "99999999";
                    _activationScreen.Wait(_driver);
                    _activationScreen.WriteTextToField(_driver, code, "Kod");
                    _activationScreen.ClickElement(_driver, "Zatwierdź kod");
                    _activationScreen.Wait(_driver);
                    _registerSubmitScreen.ClickElement(_driver, "Zamknij");
                    _topbar.ClickElement(_driver, "Moje konto");
                    BaseScreen.SwipeToBottom(_driver);
                    _userDetailsScreen.ClickElement(_driver, "Edytuj profil");
                    break;
            }
        }

        [Then(@"User sees correct user data")]
        public void ThenUserSeesCorrectUserData()
        {
            _response = JsonConvert.DeserializeObject<GetUserResponse>(_client.Execute(_requestGet).Content);
            Assert.AreEqual(_response.user.firstName, BaseScreen.GetElementFromScreen(_driver, "Imię", "Edycja użytkownika").Text);
            Assert.AreEqual(_response.user.lastName, BaseScreen.GetElementFromScreen(_driver, "Nazwisko", "Edycja użytkownika").Text);
            Assert.AreEqual(_response.user.email, BaseScreen.GetElementFromScreen(_driver, "Email", "Edycja użytkownika").Text);
            Assert.AreEqual(_response.user.phoneNumber, BaseScreen.GetElementFromScreen(_driver, "Numer telefonu", "Edycja użytkownika").Text);
            Assert.AreEqual(_response.user.gitHubUrl, BaseScreen.GetElementFromScreen(_driver, "Github", "Edycja użytkownika").Text);
            if (_response.user.bio == null)
            {
                Assert.AreEqual("Bio", BaseScreen.GetElementFromScreen(_driver, "Bio", "Edycja użytkownika").Text);
            }
            else
            {
                Assert.AreEqual(_response.user.bio, BaseScreen.GetElementFromScreen(_driver, "Bio", "Edycja użytkownika").Text);
            }
        }
    }
}