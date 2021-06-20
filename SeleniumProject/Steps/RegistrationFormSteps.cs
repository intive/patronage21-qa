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
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithData((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password, (string)data.passwordConfirm);
            registrationFormPage.checkBoxJavaScript.Click();
            registrationFormPage.firstTermsAndConditions.Click();
            registrationFormPage.secondTermsAndConditions.Click();
        }

        [Given(@"User doesn't fill data")]
        public void GivenUserDoesnTFillData()
        {
            registrationFormPage.titleListBox.Click();
            registrationFormPage.RegistrationFormWithoutData();
        }

        [Given(@"User fills Tytuł incorrect")]
        public void GivenUserFillsTytulIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.titleListBox.Click();
        }

        [Given(@"User fills Adres email incorrect")]
        public void GivenUserFillsAdresEmailIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithIncorrectEmail((string)data.firstName, (string)data.lastName);
        }

        [Given(@"User fills Numer telefonu incorrect")]
        public void GivenUserFillsNumerTelefonuIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithIncorrectPhoneNumber((string)data.firstName, (string)data.lastName, (string)data.email);
        }

        [Given(@"User fills Github link incorrect")]
        public void GivenUserFillsGithubLinkIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithIncorrectGithubLink((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone);
        }

        [Given(@"User fills Hasło incorrect")]
        public void GivenUserFillsHasloIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithIncorrectPassword((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login);
        }

        [Given(@"User fills Powtórz hasło incorrect")]
        public void GivenUserFillsPowtorzHasloIncorrect(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithIncorrectPasswordConfirm((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password);
        }

        [Given(@"User fills too short Imię")]
        public void GivenUserFillsTooShortImie(Table table)
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooShortImie();          
        }

        [Given(@"User fills too short Nazwisko")]
        public void GivenUserFillsTooShortNazwisko(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooShortNazwisko((string)data.firstName);
        }

        [Given(@"User fills too short Numer telefonu")]
        public void GivenUserFillsTooShortNumerTelefonu(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooShortPhoneNumber((string)data.firstName, (string)data.lastName, (string)data.email);
        }

        [Given(@"User fills too short Login")]
        public void GivenUserFillsTooShortLogin(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooShortLogin((string)data.firstName, (string)data.lastName, (string)data.email, (string)data.githubLink);
        }

        [Given(@"User fills too short Hasło")]
        public void GivenUserFillsTooShortHaslo(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooShortHasło((string)data.firstName, (string)data.lastName, (string)data.email, (string)data.githubLink);
        }

        [Given(@"User fills too long Imie")]
        public void GivenUserFillsTooLongImie()
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooLongFirstName();
        }

        [Given(@"User fills too long Nazwisko")]
        public void GivenUserFillsTooLongNazwisko()
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooLongLastName();
        }

        [Given(@"User fills too long Numer telefonu")]
        public void GivenUserFillsTooLongNumerTelefonu()
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooLongPhoneNumber();
        }

        [Given(@"User fills too long Login")]
        public void GivenUserFillsTooLongLogin()
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooLongLogin();
        }

        [Given(@"User fills too long Hasło")]
        public void GivenUserFillsTooLongHaslo()
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooLongHaslo();
        }

        [Given(@"User fills too long Githublink")]
        public void GivenUserFillsTooLongGithublink()
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithTooLongGithubLink();
        }

        [Given(@"User fills data which is before technologies field")]
        public void GivenUserFillsRequiredData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWtihoutTechnologies((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink);
        }

        [Given(@"User fills all data without technologies")]
        public void GivenUserFillsDataInTextFields(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithData((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password, (string)data.passwordConfirm);
            registrationFormPage.checkBoxJavaScript.Click();
            registrationFormPage.firstTermsAndConditions.Click();
            registrationFormPage.secondTermsAndConditions.Click();
        }

        [Given(@"User fills all data")]
        public void GivenUserFillsAllData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithData((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone,
                (string)data.githubLink, (string)data.login, (string)data.password, (string)data.passwordConfirm);
            registrationFormPage.checkBoxJavaScript.Click();
        }

        [When(@"User clicks on next Imię")]
        public void WhenUserClicksOnNextImie()
        {
            registrationFormPage.txtFirstName.Click();
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
            registrationFormPage.firstTermsAndConditions.Click();
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

        [When(@"User clicks on next Login")]
        public void WhenUserClicksOnNextLogin()
        {
            registrationFormPage.txtLogin.Click();
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

        [When(@"Users doesn't check fields about terms and conditions")]
        public void WhenUsersDoesnTCheckFieldRegulamin()
        {
            Assert.AreEqual(registrationFormPage.firstTermsAndConditions.Selected, false);
            Assert.AreEqual(registrationFormPage.secondTermsAndConditions.Selected, false);
        }

        [Then(@"Button Załóż konto is active")]
        public void ThenUserShouldBeOnSiteAboutE_MailVerification()
        {
            Assert.That(registrationFormPage.buttonCreateAccount.Enabled, Is.True);
        }

        [Then(@"Button Załóż konto is inactive")]
        public void ThenUserCanTClickOnTheButtonZalozKonto()
        {
            Assert.That(registrationFormPage.buttonCreateAccount.Enabled, Is.False);
        }

        [Then(@"User should see that field Tytuł is incorrect")]
        public void ThenUserShouldSeeThatFieldTytulIsIncorrect()
        {
            Assert.AreEqual(true, registrationFormPage.errorMessageAboutTitle.Displayed);
        }

        [Then(@"User should see that field Adres email is incorrect")]
        public void ThenUserShouldSeeThatFieldAdresEmailIsIncorrect()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutEmailAdress.Displayed);
        }

        [Then(@"User should see that field Numer telefonu is incorrect")]
        public void ThenUserShouldSeeThatFieldNumerTelefonuIsIncorrect()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutPhoneNumber.Displayed);
        }

        [Then(@"User should see that field Github link is incorrect")]
        public void ThenUserShouldSeeThatFieldGithubLinkIsIncorrect()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutGithubLink.Displayed);
        }

        [Then(@"User should see that field Hasło is incorrect")]
        public void ThenUserShouldSeeThatFieldHasloIsIncorrect()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutPassword.Displayed);
        }

        [Then(@"User should see that field Powtórz hasło is incorrect")]
        public void ThenUserShouldSeeThatFieldPowtorzHasloIsIncorrect()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutPasswordConfirm.Displayed);
        }

        [Then(@"User should see error message about too short Imię")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortImie()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooShortFirstName.Displayed);
        }

        [Then(@"User should see error message about too short Nazwisko")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortNazwisko()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooShortLastName.Displayed);
        }

        [Then(@"User should see error message about too short Numer telefonu")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortNumerTelefonu()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutPhoneNumber.Displayed);
        }

        [Then(@"User should see error message about too short Login")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortLogin()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooShortLogin.Displayed);
        }

        [Then(@"User should see error message about too short Hasło")]
        public void ThenUserShouldSeeErrorMessageAboutTooShortHaslo()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooShortPassword.Displayed);
        }

        [Then(@"User should see error message about too long Imie")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongImie()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooLongFirstName.Displayed);
        }

        [Then(@"User should see error message about too long Nazwisko")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongNazwisko()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooLongLastName.Displayed);
        }

        [Then(@"User should see error message about too long Numer telefonu")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongNumerTelefonu()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutPhoneNumber.Displayed);
        }

        [Then(@"User should see error message about too long Login")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongLogin()
        { 
            Assert.AreEqual(true, registrationFormPage.errorAboutTooLongLogin.Displayed);
        }

        [Then(@"User should see error message about too long Hasło")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongHaslo()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooLongPassword.Displayed);
        }

        [Then(@"User should see error message about too long Githublink")]
        public void ThenUserShouldSeeErrorMessageAboutTooLongGithublink()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTooLongGithubLink.Displayed);
        }

        [Then(@"User should see error message about checked too many technology groups")]
        public void ThenUserShouldSeeErrorMessageAboutCheckedTooManyTechnologyGroups()
        {
            Assert.AreEqual(true, registrationFormPage.errorAboutTechnologies.Displayed);
        }
    }
}