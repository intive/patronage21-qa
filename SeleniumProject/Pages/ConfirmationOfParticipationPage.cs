using OpenQA.Selenium;

namespace SeleniumProject.Pages
{
    class ConfirmationOfParticipationPage
    {
        IWebDriver driver;
        public ConfirmationOfParticipationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement successfulRegistrationText => driver.FindElement(By.XPath("//*[text()[contains(.,'Twoja rejestracja przebiegła pomyślnie!')]]"));
        public IWebElement mainPageButton => driver.FindElement(By.XPath("//*[text()[contains(.,'Strona główna')]]"));
        
        public By mainPageContentElement = By.XPath("//*[text()[contains(.,'Witaj w Patron-a-tive!')]]");
        public IWebElement mainPageContent => driver.FindElement(mainPageContentElement);
    }
}
