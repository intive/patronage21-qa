using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Screens;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    [Scope(Feature = "LOGIN_SCREEN")]
    public class LoginScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        private readonly LoginScreen _loginScreen = new();

        public LoginScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string element)
        {
            _loginScreen.ClickElement(_driver, element);
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string button)
        {
            switch (button)
            {
                case "Back":
                    _driver.Navigate().Back();
                    break;
            }
        }
        
        [Then(@"""(.*)"" screen is displayed correctly")]
        public void ThenScreenIsDisplayedCorrectly(string screenName)
        {
            switch (screenName)
            {
                case "Logowanie":

                    break;
            }
        }
    }
}
