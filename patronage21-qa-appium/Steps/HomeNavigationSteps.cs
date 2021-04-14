using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class HomeNavigationSteps
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

        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            _driver.LaunchApp();
        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string buttonId)
        {
            if (buttonId.Equals("Back"))
            {
                _driver.Navigate().Back();
            }
            else
            {
                var button = _driver.FindElementByAccessibilityId(buttonId);
                button.Click();
            }
        }

        [Then(@"I see ""(.*)"" page")]
        public void ThenISeePage(string pageId)
        {
            var page = _driver.FindElementByAccessibilityId(pageId);
            Assert.IsTrue(page.Displayed);
        }
    }
}
