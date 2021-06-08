using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using patronage21_qa_appium.Screens;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class RegisterScreenSteps
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

        public RegisterScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Given(@"User is on Registration page")]
        public void GivenUserIsOnRegistrationPage()
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
        }
        
        [When(@"User completes form correctly but with ""(.*)"" set to ""(.*)""")]
        public void WhenUserCompletesFormCorrectlyButWithSetTo(string field, string value)
        {
            if (field.Contains("Imi")) { field = "Imię"; }
            else if (field.Contains("Potw")) { field = "Potwierdź hasło"; }
            else if (field.Contains("Has")) { field = "Hasło"; }
            if (value.Contains("[znakidiakrytyczne]")) { value = value.Replace("[znakidiakrytyczne]", "ĘÓĄŚŁŻŹŃ"); }
            _registerScreen.SubmitRegisterFormWithFieldSetTo(_driver, field, value);
        }
        
        [Then(@"Submit button is inactive")]
        public void ThenButtonIsInactive()
        {
            Assert.IsFalse(_registerScreen.GetElement(_driver, "Załóż konto").Enabled);
        }

        [Then(@"User sees ""(.*)"" screen")]
        public void ThenUserSeesScreen(string screenName)
        {
            Assert.IsNotEmpty(BaseScreen._screensXpathDict[screenName]["Nagłówek"]);
        }

        [When(@"User submits register form")]
        public void WhenUserSubmitsRegisterForm()
        {
            BaseScreen.SwipeToBottom(_driver);
            _registerScreen.GetElement(_driver, "Załóż konto").Click();
        }

        [Then(@"User ""(.*)"" is created")]
        public void ThenUserIsCreated(string login)
        {
            // To be developed
            // when user registration will be connected to api
            // check if created user exists in database 
        }

        [When(@"User completes form correctly but with every tech group selected")]
        public void WhenUserCompletesFormCorrectlyButWithEveryTechGroupSelected()
        {
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "test", "test@email.com", "123456789",
                true, true, true, true, "TestLogin", "Deactivate11!", "Deactivate11!", "", true, true, false);
        }

        [When(@"User completes form correctly but without any tech group selected")]
        public void WhenUserCompletesFormCorrectlyButWithoutAnyTechGroupSelected()
        {
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "test", "test@email.com", "123456789",
                false, false, false, false, "TestLogin", "Deactivate11!", "Deactivate11!", "", true, true, false);
        }

        [When(@"User clicks ""(.*)"" checkbox")]
        public void WhenUserClicksCheckbox(string checkbox)
        {
            BaseScreen.SwipeToBottom(_driver);
            _registerScreen.ClickElement(_driver, checkbox);
        }

        [Then(@"Submit button is active")]
        public void ThenSubmitButtonIsActive()
        {
            Assert.IsTrue(_registerScreen.GetElement(_driver, "Załóż konto").Enabled);
        }

    }
}
