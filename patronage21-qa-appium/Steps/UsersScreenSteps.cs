using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class UsersScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        public UsersScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [BeforeFeature]
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
            _driver.FindElementByXPath("//android.widget.ImageView[@content-desc='Miniaturka modułu użytkowników']").Click();
            Assert.IsNotEmpty(_driver.FindElementsByXPath(_usersScreenDict[screenName]));
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
            var field = _driver.FindElementByXPath(_usersScreenDict[fieldName]);
            field.SendKeys(input + "\n");
        }
        
        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string buttonName)
        {
        }
        
        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string elementName)
        {
            _driver.FindElementByXPath(_usersScreenDict[elementName]).Click();
        }
        
        [When(@"User clears ""(.*)"" field")]
        public void WhenUserClearsField(string fieldName)
        {
            _driver.FindElementByXPath(_usersScreenDict[fieldName]).Clear();
        }
        
        [When(@"User clicks ""(.*)"" in ""(.*)"" list")]
        public void WhenUserClicksInList(string userName, string listName)
        {
            _driver.FindElementByXPath(_usersScreenDict[listName + "_list"] + "[@text='" + userName + "']").Click();
        }
        
        [Then(@"""(.*)"" field is empty")]
        public void ThenFieldIsEmpty(string fieldName)
        {
            Assert.IsNotEmpty(_driver.FindElementsByXPath(_usersScreenDict[fieldName] + "[@text='Szukaj użytkownika']"));
        }
        
        [Then(@"""(.*)"" is set to ""(.*)""")]
        public void ThenIsSetTo(string fieldName, string elementText)
        {
            Assert.IsNotEmpty(_driver.FindElementsByXPath(_usersScreenDict[fieldName] + "[@text='" + elementText + "']"));
        }
        
        [Then(@"User sees ""(.*)"" list")]
        public void ThenUserSeesList(string listName)
        {
            Assert.IsNotEmpty(_driver.FindElementsByXPath(_usersScreenDict[listName + "_list"]));
        }
        
        [Then(@"User sees information that searched user does not exist")]
        public void ThenUserSeesInformationThatSearchedUserDoesNotExist()
        {
            Assert.Equals("0", _driver.FindElementsByXPath(_usersScreenDict["Liderzy_counter"]));
            Assert.Equals("0", _driver.FindElementsByXPath(_usersScreenDict["Uczestnicy_counter"]));
        }
        
        [Then(@"User sees user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesUserInList(string userName, string listName)
        {
            Assert.IsNotEmpty(_driver.FindElementsByXPath(_usersScreenDict[listName + "_list"] + "[@text='" + userName + "']"));
        }
        
        [Then(@"User does not see user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserDoesNotSeeUserInList(string userName, string listName)
        {
            Assert.IsEmpty(_driver.FindElementsByXPath(_usersScreenDict[listName + "_list"] + "[@text='" + userName + "']"));
        }
        
        [Then(@"User sees ""(.*)"" screen")]
        public void ThenUserSeesScreen(string screenName)
        {
            Assert.IsNotEmpty(_driver.FindElementsByXPath(_usersScreenDict[screenName]));
        }
        
        [Then(@"User is on ""(.*)"" screen")]
        public void ThenUserIsOnScreen(string screenName)
        {
            Assert.IsNotEmpty(_driver.FindElementsByXPath(_usersScreenDict[screenName]));
        }
        
        [Then(@"User sees only one occurance of ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesOnlyOneOccuranceOfInList(string userName, string listName)
        {
            Assert.Equals(1, _driver.FindElementsByXPath(_usersScreenDict[listName + "_list"] + "[@text='" + userName + "']").Count);
        }
        
        [Then(@"""(.*)"" list users counter is correct")]
        public void ThenListUsersCounterIsCorrect(string listName)
        {
            var users = _driver.FindElementsByXPath(_usersScreenDict[listName + "_list"]);
            var counter = _driver.FindElementsByXPath(_usersScreenDict[listName + "_counter"]);
            Assert.Equals(counter, users.Count.ToString());
        }
        
        [Then(@"User sees ""(.*)"" mark next to user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserSeesMarkNextToUserInList(string markText, string userName, string listName)
        {
            var mark = _driver.FindElementByXPath(_usersScreenDict[listName + "_list"] + "[@text='" + userName + "']/following-sibling::android.view.View[position()=1]");
            Assert.Equals(markText, mark.Text);
        }
        
        [Then(@"No other user is marked with ""(.*)""")]
        public void ThenNoOtherUserIsMarkedWith(string markText)
        {
            _driver.FindElementByXPath("//android.view.View[@text='" + markText + "']");
        }
        
        [Then(@"User does not see ""(.*)"" mark next to user ""(.*)"" in ""(.*)"" list")]
        public void ThenUserDoesNotSeeMarkNextToUserInList(string markText, string userName, string listName)
        {
            var mark = _driver.FindElementByXPath(_usersScreenDict[listName + "_list"] + "[@text='" + userName + "']/following-sibling::android.view.View[position()=1]");
            Assert.AreNotEqual(markText, mark.Text);
        }
    }
}
