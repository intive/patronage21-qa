using OpenQA.Selenium;
using System;

namespace SeleniumProject.Pages
{
    internal class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string buttonName;
        public By buttonCommonXPath => By.XPath($"//*[text()[contains(.,'{buttonName}')]]/parent::*");
        public IWebElement buttonCommon => driver.FindElement(buttonCommonXPath);

        public By mainPageContentElement = By.XPath("//*[text()[contains(.,'Witaj w Patron-a-tive!')]]");
        public IWebElement mainPageContent => driver.FindElement(mainPageContentElement);
    }

    }