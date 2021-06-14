using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using patronage21_qa_appium.Screens;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "UsersScreen")]
    public class UsersScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly JavaDatabase _javaDatabase = new();

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly UsersScreen _usersScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();
        private readonly DeactivationScreen _deactivationScreen = new();
        private readonly DeactivationSubmitScreen _deactivationSubmitScreen = new();
        private readonly Dictionary<string, Dictionary<string, string>> _screensDict = BaseScreen._screensXpathDict;

        public UsersScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string screenName)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "Usersscreen", "test@email.com", "123456789",
                true, false, false, false, "Usersscreen", "UsersScreen1!", "UsersScreen1!", "", true, true, true);
            _registerSubmitScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
            _homeScreen.Wait(_driver);
            _homeScreen.ClickElement(_driver, "Użytkownicy");
            _usersScreen.Wait(_driver);
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Nagłówek"));
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Opis"));
        }

        [Given(@"Existing user ""(.*)"" assigned to ""(.*)"" list")]
        public void GivenExistingUserAssignedToList(string username, string list)
        {
            // To be developed, there is no implementation allowing this step to work for now
        }

        [Given(@"User is logged in as ""(.*)"" assigned to ""(.*)"" list")]
        public void GivenUserIsLoggedInAsAssignedToList(string username, string list)
        {
            // To be developed, there is no implementation allowing this step to work for now
        }

        [When(@"User writes ""(.*)"" into ""(.*)"" field")]
        public void WhenUserWritesIntoField(string text, string field)
        {
            _usersScreen.WriteTextToField(_driver, text, field);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string element)
        {
            _usersScreen.ClickElement(_driver, element);
        }

        [When(@"User clears ""(.*)"" field")]
        public void WhenUserClearsField(string field)
        {
            _usersScreen.GetElement(_driver, field).Clear();
        }

        [When(@"User clicks ""(.*)"" in ""(.*)"" list")]
        public void WhenUserClicksInList(string element, string list)
        {
            _usersScreen.GetElementFromList(_driver, element, list).Click();
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string button)
        {
            _driver.Navigate().Back();
        }

        [Then(@"""(.*)"" field is empty")]
        public void ThenFieldIsEmpty(string fieldName)
        {
            Assert.AreEqual(_usersScreen.GetElement(_driver, fieldName).Text, fieldName);
        }

        [Then(@"""(.*)"" is set to ""(.*)""")]
        public void ThenIsSetTo(string fieldName, string text)
        {
            Assert.AreEqual(_usersScreen.GetElement(_driver, fieldName).Text, text);
        }

        [Then(@"User sees ""(.*)"" list")]
        public void ThenUserSeesList(string list)
        {
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, list + " nagłówek"));
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, list + " licznik"));
            switch (list)
            {
                case "Liderzy":
                    Assert.IsNotEmpty(_usersScreen.GetLidersList(_driver));
                    break;

                case "Uczestnicy":
                    _usersScreen.SearchForElement(_driver, list + " lista");
                    Assert.IsNotEmpty(_usersScreen.GetParticipantsList(_driver));
                    break;
            }
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, list + " licznik"));
        }

        [Then(@"User sees user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesUserInList(string username, string list)
        {
            Assert.IsNotEmpty(_usersScreen.GetElementsFromList(_driver, username, list));
        }

        [Then(@"User sees information that searched user does not exist")]
        public void ThenUserSeesInformationThatSearchedUserDoesNotExist()
        {
            Assert.Equals("0", _usersScreen.GetElement(_driver, "Liderzy licznik").Text);
            Assert.Equals("0", _usersScreen.GetElement(_driver, "Uczestnicy licznik").Text);
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Liderzy brak wyników"));
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Uczestnicy brak wyników"));
        }

        [Then(@"User does not see user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserDoesNotSeeUserInList(string username, string list)
        {
            Assert.IsEmpty(_usersScreen.GetElementsFromList(_driver, username, list));
        }

        [Then(@"User is on ""(.*)"" screen")]
        public void ThenUserIsOnScreen(string screenName)
        {
            Assert.IsNotEmpty(BaseScreen.GetElementsFromScreen(_driver, "Nagłówek", screenName));
        }

        [Then(@"User sees only one occurance of ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesOnlyOneOccuranceOfInList(string username, string list)
        {
            Assert.Equals(1, _usersScreen.GetElementsFromList(_driver, username, list).Count);
        }

        [Then(@"""(.*)"" list users counter is correct")]
        public void ThenListUsersCounterIsCorrect(string list)
        {
            var usersCount = _usersScreen.GetElements(_driver, list + " lista").Count;
            var counter = _usersScreen.GetElements(_driver, list + " licznik");
            Assert.Equals(counter, usersCount.ToString());
        }

        [Then(@"User sees ""(.*)"" mark next to user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesMarkNextToUserInList(string mark, string username, string list)
        {
            var markedUser = _usersScreen.GetElement(_driver, list + " Ty użytkownik");
            Assert.Equals(username, markedUser.Text);
        }

        [Then(@"No other user is marked with ""(.*)""")]
        public void ThenNoOtherUserIsMarkedWith(string mark)
        {
            var marks = _usersScreen.GetElements(_driver, mark);
            Assert.AreEqual(1, marks.Count);
        }

        [Then(@"User does not see ""(.*)"" mark next to user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserDoesNotSeeMarkNextToUserInList(string mark, string username, string list)
        {
            Assert.IsEmpty(_usersScreen.GetElements(_driver, list + " Ty użytkownik"));
        }
    }
}