using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Screens;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "EVENTS_AUDIT_SCREEN")]
    public class EventsAuditScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly EventsAuditScreen _eventsAuditScreen = new();
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
                    _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "Kowalski", "test@email.com", "123456789",
                        true, false, false, false, "Username", "Deactivate11!", "Deactivate11!", "", true, true, true);
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
            _eventsAuditScreen.WriteTextToField(_driver, text, field);
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
            BaseScreen.FastSwipes(_driver, 5);
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
            List<string> eventTypes = new() { "Logowanie", "Rejestracja", "Wylogowanie" };
            foreach (string type in eventTypes)
            {
                if (eventType != type)
                {
                    Assert.IsEmpty(_eventsAuditScreen.GetElements(_driver, type));
                }
            }
        }

        [Then(@"User sees first element of events list")]
        public void ThenUserSeesFirstElementOfEventsList()
        {
            Assert.Equals(_eventsAuditScreen.GetElement(_driver, "Pierwsze zdarzenie data").Text, _firstElementText);
        }
    }
}