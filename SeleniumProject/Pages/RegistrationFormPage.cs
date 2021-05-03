using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    public class RegistrationFormPage
    {
        IWebDriver driver;
        public RegistrationFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement txtFirstName => driver.FindElement(By.XPath(".//*[@name='firstName']"));
        IWebElement txtLastName => driver.FindElement(By.XPath(".//*[@name='lastName']"));
        IWebElement txtEmail => driver.FindElement(By.XPath(".//*[@name='email']"));
        IWebElement txtPhone => driver.FindElement(By.XPath(".//*[@name='phone']"));
        IWebElement txtGithubLink => driver.FindElement(By.XPath(".//*[@name='githubLink']"));
        IWebElement checkBoxJavaScript => driver.FindElement(By.XPath(".//*[@value='JS']"));
        IWebElement checkBoxJava => driver.FindElement(By.XPath(".//*[@value='Java']"));
        IWebElement checkBoxQA => driver.FindElement(By.XPath(".//*[@value='QA']"));
        IWebElement checkBoxMobileAndroid => driver.FindElement(By.XPath(".//*[@value='Mobile']"));
        IWebElement txtLogin => driver.FindElement(By.XPath(".//*[@name='login']"));
        IWebElement txtPassword => driver.FindElement(By.XPath(".//*[@name='password']"));
        IWebElement txtPasswordConfirm => driver.FindElement(By.XPath(".//*[@name='passwordConfirm']"));
        IWebElement buttonCreateAccount => driver.FindElement(By.XPath(".//*[@type='submit']"));
        IWebElement checkBoxTermsAndConditions => driver.FindElement(By.XPath(".//*[@name='regulations']"));

        public void ClickLastName() => txtLastName.Click();
        public void ClickEmail() => txtEmail.Click();
        public void ClickPhoneNumber() => txtPhone.Click();
        public void ClickGithubLink() => txtGithubLink.Click();
        public void ClickTechnologies() => checkBoxJavaScript.Click();
        public void ClickLogin() => txtLogin.Click();
        public void ClickPassword() => txtPassword.Click();
        public void ClickPasswordConfirm() => txtPasswordConfirm.Click();
        public void CreateAccountButtonClick() => buttonCreateAccount.Click();
        public void ClickTermsAndConditions() => checkBoxTermsAndConditions.Click();
        public void RegistrationFormWithData(string firstName, string lastName, string email, Nullable<int> phone, string githubLink, string login, string password, string passwordConfirm)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(phone.ToString());
            txtGithubLink.SendKeys(githubLink);
            txtLogin.SendKeys(login);
            txtPassword.SendKeys(password);
            txtPasswordConfirm.SendKeys(passwordConfirm);
        }
        public void RegistrationFormWithoutData()
        {
            txtFirstName.SendKeys("");
            txtLastName.SendKeys("");
            txtEmail.SendKeys("");
            txtPhone.SendKeys("");
            txtGithubLink.SendKeys("");
            txtLogin.SendKeys("");
            txtPassword.SendKeys("");
            txtPasswordConfirm.SendKeys("");
        }
        public bool CreateAccountButtonIsActiveOrNot()
        {
            if (buttonCreateAccount.Enabled)
            {
                return true;
            } else
            {
                return false;
            }
        }
        public void RegistrationFormWithIncorrectEmail(string firstName, string lastName)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys("incorrectEmail.com");
        }
        public void RegistrationFormWithIncorrectPhoneNumber(string firstName, string lastName, string email)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys("12345678");
        }
        public void RegistrationFormWithIncorrectGithubLink(string firstName, string lastName, string email, Nullable<int> phone)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(phone.ToString());
            txtGithubLink.SendKeys("wrongLink");
        }
        public void RegistrationFormWithIncorrectPassword(string firstName, string lastName, string email, Nullable<int> phone, string githubLink, string login)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(phone.ToString());
            txtGithubLink.SendKeys(githubLink);
            ClickTechnologies();
            txtLogin.SendKeys(login);
            txtPassword.SendKeys("wrongpassword");
        }
        public void RegistrationFormWithIncorrectPasswordConfirm(string firstName, string lastName, string email, Nullable<int> phone, string githubLink, string login, string password)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(phone.ToString());
            txtGithubLink.SendKeys(githubLink);
            ClickTechnologies();
            txtLogin.SendKeys(login);
            txtPassword.SendKeys(password);
            txtPasswordConfirm.SendKeys("wrongConfirmPassword");
        }
        public void RegistrationFormWithTooShortPhoneNumber(string firstName, string lastName, string email) 
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(123.ToString());
        }
        public void RegistrationFormWithTooShortLogin(string firstName, string lastName, string email, string githubLink) 
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(123456789.ToString());
            txtGithubLink.SendKeys(githubLink);
            ClickTechnologies();
            txtLogin.SendKeys("l");
        }
        public void RegistrationFormWithTooShortHasło(string firstName, string lastName, string email, string githubLink) 
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(123456789.ToString());
            txtGithubLink.SendKeys(githubLink);
            ClickTechnologies();
            txtLogin.SendKeys("exampleLogin");
            txtPassword.SendKeys("short");
        }
        public void RegistrationFormWithTooLongFirstName()
        {
            txtFirstName.SendKeys("enterTooLongUserFirstName");
        }
        public void RegistrationFormWithTooLongLastName()
        {
            txtFirstName.SendKeys("Jan");
            txtLastName.SendKeys("enterTooLongUserLastName");
        }
        public void RegistrationFormWithTooLongPhoneNumber()
        {
            txtFirstName.SendKeys("Jan");
            txtLastName.SendKeys("Kowalski");
            txtLogin.SendKeys("exmapleEmail@email.com");
            txtPhone.SendKeys(1234567890.ToString());
        }
        public void RegistrationFormWithTooLongLogin()
        {
            txtFirstName.SendKeys("Jan");
            txtLastName.SendKeys("Kowalski");
            txtLogin.SendKeys("tooLongExampleLogin");
        }
        public void RegistrationFormWtihoutTechnologies(string firstName, string lastName, string email, Nullable<int> phone, string githubLink)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(phone.ToString());
            txtGithubLink.SendKeys(githubLink);
        }
        public void ChecksAllTechnologies()
        {
            checkBoxJavaScript.Click();
            checkBoxJava.Click();
            checkBoxQA.Click();
            checkBoxMobileAndroid.Click();
        }
        public void CheckMaxTechnologiesFields()
        {
            checkBoxJavaScript.Click();
            checkBoxJava.Click();
            checkBoxQA.Click();
        }
    }
}
