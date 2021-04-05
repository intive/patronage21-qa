using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
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
            var appFileName = "Patron-a-tive.apk";
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
        }

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
