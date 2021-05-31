using OpenQA.Selenium;

namespace SeleniumProject.Pages
{
    class ErrorSite_Page
    {
        private IWebDriver driver;

        public ErrorSite_Page(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement wrongAddressText => driver.FindElement(By.XPath("//*[text()[contains(.,'Strona o podanym adresie nie została odnaleziona')]]"));
        public IWebElement patronativePage => driver.FindElement(By.XPath("//*[text()[contains(.,'Witaj w Patron-a-tive!')]]"));
    }
}