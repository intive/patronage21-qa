using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using RestSharp;
using TechTalk.SpecFlow;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Drivers;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "UsersScreenTechGroupsFromApi")]
    public class UsersScreenTechGroupsFromApiSteps
    {
        private string _url;
        private RestClient _client;
        private RestRequest _requestGet;
        private List<string> _groups;

        private LoginScreen _loginScreen;
        private RegisterScreen _registerScreen;
        private ActivationScreen _activationScreen;
        private RegisterSubmitScreen _registerSubmitScreen;
        private HomeScreen _homeScreen;
        private UsersScreen _usersScreen;
        private JavaDatabase _javaDatabase;

        private readonly AppiumDriver<AndroidElement> _driver;

        public UsersScreenTechGroupsFromApiSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _url = "http://64z31.mocklab.io";
            _client = new RestClient(_url);
            _requestGet = new RestRequest("/api/groups/technologies", Method.GET);
            _groups = JsonConvert.DeserializeObject<List<string>>(_client.Execute(_requestGet).Content);
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string p0)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "Nazwisko", "test@email.com", "123456789",
                true, false, false, false, p0, "TechGroups1!", "TechGroups1!", "", true, true, true);
            _activationScreen.Wait(_driver);
            // to be changed, there is no code table in database yet
            // string code = _javaDatabase.GetProperty("code", "patronative.code_user", "user", p0);
            string code = "99999999";
            _activationScreen.WriteTextToField(_driver, code, "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _registerSubmitScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
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
                var element = _usersScreen.GetElements(_driver, _groups[i]);
                Assert.AreEqual(1, element.Count);
            }
            Assert.AreEqual(_groups.Count, displayedGroups.Count);
        }
    }
}