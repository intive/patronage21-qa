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
    [Scope(Feature = "REGISTER_FAILED_NOTIFICATION")]
    public class RegisterFailedNotificationSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();

        public RegisterFailedNotificationSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string element)
        {
            _loginScreen.ClickElement(_driver, element);
        }
        
        [When(@"User submits registration form correctly")]
        public void WhenUserSubmitsRegistrationFormCorrectly()
        {
            _registerScreen.SubmitRegisterFormCorrectly(_driver, _testKey);
            _registerScreen.ClickElement(_driver, "Załóż konto");
        }
        
        [When(@"User submits activation code form with wrong code")]
        public void WhenUserSubmitsActivationCodeFormWithWrongCode()
        {
            _activationScreen.WriteTextToField(_driver, "12341243", "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
        }
    }
}
