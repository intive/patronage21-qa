using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class RunAppSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        public RunAppSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"I run app using Appium server")]
        public void GivenIRunAppUsingAppiumServer()
        {
        }

        [When(@"I wait for app to start")]
        public void WhenIWaitForAppToStart()
        {
        }

        [Then(@"App should run")]
        public void ThenAppShouldRun()
        {
            Assert.AreEqual(AppState.RunningInForeground, _driver.GetAppState("com.intive.patronative"));
        }
    }
}
