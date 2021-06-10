using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    public class NavigationPage
    {
        private IWebDriver driver;

        public NavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By users = By.XPath("//*[text()='Użytkownicy']//parent::button");
        private By calendar = By.XPath("//*[text()='Kalendarz']//parent::button");

        private IWebElement usersModule => driver.FindElement(users);
        private IWebElement calendarModule => driver.FindElement(calendar);

        public void NavigateToCalendarSite() => calendarModule.Click();
        public void NavigateToUsersSite() => usersModule.Click();
    }
}
