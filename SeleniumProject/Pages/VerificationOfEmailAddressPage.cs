using OpenQA.Selenium;
using System;

namespace SeleniumProject.Pages
{
    internal class VerificationOfEmailAddressPage
    {
        private IWebDriver driver;

        public VerificationOfEmailAddressPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement firstName => driver.FindElement(By.XPath("//*[@name='firstName']"));
        public IWebElement lastName => driver.FindElement(By.XPath("//*[@name='lastName']"));
        public IWebElement email => driver.FindElement(By.XPath("//*[@name='email']"));
        public IWebElement phone => driver.FindElement(By.XPath("//*[@name='phone']"));
        public IWebElement githubLink => driver.FindElement(By.XPath("//*[@name='githubLink']"));
        public IWebElement login => driver.FindElement(By.XPath("//*[@name='login']"));
        public IWebElement password => driver.FindElement(By.XPath("//*[@name='password']"));
        public IWebElement passwordConfirm => driver.FindElement(By.XPath("//*[@name='passwordConfirm']"));
        public IWebElement checkBoxQA => driver.FindElement(By.XPath("//*[@value='QA']"));
        public IWebElement checkBoxTermsAndConditions => driver.FindElement(By.XPath("//*[@name='regulations']"));
        public IWebElement zalozKontoButton => driver.FindElement(By.XPath("//*[text()[contains(.,'Załóż konto')]]"));
        public IWebElement codeInput => driver.FindElement(By.XPath("//*[@id='outlined-adornment-password']"));
        public IWebElement confirmationButton => driver.FindElement(By.XPath("//*[text()[contains(.,'Zatwierdź kod')]]/parent::button"));
        public IWebElement renewalSentButton => driver.FindElement(By.XPath("//span[@class='MuiButton-label' and text() = 'Nie otrzymałem/am kodu']"));
        public IWebElement getErrorMessage(string p0)
        {
            return driver.FindElement(By.XPath("//*[text()[contains (.,'" + p0 + "')]]"));
        }

        public static string GenerateEmailAdress()
        {
            Random rand = new Random();
            string email = $"example{rand.Next(0, 10000)}@email.com";

            return email;
        }

        public static string GenerateLogin()
        {
            Random rand = new Random();
            string login = $"userLogin{rand.Next(0, 10000)}";

            return login;
        }

        public static string GenerateGithubLink()
        {
            Random rand = new Random();
            string githubLink = "https://github.com/example" + $"{rand.Next(0, 10000)}";
            return githubLink;
        }
    }
}