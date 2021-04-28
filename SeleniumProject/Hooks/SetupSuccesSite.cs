using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProject.Hooks
{
    [Binding]
    public class SetupSuccesSite
    {
        public IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            //Console.WriteLine("Setup");

            driver = new ChromeDriver();
            driver.Url = "http://localhost:3000/rejestracja-sukces";

         }

        [AfterScenario]
        public void AfterScenario()
        {
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
