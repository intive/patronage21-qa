using System;
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
    [Scope(Feature = "EDIT_PROFILE_SCREEN")]
    public class EditProfileScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private static JavaApi _javaApi = new();
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly Topbar _topbar = new();
        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly UsersScreen _usersScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();
        private readonly EditUserScreen _editUserScreen = new();

        public EditProfileScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [AfterScenario]
        public void TearDown()
        {
            _javaApi.DeactivateUsersByLogin(_testKey);
        }

        [When(@"User registers as ""(.*)"" with surname ""(.*)""")]
        public void WhenUserRegistersAsWithSurname(string username, string surname)
        {
            username = username.Replace("[unique]", _testKey);
            surname = surname.Replace("[unique]", _testKey);
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, _testKey, "Pan", "test", surname, "[unique]@ema.il", "123456789",
                true, false, false, false, username, "Deactivate11!", "Deactivate11!", "https://www.github.com/[unique]", true, true, true);
            string code = "99999999";
            _activationScreen.Wait(_driver);
            _activationScreen.WriteTextToField(_driver, code, "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _activationScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
            _homeScreen.Wait(_driver);
        }

        [When(@"User navigates to ""(.*)"" screen through ""(.*)""")]
        public void WhenUserNavigatesToScreenThrough(string screenName, string through)
        {
            switch (screenName, through)
            {
                case ("Edycja profilu", "Użytkownicy"):
                    _homeScreen.ClickElement(_driver, "Użytkownicy");
                    _usersScreen.WriteTextToField(_driver, _testKey, "Szukaj użytkownika");
                    _usersScreen.ClickElement(_driver, "Ty");
                    BaseScreen.SwipeToBottom(_driver);
                    _userDetailsScreen.ClickElement(_driver, "Edytuj profil");
                    BaseScreen.SwipeToBottom(_driver);
                    break;

                case ("Edycja profilu", "Moje konto"):
                    _topbar.ClickElement(_driver, "Moje konto");
                    BaseScreen.SwipeToBottom(_driver);
                    _userDetailsScreen.ClickElement(_driver, "Edytuj profil");
                    BaseScreen.SwipeToBottom(_driver);
                    break;
            }
        }

        [When(@"User registers")]
        public void WhenUserRegisters(Table table)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, _testKey, table.Rows[0][0], table.Rows[0][1], table.Rows[0][2], table.Rows[0][3], table.Rows[0][4],
                true, false, false, false, table.Rows[0][6], "Deactivate11!", "Deactivate11!", table.Rows[0][5], true, true, true);
            string code = "99999999";
            _activationScreen.Wait(_driver);
            _activationScreen.WriteTextToField(_driver, code, "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _activationScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
            _homeScreen.Wait(_driver);
        }

        [When(@"User fills edit form with data")]
        public void WhenUserFillsEditFormWithData(Table table)
        {
            _editUserScreen.FillForm(_driver, table);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string element)
        {
            _editUserScreen.ClickElement(_driver, element);
        }

        [When(@"User writes ""(.*)"" to ""(.*)"" field")]
        public void WhenUserWritesToField(string text, string field)
        {
            if (text == "[empty]") { text = ""; }
            _editUserScreen.WriteTextToField(_driver, text.ToString(), field);
        }

        [Then(@"User ""(.*)"" data is")]
        public void ThenUserDataIs(string username, Table userData)
        {
            _userDetailsScreen.ClickElement(_driver, "Edytuj profil");
            BaseScreen.SwipeToBottom(_driver);
            Assert.AreEqual(_editUserScreen.GetElement(_driver, "Imię").Text, userData.Rows[0][0]);
            Assert.AreEqual(_editUserScreen.GetElement(_driver, "Nazwisko").Text, userData.Rows[0][1]);
            Assert.AreEqual(_editUserScreen.GetElement(_driver, "Email").Text, userData.Rows[0][2]);
            Assert.AreEqual(_editUserScreen.GetElement(_driver, "Numer telefonu").Text, userData.Rows[0][3]);
            Assert.AreEqual(_editUserScreen.GetElement(_driver, "Github").Text, userData.Rows[0][4]);
            Assert.AreEqual(_editUserScreen.GetElement(_driver, "Bio").Text, userData.Rows[0][5]);
        }

        [Then(@"User ""(.*)"" ""(.*)"" is ""(.*)""")]
        public void ThenUserIs(string username, string attribute, string value)
        {
            value = value.Replace("[unique]", _testKey);
            _editUserScreen.ClickElement(_driver, "Anuluj");
            BaseScreen.SwipeToBottom(_driver);
            _userDetailsScreen.ClickElement(_driver, "Edytuj profil");
            BaseScreen.SwipeToBottom(_driver);
            Assert.AreEqual(_editUserScreen.GetElement(_driver, attribute).Text, value.ToString());
        }

        [Then(@"User sees ""(.*)"" in ""(.*)"" field")]
        public void ThenUserSeesInField(string value, string field)
        {
            Assert.AreEqual(_editUserScreen.GetElement(_driver, field).Text, value.ToString());
        }
    }
}