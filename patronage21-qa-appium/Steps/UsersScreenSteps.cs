using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Models;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
using RestSharp;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "USERS_SCREEN")]
    public class UsersScreenSteps
    {
        private static readonly string _url = "http://intive-patronage.pl";
        private static JavaApi _javaApi = new();
        private string _deleteUsername = "";
        private RestClient _client = new(_url);
        private RestRequest _requestPost;
        private RestRequest _requestPatch;
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly UsersScreen _usersScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();

        public UsersScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [AfterScenario]
        public void TearDown()
        {
            _javaApi.DeactivateUsersByLogin(_testKey);
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string screenName)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, _testKey, "Pan", "test", "[unique]", "[unique]@ema.il", "123456789",
                true, false, false, false, "[unique]", "Deactivate11!", "Deactivate11!", "https://www.github.com/[unique]", true, true, true);
            _activationScreen.WriteTextToField(_driver, "99999999", "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _registerSubmitScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
            _homeScreen.Wait(_driver);
            _homeScreen.ClickElement(_driver, "Użytkownicy");
            _usersScreen.Wait(_driver);
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

        [Given(@"Existing user ""(.*)"" assigned to ""(.*)"" group")]
        public void GivenExistingUserAssignedToGroup(string username, string group)
        {
            username = username.Replace("[unique]", _testKey);
            _requestPost = new RestRequest("/api/users", Method.POST);
            List<Group> groups = new() { new Group(group) };
            PostUserRequest request = new(username, username, username, username + "@ema.il", "123456789", "github.com/" + username, "MALE", groups);
            _requestPost.AddParameter("application/json", JsonConvert.SerializeObject(request), ParameterType.RequestBody);
            _client.Execute(_requestPost);
            _deleteUsername = username;
        }

        [Given(@"Existing user with name ""(.*)"" assigned to ""(.*)"" list")]
        public void GivenExistingUserWithNameAssignedToList(string name, string list)
        {
            name = name.Replace("[unique]", _testKey);
            _requestPost = new RestRequest("/api/users", Method.POST);
            List<Group> groups = new() { new Group("JavaScript") };
            PostUserRequest request = new(name, name + "gg", name, name + "@ema.il", "123456789", "github.com/" + name, "MALE", groups);
            _requestPost.AddParameter("application/json", JsonConvert.SerializeObject(request), ParameterType.RequestBody);
            _client.Execute(_requestPost);
            _deleteUsername = name + "gg";
        }

        [When(@"User scrolls to bottom")]
        public void WhenUserScrollsToBottom()
        {
            BaseScreen.FastSwipes(_driver, 5);
        }

        [When(@"User writes ""(.*)"" into ""(.*)"" field")]
        public void WhenUserWritesIntoField(string text, string field)
        {
            text = text.Replace("[unique]", _testKey);
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
            Assert.AreEqual(string.Empty, _usersScreen.GetElement(_driver, fieldName).Text);
        }

        [Then(@"""(.*)"" is set to ""(.*)""")]
        public void ThenIsSetTo(string fieldName, string text)
        {
            Assert.AreEqual(text, _usersScreen.GetElement(_driver, fieldName).Text);
        }

        [Then(@"User sees ""(.*)"" mark next to his username in ""(.*)"" list")]
        public void ThenUserSeesMarkNextToHisUsernameInList(string mark, string list)
        {
            _usersScreen.WriteTextToField(_driver, _testKey, "Szukaj użytkownika");
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, mark));
        }

        [Then(@"User sees user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesUserInList(string username, string list)
        {
            username = username.Replace("[unique]", _testKey);
            Assert.IsNotEmpty(_usersScreen.FindElementsByText(_driver, username));
        }

        [Then(@"User sees information that searched user does not exist")]
        public void ThenUserSeesInformationThatSearchedUserDoesNotExist()
        {
            Assert.AreEqual("0", _usersScreen.GetElement(_driver, "Liderzy licznik").Text);
            Assert.AreEqual("0", _usersScreen.GetElement(_driver, "Uczestnicy licznik").Text);
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Liderzy brak wyników"));
            Assert.IsNotEmpty(_usersScreen.GetElements(_driver, "Uczestnicy brak wyników"));
        }

        [Then(@"User does not see user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserDoesNotSeeUserInList(string username, string list)
        {
            username = username.Replace("[unique]", _testKey);
            Assert.IsEmpty(_usersScreen.FindElementsByText(_driver, username));
        }


        [Then(@"User sees ""(.*)"" ""(.*)"" screen")]
        public void ThenUserSeesScreen(string name, string screenName)
        {
            switch (screenName)
            {
                case "Szczegóły użytkownika":
                    Assert.IsNotEmpty(_userDetailsScreen.FindElementsByText(_driver, name));
                    break;
            }
        }

        [Then(@"User is on ""(.*)"" screen")]
        public void ThenUserIsOnScreen(string screenName)
        {
            Assert.IsNotEmpty(BaseScreen.GetElementsFromScreen(_driver, "Nagłówek", screenName));
        }

        [Then(@"User sees only one occurance of ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesOnlyOneOccuranceOfInList(string username, string list)
        {
            username = username.Replace("[unique]", _testKey);
            Assert.AreEqual(1, _usersScreen.GetElementsFromList(_driver, username, list).Count);
        }

        [Then(@"""(.*)"" list users counter is correct")]
        public void ThenListUsersCounterIsCorrect(string list)
        {
            var usersCount = _usersScreen.GetElements(_driver, list + " lista").Count;
            var counter = _usersScreen.GetElement(_driver, list + " licznik").Text;
            Assert.AreEqual(usersCount.ToString(), counter);
        }

        [Then(@"""(.*)"" list users counter is ""(.*)""")]
        public void ThenListUsersCounterIs(string list, int counter)
        {
            var usersCount = _usersScreen.GetElement(_driver, list + " licznik").Text;
            Assert.AreEqual(counter.ToString(), usersCount);
        }

        [Then(@"User sees ""(.*)"" mark next to user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesMarkNextToUserInList(string mark, string username, string list)
        {
            var markedUser = _usersScreen.GetElement(_driver, list + " Ty użytkownik");
            Assert.AreEqual(username, markedUser.Text);
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