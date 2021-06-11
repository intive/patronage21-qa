using OpenQA.Selenium;

namespace SeleniumProject.Pages
{
    public class NavigationPage
    {
        private IWebDriver driver;

        public NavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateToHomePage()
        {
            driver.Navigate().GoToUrl(driver.Url);
        }
        public void NavigateToCalendar()
        {
            driver.Navigate().GoToUrl(driver.Url + "kalendarz");
        }
        public void NavigateToRegistration()
        {
            driver.Navigate().GoToUrl(driver.Url + "rejestracja");
        }
        public void NavigateToVerification()
        {
            driver.Navigate().GoToUrl(driver.Url + "weryfikacja");
        }
        public void NavigateToErrorSite()
        {
            driver.Navigate().GoToUrl(driver.Url + "404");
        }
        public void NavigateToSuccessfulRegistration()
        {
            driver.Navigate().GoToUrl(driver.Url + "rejestracja-sukces");
        }
    }
}