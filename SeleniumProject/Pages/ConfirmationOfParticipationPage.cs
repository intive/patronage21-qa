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
        // TO DO: change xpath when site will be updated
        public By mainPageContentElement = By.XPath("//div[text()='tu kontent']");
        public IWebElement mainPageContent => driver.FindElement(mainPageContentElement);
    }
}