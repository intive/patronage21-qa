using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    public class BaseSteps
    {
        public AppiumDriver<AndroidElement> _driver;

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
    }
}
