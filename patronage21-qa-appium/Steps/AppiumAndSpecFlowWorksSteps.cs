using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class AppiumAndSpecFlowWorksSteps : BaseSteps
    {
        [Given(@"I run app using Appium server")]
        public void GivenIRunAppUsingAppiumServer()
        {
            _driver.LaunchApp();
        }

        [When(@"I wait for app to start")]
        public void WhenIWaitForAppToStart()
        {
            Thread.Sleep(1000);
        }

        [Then(@"App should run")]
        public void ThenAppShouldRun()
        {
            Assert.AreEqual(AppState.RunningInForeground, _driver.GetAppState("com.intive.patronative"));
        }
    }
}
