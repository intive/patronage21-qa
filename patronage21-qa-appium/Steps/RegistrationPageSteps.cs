using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class RegistrationPageSteps
    {
        private readonly AndroidDriver<AndroidElement> _driver;

        public RegistrationPageSteps(AndroidDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"User is on Registration page")]
        public void GivenUserIsOnRegistrationPage()
        {
            var homePageRegistrationButton = _driver.FindElementByAccessibilityId("Miniaturka modułu rejestracji");
            homePageRegistrationButton.Click();

            var loginPageRegistrationButtonXpath = "//android.widget.Button[2]";
            var loginPageRegistrationButton = _driver.FindElementByXPath(loginPageRegistrationButtonXpath);
            loginPageRegistrationButton.Click();
        }

        [When(@" User completes ""(.*)"" ""(.*)"" with ""(.*)""")]
        public void WhenUserCompletesElementInAWayWithData(string element, string way, string data)
        {
            
        }

        [When(@"User completes form correctly")]
        public void WhenUserCompletesFormCorrectly(Table formData)
        {

        }

        [When(@"User signs up")]
        public void WhenUserSignsUp()
        {
            
        }
        
        [When(@"User signs up again with the same email")]
        public void WhenUserSignsUpAgainWithTheSameEmail()
        {
            
        }

        [Then(@"User sees Registration page")]
        public void ThenUserSeesRegistrationPage()
        {
            
        }

        [Then(@"User ""(.*)"" sign up")]
        public void ThenUserSignUp(string ability)
        {
            
        }
        
        [Then(@"User is informed if ""(.*)"" is valid")]
        public void ThenUserIsInformedIfElementIsValid(string element)
        {
            
        }
    }
}
