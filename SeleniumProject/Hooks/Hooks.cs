using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public static IWebDriver _driver;

        public static IObjectContainer _objectContainer;

        public string envUrl = TestContext.Parameters["homePage"];

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.AddArgument("--start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if (string.IsNullOrEmpty(envUrl))
                envUrl = "http://localhost:3000";

            _driver.Url = envUrl;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
