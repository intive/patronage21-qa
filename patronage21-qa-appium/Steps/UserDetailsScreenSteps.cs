using System;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Models;
using patronage21_qa_appium.Screens;
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

        private LoginScreen _loginScreen = new();
        private RegisterScreen _registerScreen = new();
        private ActivationScreen _activationScreen = new();
        private RegisterSubmitScreen _registerSubmitScreen = new();
        private HomeScreen _homeScreen = new();
        private UsersScreen _usersScreen = new();
        private UserDetailsScreen _userDetailsScreen = new();

        private readonly AppiumDriver<AndroidElement> _driver;

        public UserDetailsScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _url = "http://www.intive-patronage.pl";
            _client = new RestClient(_url);
            _requestGet = new RestRequest("/api/groups", Method.GET);
            _response = JsonConvert.DeserializeObject<TechGroupsResponse>(_client.Execute(_requestGet).Content);
            _groups = _response.groups;
        }

        [Given(@"User registers as ""(.*)""")]
        public void GivenUserRegistersAs(string username)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "Nazwisko", "test@email.com", "123456789",
                true, false, false, false, username, "TechGroups1!", "TechGroups1!", "", true, true, true);
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

        [When(@"User clicks ""(.*)"" on ""(.*)"" screen")]
        public void WhenUserClicksOnScreen(string element, string screen)
        {
            switch (screen)
            {
                case "Home":
                    _homeScreen.ClickElement(_driver, element);
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
            // To be changed, for now app is working in admin mode for everyone, in future
            // those elements will be split into owned ("Edytuj profil" and
            // "Dezaktywuj profil" visible) and not owned ("Wyślij wiadomość", "Zadzwoń",
            // "Otwórz link" visible), when it happens code should be replaced
            // by commented code
            /*
            BaseScreen.SwipeToBottom(_driver);
            switch(profile)
            {
                case "owned":
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Edytuj profil"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Dezaktywuj profil"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Kontakt nagłówek"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Wyślij wiadomość"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Zadzwoń"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Otwórz link"));
                    break;

                case "not owned":
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Edytuj profil"));
                    Assert.IsEmpty(_userDetailsScreen.GetElements(_driver, "Dezaktywuj profil"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Kontakt nagłówek"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Wyślij wiadomość"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Zadzwoń"));
                    Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Otwórz link"));
                    break;
            }
            */
            BaseScreen.SwipeToBottom(_driver);
            Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Edytuj profil"));
            Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Dezaktywuj profil"));
            Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Kontakt nagłówek"));
            Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Wyślij wiadomość"));
            Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Zadzwoń"));
            Assert.IsNotEmpty(_userDetailsScreen.GetElements(_driver, "Otwórz link"));
        }
    }
}