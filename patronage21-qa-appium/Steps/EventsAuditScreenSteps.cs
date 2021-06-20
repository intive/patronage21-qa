using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using patronage21_qa_appium.Models;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "EVENTS_AUDIT_SCREEN")]
    public class EventsAuditScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly Topbar _topbar = new();
        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly EventsAuditScreen _eventsAuditScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();
        private readonly EditUserScreen _editUserScreen = new();
        private string _firstElementText;

        public EventsAuditScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string screenName)
        {
            switch (screenName)
            {
                case "Audyt zdarzeń":
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
                    _homeScreen.Wait(_driver);
                    _homeScreen.ClickElement(_driver, "Audyt zdarzeń");
                    _eventsAuditScreen.Wait(_driver);
                    break;
            }
        }

        [Given(@"""(.*)"" events are existing")]
        public void GivenEventsAreExisting(int amount)
        {
            _topbar.ClickElement(_driver, "Moje konto");
            for (int i = 0; i < amount - 1; i++)
            {
                _userDetailsScreen.ClickElement(_driver, "Edytuj profil");
                _editUserScreen.ClickElement(_driver, "Zapisz");
            }
            _driver.Navigate().Back();
        }


        [Given(@"User sees first element of events list")]
        public void GivenUserSeesFirstElementOfEventsList()
        {
            _firstElementText = _eventsAuditScreen.GetElement(_driver, "Pierwsze zdarzenie data").Text;
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string element)
        {
            _eventsAuditScreen.ClickElement(_driver, element);
        }

        [When(@"User writes ""(.*)"" to ""(.*)"" field")]
        public void WhenUserWritesToField(string text, string field)
        {
            _eventsAuditScreen.Wait(_driver);
            _eventsAuditScreen.WriteTextToField(_driver, text, field);
        }

        [When(@"User writes his username to ""(.*)"" field")]
        public void WhenUserWritesHisUsernameToField(string field)
        {
            _eventsAuditScreen.WriteTextToField(_driver, _testKey, field);
        }

        [When(@"User scroll down")]
        public void WhenUserScrollDown()
        {
            BaseScreen.FastSwipes(_driver, 2);
        }

        [Then(@"Users sees ""(.*)"" screen")]
        public void ThenUsersSeesScreen(string screenName)
        {
            Assert.IsNotEmpty(BaseScreen.GetElementsFromScreen(_driver, "Nagłówek", screenName));
        }

        [Then(@"Events are displayed in ""(.*)"" order")]
        public void ThenEventsAreDisplayedInOrder(string order)
        {
            var firstEvent = _eventsAuditScreen.GetElement(_driver, "Pierwsze zdarzenie data");
            var firstEventDateTime = _eventsAuditScreen.ParseDateTime(firstEvent.Text);
            BaseScreen.FastSwipes(_driver, 2);
            var lastEvent = _eventsAuditScreen.GetElement(_driver, "Ostatnie zdarzenie data");
            var lastEventDateTime = _eventsAuditScreen.ParseDateTime(lastEvent.Text);

            switch (order)
            {
                case "Od najnowszych":
                    Assert.Greater(firstEventDateTime, lastEventDateTime);
                    break;

                case "Od najstarszych":
                    Assert.Greater(lastEventDateTime, firstEventDateTime);
                    break;
            }
        }

        [Then(@"User ""(.*)"" events are displayed")]
        public void ThenUserEventsAreDisplayed(string username)
        {
            Assert.IsNotEmpty(_driver.FindElementsByXPath($"//android.view.View[text()='{username}']"));
        }

        [Then(@"""(.*)"" events are displayed")]
        public void ThenEventsAreDisplayed(string eventType)
        {
            List<string> eventTypes = new() { "Logowanie", "Udana rejestracja", "Wylogowanie", "Dodanie wydarzenia", "Pomyślna edycja" };
            foreach (string type in eventTypes)
            {
                if (eventType != type)
                {
                    Assert.IsEmpty(_eventsAuditScreen.GetElements(_driver, type));
                }
            }
            Assert.IsNotEmpty(_eventsAuditScreen.GetElements(_driver, eventType));
        }

        [Then(@"User sees first element of events list")]
        public void ThenUserSeesFirstElementOfEventsList()
        {
            _eventsAuditScreen.Wait(_driver);
            Assert.AreEqual(_eventsAuditScreen.GetElement(_driver, "Pierwsze zdarzenie data").Text, _firstElementText);
        }
    }
}