using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class BaseSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly BasePage basePage;

        public BaseSteps(IWebDriver driver)
        {
            _webdriver = driver;
            basePage = new BasePage(_webdriver);            
        }

        [StepDefinition(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string buttonName)
        {
            basePage.buttonName = buttonName;
            basePage.buttonCommon.Click();
        }


    }
}
