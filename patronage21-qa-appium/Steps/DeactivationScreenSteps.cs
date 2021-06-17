using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "DEACTIVATION_SCREEN")]
    public class DeactivationScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly UsersScreen _usersScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();
        private readonly DeactivationScreen _deactivationScreen = new();
        private readonly DeactivationSubmitScreen _deactivationSubmitScreen = new();

        public DeactivationScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [BeforeScenario]
        public void Setup()
        {
            _driver.LaunchApp();
        }

        [Given(@"User is not logged in")]
        public void GivenUserIsNotLoggedIn()
        {
            Assert.IsNotEmpty(_loginScreen.GetElements(_driver, "Nagłówek"));
        }

        [When(@"User registers as ""(.*)"" with surname ""(.*)""")]
        public void WhenUserRegistersAsWithSurname(string username, string surname)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, _testKey, "Pani", "test", surname, "[unique]@ema.il", "123456789",
                true, false, false, false, username, "Deactivate11!", "Deactivate11!", "https://www.github.com/[unique]", true, true, true);
            // to be changed, there is no code table in database yet
            // string code = _javaDatabase.GetProperty("code", "patronative.code_user", "user", username);
            string code = "99999999";
            _activationScreen.Wait(_driver);
            _activationScreen.WriteTextToField(_driver, code, "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _activationScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
        }

        [When(@"User navigates to ""(.*)"" screen through ""(.*)""")]
        public void WhenUserNavigatesToScreenThrough(string screenName, string through)
        {
            switch (screenName, through)
            {
                case ("Dezaktywacja", "Użytkownicy"):
                    _homeScreen.ClickElement(_driver, "Użytkownicy");
                    _usersScreen.Wait(_driver);
                    // _usersScreen.ClickElement(_driver, "Ty");
                    // to be changed, code from previous line will replace next line in future (for now data is mocked and it does not contain any user labeled with "Ty")
                    _usersScreen.ClickElement(_driver, "Liderzy lista bez widocznych uczestników");
                    _userDetailsScreen.SearchForElement(_driver, "Dezaktywuj profil").Click();
                    break;

                case ("Dezaktywacja", "Moje konto"):
                    // to be changed, there is no such navigation yet
                    _homeScreen.ClickElement(_driver, "Użytkownicy");
                    _usersScreen.Wait(_driver);
                    _usersScreen.ClickElement(_driver, "Liderzy lista bez widocznych uczestników");
                    _userDetailsScreen.SearchForElement(_driver, "Dezaktywuj profil").Click();
                    break;
            }
        }

        [When(@"User writes ""(.*)"" to ""(.*)"" field")]
        public void WhenUserWritesToField(string input, string field)
        {
            input = input.Replace("[unique]", _testKey);
            _deactivationScreen.WriteTextToField(_driver, input, field);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string button)
        {
            _deactivationScreen.ClickElement(_driver, button);
            _deactivationScreen.Wait(_driver);
        }

        [When(@"User writes ""(.*)"" characters to ""(.*)"" field")]
        public void WhenUserWritesCharactersToField(int amount, string field)
        {
            string input = new('a', amount);
            _deactivationScreen.WriteTextToField(_driver, input, field);
        }

        [Then(@"User sees ""(.*)"" screen")]
        public void ThenUserSeesScreen(string screenName)
        {
            switch (screenName)
            {
                case "Dezaktywacja":
                    Assert.IsNotEmpty(_deactivationScreen.GetElements(_driver, "Nagłówek"));
                    Assert.IsNotEmpty(_deactivationScreen.GetElements(_driver, "Opis"));
                    Assert.IsNotEmpty(_deactivationScreen.GetElements(_driver, "Instrukcja"));
                    break;
            }
        }

        [Then(@"User with username ""(.*)"" profile is deactivated")]
        public void ThenUserWithUsernameProfileIsDeactivated(string username)
        {
            // to be changed, there is no table user_status in database
            // string active = _javaDatabase.GetProperty("active", "patronative.user_status", "name", username);
            // Assert.AreEqual("false", active);
        }

        [Then(@"User is not logged in")]
        public void ThenUserIsNotLoggedIn()
        {
            Assert.IsNotEmpty(_deactivationSubmitScreen.GetElements(_driver, "Nagłówek"));
            _deactivationSubmitScreen.ClickElement(_driver, "OK");
            Assert.IsNotEmpty(_loginScreen.GetElements(_driver, "Nagłówek"));
        }

        [Then(@"User sees ""(.*)"" characters in ""(.*)"" field")]
        public void ThenUserSeesCharactersInField(int amount, string field)
        {
            string text = _deactivationScreen.GetElement(_driver, field).Text;
            Assert.AreEqual(amount, text.Length);
        }
    }
}