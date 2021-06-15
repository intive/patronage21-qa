using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{

    public class UserPage
    {
        private IWebDriver driver;
        public string envUrl = TestContext.Parameters["javaUsersPage"];

        public UserPage(IWebDriver driver)
        {
            this.driver = driver;
            if (string.IsNullOrEmpty(envUrl))
                envUrl = "http://localhost:3000/";
        }

        public By userHeaderXpath = By.XPath("//h1[contains(@class,'sc-bdnxRM')]");
        public IWebElement UserHeader => driver.FindElement(userHeaderXpath);

        public By searchUserInputXpath = By.XPath("//input[@placeholder='Szukaj użytkownika']");
        public IWebElement SearchUserInput => driver.FindElement(searchUserInputXpath);

        public By technologyGroupListXPath = By.XPath("//*[(text()='Wszystkie grupy technologiczne')]//parent::div");
        public IWebElement technologyGroupList => driver.FindElement(technologyGroupListXPath);

        public By allTechnologyGroupXPath = By.XPath(".//li[contains(text(),'Wszystkie grupy technologiczne')]");

        public IWebElement allTechnologyGroup => driver.FindElement(allTechnologyGroupXPath);

        public By JavaXPath = By.XPath(".//li[contains(text(),'Java')]");

        public IWebElement Java => driver.FindElement(JavaXPath);

        public By mobileAndroidXPath = By.XPath(".//li[contains(text(),'Mobile (Android)')]");
        public IWebElement mobileAndroid => driver.FindElement(mobileAndroidXPath);

        public By brakWynikówXPath = By.XPath("//*[text()='Brak wyników']//parent::div");

        public IWebElement brakWyników => driver.FindElement(brakWynikówXPath);

        public By TomekKowalskiXPath = By.XPath("//*[text()='Tomek Kowalski']//parent::div");
        public IWebElement TomekKowalski => driver.FindElement(TomekKowalskiXPath);
    }
}
