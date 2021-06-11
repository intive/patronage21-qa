using OpenQA.Selenium;

namespace SeleniumProject.Pages
{
    internal class RegistrationSuccessSitePage
    {
        private IWebDriver driver;

        public RegistrationSuccessSitePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement successfulRegistrationText => driver.FindElement(By.XPath("//*[text()[contains(.,'Twoja rejestracja przebiegła pomyślnie!')]]"));
    }
}