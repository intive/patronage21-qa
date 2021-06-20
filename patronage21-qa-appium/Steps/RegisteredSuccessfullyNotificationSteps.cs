using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "REGISTERED_SUCCESSFULLY_NOTIFICATION")]
    public class RegisteredSuccesfullyNotificationSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly ResendCodeScreen _resendCodeScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();
        private readonly UsersScreen _usersScreen = new();
        private readonly UserDetailsScreen _userDetailsScreen = new();
        private readonly DeactivationScreen _deactivationScreen = new();
        private readonly DeactivationSubmitScreen _deactivationSubmitScreen = new();

        public RegisteredSuccesfullyNotificationSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string element)
        {
            _loginScreen.ClickElement(_driver, element);
        }

        [When(@"User submits registration form correctly")]
        public void WhenUserSubmitsRegistrationFormCorrectly()
        {
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterFormCorrectly(_driver, _testKey);
            _registerScreen.SearchForElement(_driver, "Załóż konto").Click();
        }

        [When(@"User submits activation code form correctly")]
        public void WhenUserSubmitsActivationCodeFormCorrectly()
        {
            _activationScreen.WriteTextToField(_driver, "99999999", "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
        }
    }
}