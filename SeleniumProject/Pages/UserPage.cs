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


    }
}
