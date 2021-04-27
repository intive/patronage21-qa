﻿using BoDi;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Drivers;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class CommonHooks
    {
        private static AppiumDriver<AndroidElement> _driver;

        [BeforeTestRun]
        public static void Init()
        {
            _driver = AndroidDriver.Init();
        }

        [BeforeScenario]
        public void Setup(IObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs(_driver);
            _driver.LaunchApp();
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.CloseApp();
        }
    }
}