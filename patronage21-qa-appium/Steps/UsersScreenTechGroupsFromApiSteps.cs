using System;
using System.Collections.Generic;
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
    [Scope(Feature = "USERS_SCREEN Tech Groups From Api")]
    public class UsersScreenTechGroupsFromApiSteps
    {
        private string _url;
        private RestClient _client;
        private RestRequest _requestGet;
        private TechGroupsResponse _response;
        private List<string> _groups;

        private LoginScreen _loginScreen = new();
        private RegisterScreen _registerScreen = new();
        private ActivationScreen _activationScreen = new();
        private RegisterSubmitScreen _registerSubmitScreen = new();
        private HomeScreen _homeScreen = new();
        private UsersScreen _usersScreen = new();

        private readonly AppiumDriver<AndroidElement> _driver;

        public UsersScreenTechGroupsFromApiSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _url = "http://www.intive-patronage.pl";
            _client = new RestClient(_url);
            _requestGet = new RestRequest("/api/groups", Method.GET);
            _response = JsonConvert.DeserializeObject<TechGroupsResponse>(_client.Execute(_requestGet).Content);
            _groups = _response.groups;
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string screenName)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "Nazwisko", "test@email.com", "123456789",
                true, false, false, false, "Login", "TechGroups1!", "TechGroups1!", "", true, true, true);
            _activationScreen.Wait(_driver);
            // to be changed, there is no code table in database yet
            // string code = _javaDatabase.GetProperty("code", "patronative.code_user", "user", p0);
            string code = "99999999";
            _activationScreen.WriteTextToField(_driver, code, "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _registerSubmitScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
            _homeScreen.Wait(_driver);
            _homeScreen.ClickElement(_driver, screenName);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string p0)
        {
            _usersScreen.ClickElement(_driver, "Wybierz grupę");
        }

        [Then(@"User sees correct tech groups")]
        public void ThenUserSeesCorrectTechGroups()
        {
            var displayedGroups = _usersScreen.GetElements(_driver, "Grupy");
            for (var i = 0; i < _groups.Count; i++)
            {
                Assert.AreEqual(1, _usersScreen.GetElements(_driver, _groups[i]).Count);
            }
            Assert.AreEqual(_groups.Count, displayedGroups.Count);
        }
    }
}