using OpenQA.Selenium;
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
    public sealed class RegistrationFormHooks : DriverHelper
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disabled-gpu");

            new DriverManager().SetUpDriver(new ChromeConfig());
            WebDriver = new ChromeDriver(option);

            WebDriver.Navigate().GoToUrl("http://localhost:3000/rejestracja");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            WebDriver.Quit();
        }
    }
}
