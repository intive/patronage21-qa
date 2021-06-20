using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "RESEND_CODE_SCREEN")]
    public class ResendCodeScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private static JavaApi _javaApi = new();
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ResendCodeScreen _resendCodeScreen = new();

        public ResendCodeScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [BeforeScenario]
        public void Setup()
        {
            // to be developed
            // reset database
            // or use unique data for every scenario
            _driver.LaunchApp();
        }

        [AfterScenario]
        public void TearDown()
        {
            _javaApi.DeactivateUsersByLogin(_testKey);
        }

        [Given(@"User registers as ""(.*)"" with ""(.*)"" email")]
        public void GivenUserRegistersAsWithEmail(string username, string email)
        {
            email = email.Replace("[unique]", _testKey);
            username = username.Replace("[unique]", _testKey);
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, _testKey, "Pan", "test", "[unique]", email, "123456789",
                true, false, false, false, username, "Deactivate11!", "Deactivate11!", "https://www.github.com/[unique]", true, true, true);
        }

        // rename "Weryfikacja adresu email" to "Aktywacja"
        [When(@"User clicks ""(.*)"" on ""(.*)"" screen")]
        public void WhenUserClicksOnScreen(string element, string screen)
        {
            BaseScreen.GetElementFromScreen(_driver, element, screen).Click();
        }

        [When(@"User writes ""(.*)"" to ""(.*)"" field")]
        public void WhenUserWritesToField(string text, string field)
        {
            _resendCodeScreen.WriteTextToField(_driver, text, field);
        }

        [Then(@"User sees ""(.*)"" screen")]
        public void ThenUserSeesScreen(string screen)
        {
            Assert.IsNotEmpty(BaseScreen.GetElementsFromScreen(_driver, "Nagłówek", screen));
        }
    }
}