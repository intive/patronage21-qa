using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public static IWebDriver driver;
        public static IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            new DriverManager().SetUpDriver(new ChromeConfig());

            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
            driver.Url = "http://localhost:3000/rejestracja-sukces";
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
