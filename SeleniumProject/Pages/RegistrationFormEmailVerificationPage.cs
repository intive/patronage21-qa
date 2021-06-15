using OpenQA.Selenium;
using System;

namespace SeleniumProject.Pages
{
    internal class RegistrationFormEmailVerificationPage
    {
        private IWebDriver driver;

        public RegistrationFormEmailVerificationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement title => driver.FindElement(By.XPath("//*[@id='title-label']"));
        public IWebElement gender => driver.FindElement(By.XPath("//*[@value='Pan']"));
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
        public IWebElement checkBoxInformation => driver.FindElement(By.XPath("//*[@name='information']"));
        public IWebElement zalozKontoButton => driver.FindElement(By.XPath("//*[text()[contains(.,'Załóż konto')]]"));
        public IWebElement codeInput => driver.FindElement(By.XPath("//*[@id='outlined-adornment-password']"));
        public IWebElement renewalSentButton => driver.FindElement(By.XPath("//span[@class='MuiButton-label' and text() = 'Nie otrzymałem/am kodu']"));

        public IWebElement getErrorMessage(string text)
        {
            return driver.FindElement(By.XPath("//*[text()[contains (.,'" + text + "')]]"));
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