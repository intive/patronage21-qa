using OpenQA.Selenium;

namespace SeleniumProject.Pages
{
    internal class ErrorSitePage
    {
        private IWebDriver driver;

        public ErrorSitePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement wrongAddressText => driver.FindElement(By.XPath("//*[text()[contains(.,'Strona o podanym adresie nie została odnaleziona')]]"));
    }
}