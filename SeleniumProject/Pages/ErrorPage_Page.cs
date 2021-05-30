using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    class ErrorPage_Page
    {
        IWebDriver driver;
        public ErrorPage_Page(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement wrongAddressText => driver.FindElement(By.XPath("//*[text()[contains(.,'Strona o podanym adresie nie została odnaleziona')]]"));
        public IWebElement patronativePage => driver.FindElement(By.XPath("//*[text()[contains(.,'Witaj w Patron-a-tive!')]]"));
        //public IWebElement previouslyVisitedSite => driver.FindElement(By.XPath("//*[text()[contains(.,'Wróć')]]"));
    }
}
