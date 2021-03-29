using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class AppiumAndSpecFlowWorksSteps
    {
        private AppiumDriver<AndroidElement> _driver;

        [Before]
        public void Setup()
        {

            var appFileName = "test-app.apk";
            var projectBaseDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            var appPath = Path.Combine(projectBaseDir, @"apps/", appFileName);

            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability("platformName", "Android");
            driverOption.AddAdditionalCapability("deviceName", "Android 30");
            driverOption.AddAdditionalCapability("app", appPath);

            _driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
        }

        [AfterScenario]
        public void TearUp()
        {
            _driver.CloseApp();
            _driver.LaunchApp();
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
            Assert.Pass();
        }
    }
}
