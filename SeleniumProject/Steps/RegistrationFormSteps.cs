using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumProject.Steps
{
    [Binding]
    public class RegistrationFormSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly RegistrationFormPage registrationFormPage;

        public RegistrationFormSteps(IWebDriver driver)
        {
            _webdriver = driver;
            _webdriver.Url = _webdriver.Url + "rejestracja";
            registrationFormPage = new RegistrationFormPage(_webdriver);
        }

        [Given(@"User fills data correctly")]
        public void GivenUserFillsDataCorrectly(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithData((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password, (string)data.passwordConfirm);
            registrationFormPage.checkBoxJavaScript.Click();
            registrationFormPage.checkBoxTermsAndConditions.Click();
        }

        [Given(@"User doesn't fill data")]
        public void GivenUserDoesnTFillData()
        {
            registrationFormPage.RegistrationFormWithoutData();
        }

        [Given(@"User fills Adres email incorrect")]
        public void GivenUserFillsAdresEmailIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithIncorrectEmail((string)data.firstName, (string)data.lastName);
        }

        [Given(@"User fills Numer telefonu incorrect")]
        public void GivenUserFillsNumerTelefonuIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithIncorrectPhoneNumber((string)data.firstName, (string)data.lastName, (string)data.email);
        }

        [Given(@"User fills Github link incorrect")]
        public void GivenUserFillsGithubLinkIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithIncorrectGithubLink((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone);
        }

        [Given(@"User fills Hasło incorrect")]
        public void GivenUserFillsHasloIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithIncorrectPassword((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login);
        }

        [Given(@"User fills Powtórz hasło incorrect")]
        public void GivenUserFillsPowtorzHasloIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithIncorrectPasswordConfirm((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password);
        }

        [Given(@"User fills too short Imię")]
        public void GivenUserFillsTooShortImie(Table table)
        {
            registrationFormPage.RegistrationFormWithTooShortImie();          
        }

        [Given(@"User fills too short Nazwisko")]
        public void GivenUserFillsTooShortNazwisko(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithTooShortNazwisko((string)data.firstName);
        }

        [Given(@"User fills too short Numer telefonu")]
        public void GivenUserFillsTooShortNumerTelefonu(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithTooShortPhoneNumber((string)data.firstName, (string)data.lastName, (string)data.email);
        }

        [Given(@"User fills too short Login")]
        public void GivenUserFillsTooShortLogin(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithTooShortLogin((string)data.firstName, (string)data.lastName, (string)data.email, (string)data.githubLink);
        }

        [Given(@"User fills too short Hasło")]
        public void GivenUserFillsTooShortHaslo(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithTooShortHasło((string)data.firstName, (string)data.lastName, (string)data.email, (string)data.githubLink);
        }

        [Given(@"User fills too long Imie")]
        public void GivenUserFillsTooLongImie()
        {
            registrationFormPage.RegistrationFormWithTooLongFirstName();
        }

        [Given(@"User fills too long Nazwisko")]
        public void GivenUserFillsTooLongNazwisko()
        {
            registrationFormPage.RegistrationFormWithTooLongLastName();
        }

        [Given(@"User fills too long Numer telefonu")]
        public void GivenUserFillsTooLongNumerTelefonu()
        {
            registrationFormPage.RegistrationFormWithTooLongPhoneNumber();
        }

        [Given(@"User fills too long Login")]
        public void GivenUserFillsTooLongLogin()
        {
            registrationFormPage.RegistrationFormWithTooLongLogin();
        }

        [Given(@"User fills too long Hasło")]
        public void GivenUserFillsTooLongHaslo()
        {
            registrationFormPage.RegistrationFormWithTooLongHaslo();
        }

        [Given(@"User fills too long Githublink")]
        public void GivenUserFillsTooLongGithublink()
        {
            registrationFormPage.RegistrationFormWithTooLongHaslo();
        }

        [Given(@"User fills data which is before technologies field")]
        public void GivenUserFillsRequiredData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWtihoutTechnologies((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink);
        }

        [Given(@"User fills all data without technologies")]
        public void GivenUserFillsDataInTextFields(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithData((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password, (string)data.passwordConfirm);
            registrationFormPage.checkBoxJavaScript.Click();
            registrationFormPage.checkBoxTermsAndConditions.Click();
        }

        [Given(@"User fills all data")]
        public void GivenUserFillsAllData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithData((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password, (string)data.passwordConfirm);
            registrationFormPage.checkBoxJavaScript.Click();
        }

        [When(@"User clicks on next Numer telefonu")]
        public void WhenUserClicksOnNextNumerTelefonu()
        {
            registrationFormPage.txtPhone.Click();
        }

        [When(@"User clicks on next Github link")]
        public void WhenUserClicksOnNextGithubLink()
        {
            registrationFormPage.txtGithubLink.Click();
        }

        [When(@"User clicks on next Technologie")]
        public void WhenUserClicksOnNextTechnologie()
        {
            registrationFormPage.checkBoxJavaScript.Click();
        }

        [When(@"User clicks on next Powtórz hasło")]
        public void WhenUserClicksOnNextPowtorzHaslo()
        {
            registrationFormPage.txtPasswordConfirm.Click();
        }

        [When(@"User clicks on next Regulamin")]
        public void WhenUserClicksOnNextRegulamin()
        {
            registrationFormPage.checkBoxTermsAndConditions.Click();
        }

        [When(@"User clicks on next Hasło")]
        public void WhenUserClicksOnNextHaslo()
        {
            registrationFormPage.txtPassword.Click();
        }

        [When(@"User clicks on next Nazwisko")]
        public void WhenUserClicksOnNextNazwisko()
        {
            registrationFormPage.txtLastName.Click();
        }

        [When(@"User clicks on next Adres email")]
        public void WhenUserClicksOnNextAdresEmail()
        {
            registrationFormPage.txtEmail.Click();
        }

        [When(@"User clicks on Login field")]
        public void WhenUserDoesnTCheckFieldsAboutTechnologyGroups()
        {
            registrationFormPage.txtLogin.Click();
        }

        [When(@"User checks all fields about technologies groups")]
        public void WhenUserChecksAllFieldsAboutTechnologiesGroups()
        {
            registrationFormPage.ChecksAllTechnologies();
        }

        [When(@"User checks three technologies groups")]
        public void WhenUserChecksThreeTechnologiesGroups()
        {
            registrationFormPage.CheckMaxTechnologiesFields();
        }

        [When(@"Users doesn't check field Regulamin")]
        public void WhenUsersDoesnTCheckFieldRegulamin()
        {
            By termsAndConditions = By.XPath(".//*[@name='regulations']");
            IWebElement isSelected = _webdriver.FindElement(termsAndConditions);
            if (isSelected.Selected)
                isSelected.Click();
        }

        [Then(@"Button Załóż konto is active")]
        public void ThenUserShouldBeOnSiteAboutE_MailVerification()
        {
            Assert.That(registrationFormPage.CreateAccountButtonIsActiveOrNot(), Is.True);
        }

        [Then(@"Button Załóż konto is inactive")]
        public void ThenUserCanTClickOnTheButtonZalozKonto()
        {
            Assert.That(registrationFormPage.CreateAccountButtonIsActiveOrNot(), Is.False);
        }

        [Then(@"User should see that field Adres email is incorrect")]
        public void ThenUserShouldSeeThatFieldAdresEmailIsIncorrect()
        {
            By email = By.XPath(".//*[contains(text(),'Niepoprawny adres e-mail')]");
            IWebElement errorAboutEmailAdress = _webdriver.FindElement(email);

            Assert.AreEqual(true, errorAboutEmailAdress.Displayed);
        }

        [Then(@"User should see that field Numer telefonu is incorrect")]
        public void ThenUserShouldSeeThatFieldNumerTelefonuIsIncorrect()
        {
            By phoneNumber = By.XPath(".//*[contains(text(),'Niepoprawny numer telefonu')]");
            IWebElement errorAboutPhoneNumber = _webdriver.FindElement(phoneNumber);

            Assert.AreEqual(true, errorAboutPhoneNumber.Displayed);
        }

        [Then(@"User should see that field Github link is incorrect")]
        public void ThenUserShouldSeeThatFieldGithubLinkIsIncorrect()
        {
            By githubLink = By.XPath(".//*[contains(text(),'To nie jest link do konta GitHub')]");
            IWebElement errorAboutGithubLink = _webdriver.FindElement(githubLink);

            Assert.AreEqual(true, errorAboutGithubLink.Displayed);
        }

        [Then(@"User should see that field Hasło is incorrect")]
        public void ThenUserShouldSeeThatFieldHasloIsIncorrect()
        {
            By password = By.XPath(".//*[contains(text(),'Hasło musi mieć przynajmniej jedną dużą literę')]");
            IWebElement errorAboutPassword = _webdriver.FindElement(password);

            Assert.AreEqual(true, errorAboutPassword.Displayed);
        }

        [Then(@"User should see that field Powtórz hasło is incorrect")]
        public void ThenUserShouldSeeThatFieldPowtorzHasloIsIncorrect()
        {
            By passwordConfirm = By.XPath(".//*[contains(text(),'Hasła nie zgadzają się')]");
            IWebElement errorAboutPasswordConfirm = _webdriver.FindElement(passwordConfirm);

            Assert.AreEqual(true, errorAboutPasswordConfirm.Displayed);
        }

        [Then(@"User should see error message about too short Imię")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortImie()
        {
            By firstName = By.XPath(".//*[contains(text(),'Imię jest za krótkie')]");
            IWebElement errorAboutFirstName = _webdriver.FindElement(firstName);

            Assert.AreEqual(true, errorAboutFirstName.Displayed);
        }

        [Then(@"User should see error message about too short Nazwisko")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortNazwisko()
        {
            By lastName = By.XPath(".//*[contains(text(),'Nazwisko jest za krótkie')]");
            IWebElement errorAboutLastName = _webdriver.FindElement(lastName);

            Assert.AreEqual(true, errorAboutLastName.Displayed);
        }

        [Then(@"User should see error message about too short Numer telefonu")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortNumerTelefonu()
        {
            By phoneNumber = By.XPath(".//*[contains(text(),'Niepoprawny numer telefonu')]");
            IWebElement errorAboutPhoneNumber = _webdriver.FindElement(phoneNumber);

            Assert.AreEqual(true, errorAboutPhoneNumber.Displayed);
        }

        [Then(@"User should see error message about too short Login")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortLogin()
        {
            By login = By.XPath(".//*[contains(text(),'Login jest za krótki')]");
            IWebElement errorAboutLogin = _webdriver.FindElement(login);

            Assert.AreEqual(true, errorAboutLogin.Displayed);
        }

        [Then(@"User should see error message about too short Hasło")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortHaslo()
        {
            By password = By.XPath(".//*[contains(text(),'Hasło jest za krótkie - min. 8 znaków')]");
            IWebElement errorAboutPassword = _webdriver.FindElement(password);

            Assert.AreEqual(true, errorAboutPassword.Displayed);
        }

        [Then(@"User should see error message about too long Imie")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongImie()
        {
            By firstName = By.XPath(".//*[contains(text(),'Imię jest za długie')]");
            IWebElement errorAboutTooLongFirstName = _webdriver.FindElement(firstName);

            Assert.AreEqual(true, errorAboutTooLongFirstName.Displayed);
        }

        [Then(@"User should see error message about too long Nazwisko")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongNazwisko()
        {
            By lastName = By.XPath(".//*[contains(text(),'Nazwisko jest za długie')]");
            IWebElement errorAboutTooLongLastName = _webdriver.FindElement(lastName);

            Assert.AreEqual(true, errorAboutTooLongLastName.Displayed);
        }

        [Then(@"User should see error message about too long Numer telefonu")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongNumerTelefonu()
        {
            By phoneNumber = By.XPath(".//*[contains(text(),'Niepoprawny numer telefonu')]");
            IWebElement errorAboutTooLongPhoneNumber = _webdriver.FindElement(phoneNumber);

            Assert.AreEqual(true, errorAboutTooLongPhoneNumber.Displayed);
        }

        [Then(@"User should see error message about too long Login")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongLogin()
        {
            By login = By.XPath(".//*[contains(text(),'Login jest za długi')]");
            IWebElement errorAboutTooLongLogin = _webdriver.FindElement(login);

            Assert.AreEqual(true, errorAboutTooLongLogin.Displayed);
        }

        [Then(@"User should see error message about too long Hasło")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongHaslo()
        {
            By password = By.XPath(".//*[contains(text(),'Hasło jest za długie - max. 20 znaków')]");
            IWebElement errorAboutTooLongPassword = _webdriver.FindElement(password);

            Assert.AreEqual(true, errorAboutTooLongPassword.Displayed);
        }

        [Then(@"User should see error message about too long Githublink")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongGithublink()
        {
            By githubLink = By.XPath(".//*[contains(text(),'To nie jest link do konta GitHub')]");
            IWebElement errorAboutTooLongGithubLink = _webdriver.FindElement(githubLink);

            Assert.AreEqual(true, errorAboutTooLongGithubLink.Displayed);
        }

        [Then(@"User should see error message about checked too many technology groups")]
        public void ThenUserShouldSeeErrorMessageAboutCheckedTooManyTechnologyGroups()
        {
            By technologies = By.XPath(".//*[contains(text(),'Można wybrać tylko 3 technologie.')]");
            IWebElement errorAboutTechnologies = _webdriver.FindElement(technologies);

            Assert.AreEqual(true, errorAboutTechnologies.Displayed);
        }
    }
}