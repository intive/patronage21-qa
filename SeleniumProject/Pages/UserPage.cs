using OpenQA.Selenium;
using System;

namespace SeleniumProject.Pages
{
    public class UserPage
    {
        private IWebDriver driver;
        public string UrlUser = "http://intive-patronage.pl/";

        public UserPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By userHeaderXpath = By.XPath("//h1[contains(@class,'sc-bdnxRM')]");
        public IWebElement UserHeader => driver.FindElement(userHeaderXpath);

        public By searchUserInputXpath = By.XPath("//input[@placeholder='Szukaj użytkownika']");
        public IWebElement SearchUserInput => driver.FindElement(searchUserInputXpath);


    }
}