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
    [Scope(Feature = "ResendCodeScreen")]
    public class ResendCodeScreenSteps
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
        [Given(@"User registers as ""(.*)"" with ""(.*)"" email")]
        public void GivenUserRegistersAsWithEmail(string username, string email)
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "test", email, "123456789",
                true, false, false, false, username, "Deactivate11!", "Deactivate11!", "", true, true, true);
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
