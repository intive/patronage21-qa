using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Screens;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "HOME_SCREEN Navigation")]
    public class HomeNavigationSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();

        public HomeNavigationSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"User is on Home page")]
        public void GivenUserIsOnHomePage()
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, "Pan", "test", "test", "test@email.com", "123456789",
                true, false, false, false, "test", "Deactivate11!", "Deactivate11!", "", true, true, true);
            // to be changed, there is no code table in database yet
            // string code = _javaDatabase.GetProperty("code", "patronative.code_user", "user", "username");
            string code = "99999999";
            _activationScreen.Wait(_driver);
            _activationScreen.WriteTextToField(_driver, code, "Kod");
            _activationScreen.ClickElement(_driver, "Zatwierdź kod");
            _activationScreen.Wait(_driver);
            _registerSubmitScreen.ClickElement(_driver, "Zamknij");
        }

        [When(@"User clicks on ""(.*)"" button")]
        public void WhenUserClickskOnButton(string button)
        {
            if (button.Equals("Back"))
            {
                _driver.Navigate().Back();
            }
            else
            {
                _homeScreen.ClickElement(_driver, button);
            }
        }

        [Then(@"User sees ""(.*)"" page")]
        public void ThenUserSeesPage(string pageTitle)
        {
            var headerXpath = BaseScreen._screensXpathDict[pageTitle]["Nagłówek"];
            Assert.IsNotEmpty(_driver.FindElementsByXPath(headerXpath));
        }
    }
}