using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Pages;
using System;
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

        [StepDefinition(@"User should be transferred to main site")]
        public void ThenUserShouldBeTransferredToMainSite()
        {
            var wait = new WebDriverWait(_webdriver, new TimeSpan(0, 0, 10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(basePage.mainPageContentElement));

            Assert.AreEqual(true, basePage.mainPageContent.Displayed);
        }
    }
}