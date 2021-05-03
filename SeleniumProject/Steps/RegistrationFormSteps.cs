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
            registrationFormPage.ClickTechnologies();
            registrationFormPage.ClickTermsAndConditions();
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
            registrationFormPage.ClickTermsAndConditions();
        }

        [Given(@"User fills all data")]
        public void GivenUserFillsAllData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.RegistrationFormWithData((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password, (string)data.passwordConfirm);
            registrationFormPage.ClickTechnologies();
        }

        [When(@"User clicks on next Numer telefonu")]
        public void WhenUserClicksOnNextNumerTelefonu()
        {
            registrationFormPage.ClickPhoneNumber();
        }

        [When(@"User clicks on next Github link")]
        public void WhenUserClicksOnNextGithubLink()
        {
            registrationFormPage.ClickGithubLink();
        }

        [When(@"User clicks on next Technologie")]
        public void WhenUserClicksOnNextTechnologie()
        {
            registrationFormPage.ClickTechnologies();
        }

        [When(@"User clicks on next Powtórz hasło")]
        public void WhenUserClicksOnNextPowtorzHaslo()
        {
            registrationFormPage.ClickPasswordConfirm();
        }

        [When(@"User clicks on next Regulamin")]
        public void WhenUserClicksOnNextRegulamin()
        {
            registrationFormPage.ClickTermsAndConditions();
        }

        [When(@"User clicks on next Hasło")]
        public void WhenUserClicksOnNextHaslo()
        {
            registrationFormPage.ClickPassword();
        }

        [When(@"User clicks on next Nazwisko")]
        public void WhenUserClicksOnNextNazwisko()
        {
            registrationFormPage.ClickLastName();
        }

        [When(@"User clicks on next Adres email")]
        public void WhenUserClicksOnNextAdresEmail()
        {
            registrationFormPage.ClickEmail();
        }

        [When(@"User clicks on Login field")]
        public void WhenUserDoesnTCheckFieldsAboutTechnologyGroups()
        {
            registrationFormPage.ClickLogin();
        }

        [When(@"User checks all fields about technologies grups")]
        public void WhenUserChecksAllFieldsAboutTechnologiesGrups()
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
            IWebElement errorAboutEmailAdress = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Niepoprawny adres e-mail')]"));

            Assert.That(errorAboutEmailAdress.Text, Is.("Niepoprawny adres e-mail"));
        }

        [Then(@"User should see that field Numer telefonu is incorrect")]
        public void ThenUserShouldSeeThatFieldNumerTelefonuIsIncorrect()
        {
            IWebElement errorAboutPhoneNumber = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Niepoprawny numer telefonu')]"));

            Assert.That(errorAboutPhoneNumber.Text, Is.EqualTo("Niepoprawny numer telefonu"));
        }

        [Then(@"User should see that field Github link is incorrect")]
        public void ThenUserShouldSeeThatFieldGithubLinkIsIncorrect()
        {       
            IWebElement errorAboutGithubLink = _webdriver.FindElement(By.XPath(".//*[contains(text(),'To nie jest link do konta GitHub')]"));

            Assert.That(errorAboutGithubLink.Text, Is.EqualTo("To nie jest link do konta GitHub"));
        }

        [Then(@"User should see that field Hasło is incorrect")]
        public void ThenUserShouldSeeThatFieldHasloIsIncorrect()
        {
            IWebElement errorAboutPassword = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Hasło musi mieć przynajmniej jedną dużą literę')]"));

            Assert.That(errorAboutPassword.Text, Is.EqualTo("Hasło musi mieć przynajmniej jedną dużą literę"));
        }

        [Then(@"User should see that field Powtórz hasło is incorrect")]
        public void ThenUserShouldSeeThatFieldPowtorzHasloIsIncorrect()
        {
            IWebElement errorAboutPasswordConfirm = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Hasła nie zgadzają się')]"));

            Assert.That(errorAboutPasswordConfirm.Text, Is.EqualTo("Hasła nie zgadzają się"));
        }

        [Then(@"User should see error message about too short Numer telefonu")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortNumerTelefonu()
        {
            IWebElement errorAboutPhoneNumber = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Niepoprawny numer telefonu')]"));

            Assert.That(errorAboutPhoneNumber.Text, Is.EqualTo("Niepoprawny numer telefonu"));
        }

        [Then(@"User should see error message about too short Login")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortLogin()
        {           
            IWebElement errorAboutLogin = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Login jest za krótki')]"));

            Assert.That(errorAboutLogin.Text, Is.EqualTo("Login jest za krótki"));
        }

        [Then(@"User should see error message about too short Hasło")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortHaslo()
        {
            IWebElement errorAboutPassword = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Hasło jest za krótkie - min. 8 znaków')]"));

            Assert.That(errorAboutPassword.Text, Is.EqualTo("Hasło jest za krótkie - min. 8 znaków"));
        }

        [Then(@"User should see error message about too long Imie")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongImie()
        {
            IWebElement errorAboutTooLongFirstName = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Imię jest za długie')]"));

            Assert.That(errorAboutTooLongFirstName.Text, Is.EqualTo("Imię jest za długie"));
        }

        [Then(@"User should see error message about too long Nazwisko")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongNazwisko()
        {
            IWebElement errorAboutTooLongLastName = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Nazwisko jest za długie')]"));

            Assert.That(errorAboutTooLongLastName.Text, Is.EqualTo("Nazwisko jest za długie"));
        }

        [Then(@"User should see error message about too long Numer telefonu")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongNumerTelefonu()
        {
            IWebElement errorAboutTooLongPhoneNumber = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Niepoprawny numer telefonu')]"));

            Assert.That(errorAboutTooLongPhoneNumber.Text, Is.EqualTo("Niepoprawny numer telefonu"));
        }

        [Then(@"User should see error message about too long Login")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongLogin()
        {
            IWebElement errorAboutTooLongLogin = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Login jest za długi')]"));

            Assert.That(errorAboutTooLongLogin.Text, Is.EqualTo("Login jest za długi"));
        }

        [Then(@"User should see error message about unchecked technology groups")]
        public void ThenUserShouldSeeErrorMessageAboutUncheckedTechnologyGroups()
        {
            IWebElement errorAboutTechnologies = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Musisz wybrać przynajmniej jedną technologię.')]"));

            Assert.That(errorAboutTechnologies.Text, Is.EqualTo("Musisz wybrać przynajmniej jedną technologię."));
        }

        [Then(@"User should see error message about checked too many technology groups")]
        public void ThenUserShouldSeeErrorMessageAboutCheckedTooManyTechnologyGroups()
        {
            IWebElement errorAboutTechnologies = _webdriver.FindElement(By.XPath(".//*[contains(text(),'Można wybrać tylko 3 technologie.')]"));

            Assert.That(errorAboutTechnologies.Text, Is.EqualTo("Można wybrać tylko 3 technologie."));
        }
    }
}
