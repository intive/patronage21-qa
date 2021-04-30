using OpenQA.Selenium.Chrome;
using SeleniumProject.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject.Hooks
{
    [Binding]
    [Scope(Feature = "Registration form")]
    public sealed class RegistrationFormHooks : DriverHelper
    {
        public static string Url { get; set; }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disabled-gpu");

            new DriverManager().SetUpDriver(new ChromeConfig());
            WebDriver = new ChromeDriver(option);

            if (Url == null)
                Url = "http://localhost:3000/rejestracja";

            WebDriver.Navigate().GoToUrl(Url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            WebDriver.Quit();
        }
    }
}
