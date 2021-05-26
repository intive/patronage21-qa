using OpenQA.Selenium;
using System;

namespace SeleniumProject.Pages
{
    public class RegistrationFormPage
    {
        private IWebDriver driver;

        public RegistrationFormPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By firstName = By.XPath(".//*[@name='firstName']");
        private By lastName = By.XPath(".//*[@name='lastName']");
        private By email = By.XPath(".//*[@name='email']");
        private By phone = By.XPath(".//*[@name='phone']");
        private By githubLink = By.XPath(".//*[@name='githubLink']");
        private By javaScriptCheckBox = By.XPath(".//*[@value='JS']");
        private By javaCheckBox = By.XPath(".//*[@value='Java']");
        private By qaCheckBox = By.XPath(".//*[@value='QA']");
        private By mobileCheckBox = By.XPath(".//*[@value='Mobile']");
        private By login = By.XPath(".//*[@name='login']");
        private By password = By.XPath(".//*[@name='password']");
        private By passwordconfirm = By.XPath(".//*[@name='passwordConfirm']");
        private By createAccountButton = By.XPath(".//*[@type='submit']");
        private By termsAndConditionsCheckBox = By.XPath(".//*[@name='regulations']");

        public IWebElement txtFirstName => driver.FindElement(firstName);
        public IWebElement txtLastName => driver.FindElement(lastName);
        public IWebElement txtEmail => driver.FindElement(email);
        public IWebElement txtPhone => driver.FindElement(phone);
        public IWebElement txtGithubLink => driver.FindElement(githubLink);
        public IWebElement checkBoxJavaScript => driver.FindElement(javaScriptCheckBox);
        public IWebElement checkBoxJava => driver.FindElement(javaCheckBox);
        public IWebElement checkBoxQA => driver.FindElement(qaCheckBox);
        public IWebElement checkBoxMobileAndroid => driver.FindElement(mobileCheckBox);
        public IWebElement txtLogin => driver.FindElement(login);
        public IWebElement txtPassword => driver.FindElement(password);
        public IWebElement txtPasswordConfirm => driver.FindElement(passwordconfirm);
        public IWebElement buttonCreateAccount => driver.FindElement(createAccountButton);
        public IWebElement checkBoxTermsAndConditions => driver.FindElement(termsAndConditionsCheckBox);

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
            }
            else
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
            txtPhone.SendKeys("abcdef");
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
            checkBoxJavaScript.Click();
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
            checkBoxJavaScript.Click();
            txtLogin.SendKeys(login);
            txtPassword.SendKeys(password);
            txtPasswordConfirm.SendKeys("wrongConfirmPassword");
        }

        public void RegistrationFormWithTooShortPhoneNumber(string firstName, string lastName, string email)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(12345678.ToString());
        }

        public void RegistrationFormWithTooShortLogin(string firstName, string lastName, string email, string githubLink)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(123456789.ToString());
            txtGithubLink.SendKeys(githubLink);
            checkBoxJavaScript.Click();
            txtLogin.SendKeys("l");
        }

        public void RegistrationFormWithTooShortHasło(string firstName, string lastName, string email, string githubLink)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(123456789.ToString());
            txtGithubLink.SendKeys(githubLink);
            checkBoxJavaScript.Click();
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

        public void RegistrationFormWithTooLongHaslo()
        {
            txtFirstName.SendKeys("Jan");
            txtLastName.SendKeys("Kowalski");
            txtEmail.SendKeys("example@email.com");
            txtPhone.SendKeys(123456789.ToString());
            txtGithubLink.SendKeys("github.com/example12");
            checkBoxJavaScript.Click();
            txtLogin.SendKeys("exampleLogin");
            txtPassword.SendKeys("tooLongPasswordWithSpecialKey6@");
        }

        public void RegistrationFormWithTooShortImie()
        {
            txtFirstName.SendKeys("J");
        }

        public void RegistrationFormWithTooShortNazwisko(string firstName)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys("K");
        }
        public void RegistrationFormWithTooLongGithubLink()
        {
            txtFirstName.SendKeys("Jan");
            txtLastName.SendKeys("Kowalski");
            txtEmail.SendKeys("example@email.com");
            txtPhone.SendKeys(123456789.ToString());
            txtGithubLink.SendKeys("github.com/tooLongGithubLinkWhichIsIncorrect1234567");
        }
    }
}