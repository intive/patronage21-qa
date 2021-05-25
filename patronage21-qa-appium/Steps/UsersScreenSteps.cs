using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Drivers;

namespace patronage21_qa_appium.Steps
{
    [Binding]
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

        [BeforeFeature]
        [Scope(Feature = "UsersScreen")]
        public void Setup()
        {
            /*
             * create user Jan Kowalski in Uczestnicy list and groups group 1, group 2
             * create user Jan Kowalski in Liderzy list and groups group 1, group 2
             * create user Anna Nowak in Liderzy list and groups group 3, group 4
             * create user Anna Nowak in Uczestnicy list and groups group 3, group 4
             */
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
        public void GivenExistingUserAssignedToList(string userName, string listName)
        {
        }
        
        [Given(@"User ""(.*)"" does not exist")]
        public void GivenUserDoesNotExist(string userName)
        {
        }
        
        [Given(@"Existing user ""(.*)"" assigned to ""(.*)"" list and ""(.*)"" group")]
        public void GivenExistingUserAssignedToListAndGroup(string userName, string listName, string groupName)
        {
        }
        
        [Given(@"Existing user ""(.*)"" assigned to ""(.*)"" list and not to ""(.*)"" group")]
        public void GivenExistingUserAssignedToListAndNotToGroup(string userName, string listName, string groupName)
        {
        }
        
        [Given(@"Existing user ""(.*)"" assigned to ""(.*)"" list and ""(.*)"" and ""(.*)"" groups")]
        public void GivenExistingUserAssignedToListAndAndGroups(string userName, string listName, string group1Name, string group2Name)
        {
        }
        
        [Given(@"Existing users in ""(.*)"" group and ""(.*)"" list")]
        public void GivenExistingUsersInGroupAndList(string groupName, string listName)
        {
        }
        
        [Given(@"No existing user named ""(.*)""")]
        public void GivenNoExistingUserNamed(string userName)
        {
        }
        
        [Given(@"User is logged in as ""(.*)"" assigned to ""(.*)"" list")]
        public void GivenUserIsLoggedInAsAssignedToList(string userName, string listName)
        {
            // log in as ...
        }
        
        [Given(@"No other user in list ""(.*)"" is named ""(.*)""")]
        public void GivenNoOtherUserInListIsNamed(string listName, string userName)
        {
        }
        
        [When(@"User writes ""(.*)"" into ""(.*)"" field")]
        public void WhenUserWritesIntoField(string input, string fieldName)
        {
            _usersScreen.WriteTextToField(_driver, input, fieldName);
        }
        
        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string buttonName)
        {
            _usersScreen.ClickElement(_driver, buttonName);
        }
        
        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string elementName)
        {
            _usersScreen.ClickElement(_driver, elementName);
        }
        
        [When(@"User clears ""(.*)"" field")]
        public void WhenUserClearsField(string fieldName)
        {
            _usersScreen.GetElement(_driver, fieldName).Clear();
        }
        
        [When(@"User clicks ""(.*)"" in ""(.*)"" list")]
        public void WhenUserClicksInList(string userName, string listName)
        {
            _usersScreen.GetElementFromList(_driver, userName, listName).Click();
        }
        
        [Then(@"""(.*)"" field is empty")]
        public void ThenFieldIsEmpty(string fieldName)
        {
            Assert.AreEqual(_usersScreen.GetElement(_driver, fieldName).Text, fieldName);
        }
        
        [Then(@"""(.*)"" is set to ""(.*)""")]
        public void ThenIsSetTo(string fieldName, string elementText)
        {
            Assert.AreEqual(_usersScreen.GetElement(_driver, fieldName).Text, elementText);
        }
        
        [Then(@"User sees ""(.*)"" list")]
        public void ThenUserSeesList(string listName)
        {
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, listName + " nagłówek"));
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, listName + " licznik"));
            switch (listName)
            {
                case "Liderzy":
                    Assert.IsNotEmpty(_usersScreen.GetLidersList(_driver));
                    break;

                case "Uczestnicy":
                    Assert.IsNotEmpty(_usersScreen.GetParticipantsList(_driver));
                    break;
            }
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, listName + " licznik"));
        }
        
        [Then(@"User sees information that searched user does not exist")]
        public void ThenUserSeesInformationThatSearchedUserDoesNotExist()
        {
            Assert.Equals("0", _usersScreen.GetElement(_driver, "Liderzy licznik").Text);
            Assert.Equals("0", _usersScreen.GetElement(_driver, "Uczestnicy licznik").Text);
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Liderzy brak wyników"));
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Uczestnicy brak wyników"));
        }
        
        [Then(@"User sees user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesUserInList(string userName, string listName)
        {
            
            Assert.IsNotEmpty(_usersScreen.GetElementsFromList(_driver, userName, listName));
        }
        
        [Then(@"User does not see user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserDoesNotSeeUserInList(string userName, string listName)
        {
            Assert.IsEmpty(_usersScreen.GetElementsFromList(_driver, userName, listName));
        }
        
        [Then(@"User sees ""(.*)"" screen")]
        public void ThenUserSeesScreen(string screenName)
        {
            switch (screenName)
            {
                case "Dezaktywacja":
                    Assert.IsNotEmpty(_deactivationScreen.GetElements(_driver, "Nagłówek"));
                    Assert.IsNotEmpty(_deactivationScreen.GetElements(_driver, "Opis"));
                    break;

                case "Użytkownicy":
                    Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Nagłówek"));
                    Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Opis"));
                    break;
            }
        }
        
        [Then(@"User is on ""(.*)"" screen")]
        public void ThenUserIsOnScreen(string screenName)
        {
            switch (screenName)
            {
                case "Dezaktywacja":
                    Assert.IsNotEmpty(_deactivationScreen.GetElements(_driver, "Nagłówek"));
                    Assert.IsNotEmpty(_deactivationScreen.GetElements(_driver, "Opis"));
                    break;

                case "Użytkownicy":
                    Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Nagłówek"));
                    Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Opis"));
                    break;
            }
        }
        
        [Then(@"User sees only one occurance of ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesOnlyOneOccuranceOfInList(string userName, string listName)
        {
            Assert.Equals(1, _usersScreen.GetElementsFromList(_driver, userName, listName).Count);
        }
        
        [Then(@"""(.*)"" list users counter is correct")]
        public void ThenListUsersCounterIsCorrect(string listName)
        {
            var usersCount = _usersScreen.GetElements(_driver, listName + " lista").Count;
            var counter = _usersScreen.GetElements(_driver, listName + " licznik");
            Assert.Equals(counter, usersCount.ToString());
        }
        
        [Then(@"User sees ""(.*)"" mark next to user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesMarkNextToUserInList(string markText, string userName, string listName)
        {
            var markedUser = _usersScreen.GetElement(_driver, listName + " Ty użytkownik");
            Assert.Equals(userName, markedUser.Text);
        }
        
        [Then(@"No other user is marked with ""(.*)""")]
        public void ThenNoOtherUserIsMarkedWith(string markText)
        {
            var marks = _usersScreen.GetElements(_driver, markText);
            Assert.AreEqual(1, marks.Count);
        }
        
        [Then(@"User does not see ""(.*)"" mark next to user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserDoesNotSeeMarkNextToUserInList(string markText, string userName, string listName)
        {
            Assert.IsEmpty(_usersScreen.GetElementsFromList(_driver, markText, listName));
        }
    }
}
