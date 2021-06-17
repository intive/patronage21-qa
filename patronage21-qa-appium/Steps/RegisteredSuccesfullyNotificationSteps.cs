using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using patronage21_qa_appium.Screens;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "REGISTERED_SUCCESSFULLY_NOTIFICATION")]
    public class RegisteredSuccesfullyNotificationSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly JavaDatabase _javaDatabase = new();

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
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "test", "test@e.mail", "123456789",
                true, false, false, false, "TestUsername", "Deactivate11!", "Deactivate11!", "", true, true, true);
        }

        [When(@"User submits activation code form correctly")]
        public void WhenUserSubmitsActivationCodeFormCorrectly()
        {
            _activationScreen.WriteTextToField(_driver, "99999999", "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
        }
    }
}