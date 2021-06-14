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

        private By firstNameXPath = By.XPath(".//*[@name='firstName']");
        public IWebElement txtFirstName => driver.FindElement(firstNameXPath);

        private By lastNameXPath = By.XPath(".//*[@name='lastName']");
        public IWebElement txtLastName => driver.FindElement(lastNameXPath);

        private By emailXPath = By.XPath(".//*[@name='email']");
        public IWebElement txtEmail => driver.FindElement(emailXPath);

        private By phoneXPath = By.XPath(".//*[@name='phone']");
        public IWebElement txtPhone => driver.FindElement(phoneXPath);

        private By githubLinkXPath = By.XPath(".//*[@name='githubLink']");
        public IWebElement txtGithubLink => driver.FindElement(githubLinkXPath);

        private By javaScriptCheckBoxXPath = By.XPath(".//*[@value='JS']");
        public IWebElement checkBoxJavaScript => driver.FindElement(javaScriptCheckBoxXPath);

        private By javaCheckBoxXPath = By.XPath(".//*[@value='Java']");
        public IWebElement checkBoxJava => driver.FindElement(javaCheckBoxXPath);

        private By qaCheckBoxXPath = By.XPath(".//*[@value='QA']");
        public IWebElement checkBoxQA => driver.FindElement(qaCheckBoxXPath);

        private By mobileCheckBoxXPath = By.XPath(".//*[@value='Mobile']");
        public IWebElement checkBoxMobileAndroid => driver.FindElement(mobileCheckBoxXPath);

        private By loginXPath = By.XPath(".//*[@name='login']");
        public IWebElement txtLogin => driver.FindElement(loginXPath);

        private By passwordXPath = By.XPath(".//*[@name='password']");
        public IWebElement txtPassword => driver.FindElement(passwordXPath);

        private By passwordconfirmXPath = By.XPath(".//*[@name='passwordConfirm']");
        public IWebElement txtPasswordConfirm => driver.FindElement(passwordconfirmXPath);

        private By createAccountButtonXPath = By.XPath(".//*[@type='submit']");
        public IWebElement buttonCreateAccount => driver.FindElement(createAccountButtonXPath);

        private By firstTermsAndConditionsCheckBoxXPath = By.XPath(".//*[@name='regulations']");
        public IWebElement firstTermsAndConditions => driver.FindElement(firstTermsAndConditionsCheckBoxXPath);

        private By secondTermsAndConditionsCheckBoxXPath = By.XPath(".//*[@name='information']");

        public IWebElement secondTermsAndConditions => driver.FindElement(secondTermsAndConditionsCheckBoxXPath);

        private By wrongEmailLabelXPath = By.XPath(".//*[contains(text(),'Niepoprawny adres e-mail')]");

        public IWebElement errorAboutEmailAdress => driver.FindElement(wrongEmailLabelXPath);

        private By wrongPhoneNumberLabelXPath = By.XPath(".//*[contains(text(),'Niepoprawny numer telefonu')]");

        public IWebElement errorAboutPhoneNumber => driver.FindElement(wrongPhoneNumberLabelXPath);

        private By wrongGithubLinkXPath = By.XPath(".//*[contains(text(),'To nie jest link do konta GitHub')]");
        public IWebElement errorAboutGithubLink => driver.FindElement(wrongGithubLinkXPath);

        private By wrongPasswordXPath = By.XPath(".//*[contains(text(),'Hasło musi mieć przynajmniej jedną dużą literę')]");
        public IWebElement errorAboutPassword => driver.FindElement(wrongPasswordXPath);

        private By wrongPasswordConfirmXPath = By.XPath(".//*[contains(text(),'Hasła nie zgadzają się')]");
        public IWebElement errorAboutPasswordConfirm => driver.FindElement(wrongPasswordConfirmXPath);

        private By tooShortFirstNameXPath = By.XPath(".//*[contains(text(),'Imię jest za krótkie')]");
        public IWebElement errorAboutTooShortFirstName => driver.FindElement(tooShortFirstNameXPath);

        private By tooShortLastNameXPath = By.XPath(".//*[contains(text(),'Nazwisko jest za krótkie')]");
        public IWebElement errorAboutTooShortLastName => driver.FindElement(tooShortLastNameXPath);

        private By tooShortLoginXPath = By.XPath(".//*[contains(text(),'Login jest za krótki')]");
        public IWebElement errorAboutTooShortLogin => driver.FindElement(tooShortLoginXPath);

        private By tooShortPasswordXPath = By.XPath(".//*[contains(text(),'Hasło jest za krótkie - min. 8 znaków')]");
        public IWebElement errorAboutTooShortPassword => driver.FindElement(tooShortPasswordXPath);

        private By tooLongFirstNameXPath = By.XPath(".//*[contains(text(),'Imię jest za długie')]");
        public IWebElement errorAboutTooLongFirstName => driver.FindElement(tooLongFirstNameXPath);

        private By tooLongLastNameXPath = By.XPath(".//*[contains(text(),'Nazwisko jest za długie')]");
        public IWebElement errorAboutTooLongLastName => driver.FindElement(tooLongLastNameXPath);

        private By tooLongLoginXPath = By.XPath(".//*[contains(text(),'Login jest za długi')]");
        public IWebElement errorAboutTooLongLogin => driver.FindElement(tooLongLoginXPath);

        private By tooLongPasswordXPath = By.XPath(".//*[contains(text(),'Hasło jest za długie - max. 20 znaków')]");
        public IWebElement errorAboutTooLongPassword => driver.FindElement(tooLongPasswordXPath);

        private By tooLongGithubLinkXPath = By.XPath(".//*[contains(text(),'To nie jest link do konta GitHub')]");
        public IWebElement errorAboutTooLongGithubLink => driver.FindElement(tooLongGithubLinkXPath);

        private By technologies = By.XPath(".//*[contains(text(),'Można wybrać tylko 3 technologie.')]");
        public IWebElement errorAboutTechnologies => driver.FindElement(technologies);

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
            txtFirstName.SendKeys("userEnteredTooLongUserFirstName");
        }

        public void RegistrationFormWithTooLongLastName()
        {
            txtFirstName.SendKeys("Jan");
            txtLastName.SendKeys("userEnteredTooLongUserLastNamee");
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