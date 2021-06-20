using System;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using patronage21_qa_appium.Models;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
using RestSharp;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "USER_DETAILS_SCREEN")]
    public class UserDetailsScreenSteps
    {
        private string _url;
        private RestClient _client;
        private RestRequest _requestGet;
        private TechGroupsResponse _response;
        private readonly AppiumDriver<AndroidElement> _driver;
        private static JavaApi _javaApi = new();
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private Topbar _topbar = new();
        private LoginScreen _loginScreen = new();
        private RegisterScreen _registerScreen = new();
        private ActivationScreen _activationScreen = new();
        private RegisterSubmitScreen _registerSubmitScreen = new();
        private HomeScreen _homeScreen = new();
        private UsersScreen _usersScreen = new();
        private UserDetailsScreen _userDetailsScreen = new();
        private JavaDatabase _javaDatabase = new();

        public UserDetailsScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _url = "http://www.intive-patronage.pl";
            _client = new RestClient(_url);
            _requestGet = new RestRequest("/api/groups", Method.GET);
            _response = JsonConvert.DeserializeObject<TechGroupsResponse>(_client.Execute(_requestGet).Content);
        }

        [AfterScenario]
        public void TearDown()
        {
            _javaApi.DeactivateUsersByLogin(_testKey);
        }

        [Given(@"User registers as ""(.*)""")]
        public void GivenUserRegistersAs(string username)
        {
            username = username.Replace("[empty]", _testKey);
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, _testKey, "Pan", "test", "[unique]", "[unique]@ema.il", "123456789",
                true, false, false, false, username, "Deactivate11!", "Deactivate11!", "https://www.github.com/[unique]", true, true, true);
            _activationScreen.Wait(_driver);
            // to be changed, there is no code table in database yet
            // string code = _javaDatabase.GetProperty("code", "patronative.code_user", "user", username);
            string code = "99999999";
            _activationScreen.WriteTextToField(_driver, code, "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _registerSubmitScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
            _homeScreen.Wait(_driver);
        }

        [When(@"User navigates to ""(.*)"" profile")]
        public void WhenUserNavigatesToProfile(string profile)
        {
            switch (profile)
            {
                case "not owned":
                    _homeScreen.ClickElement(_driver, "Użytkownicy");
                    _usersScreen.ClickElement(_driver, "Liderzy lista bez widocznych uczestników");
                    break;

                case "owned":
                    _topbar.ClickElement(_driver, "Moje konto");
                    break;
            }
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string element)
        {
            _userDetailsScreen.FindElementByText(_driver, element).Click();
        }

        [When(@"User selects ""(.*)"" from ""(.*)"" list")]
        public void WhenUserSelectsFromList(string username, string listName)
        {
            // To be changed, there are only mocked users in lists for now
            _usersScreen.Wait(_driver);
            _usersScreen.ClickElement(_driver, "Liderzy lista bez widocznych uczestników");
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string button)
        {
            switch (button)
            {
                case "Back":
                    _driver.Navigate().Back();
                    break;
            }
        }

        [Then(@"User sees ""(.*)"" screen")]
        public void ThenUserSeesScreen(string screenName)
        {
            switch (screenName)
            {
                case "Szczegóły użytkownika":
                    BaseScreen.GetElementsFromScreen(_driver, "Zdjęcie", screenName);
                    BaseScreen.GetElementsFromScreen(_driver, "Nazwa użytkownika", screenName);
                    break;
            }
        }

        [Then(@"""(.*)"" screen is displayed correctly for ""(.*)"" profile")]
        public void ThenScreenIsDisplayedCorrectlyForProfile(string screenName, string profile)
        {
            BaseScreen.SwipeToBottom(_driver);
            switch(profile)
            {
                case "owned":
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Edytuj profil"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Dezaktywuj profil"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Wyślij wiadomość"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Zadzwoń"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Otwórz link"));
                    break;

                case "not owned":
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Edytuj profil"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Dezaktywuj profil"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Wyślij wiadomość"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Zadzwoń"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Otwórz link"));
                    break;
            }
        }
    }
}