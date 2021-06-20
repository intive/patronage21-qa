using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Screens;
using patronage21_qa_appium.Utils;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "HOME_SCREEN Navigation")]
    public class HomeNavigationSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private static JavaApi _javaApi = new();
        private readonly string _testKey = UniqueStringGenerator.GenerateShortLettersBasedOnTimestamp();

        private readonly HomeScreen _homeScreen = new();
        private readonly LoginScreen _loginScreen = new();
        private readonly RegisterScreen _registerScreen = new();
        private readonly ActivationScreen _activationScreen = new();
        private readonly RegisterSubmitScreen _registerSubmitScreen = new();

        public HomeNavigationSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [AfterScenario]
        public void TearDown()
        {
            _javaApi.DeactivateUsersByLogin(_testKey);
        }

        [Given(@"User is on Home page")]
        public void GivenUserIsOnHomePage()
        {
            _loginScreen.ClickElement(_driver, "Rejestracja");
            _registerScreen.Wait(_driver);
            _registerScreen.SubmitRegisterForm(_driver, _testKey, "Pan", "test", "[unique]", "[unique]@ema.il", "123456789",
                true, false, false, false, "[unique]", "Deactivate11!", "Deactivate11!", "https://www.github.com/[unique]", true, true, true);
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