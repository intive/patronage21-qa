using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumProject.Steps
{
    [Binding]
    public class RegistrationFormEmailVerificationSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly RegistrationFormEmailVerificationPage registrationFormEmailVerificationPage;
        private readonly BasePage basePage;
        private string verificationLink, registrationLink;
        
        public RegistrationFormEmailVerificationSteps(IWebDriver driver)
        {
            _webdriver = driver;
            registrationFormEmailVerificationPage = new RegistrationFormEmailVerificationPage(_webdriver);
            basePage = new BasePage(_webdriver);
            verificationLink = _webdriver.Url + "weryfikacja";
            registrationLink = _webdriver.Url + "rejestracja";
        }

        [Given(@"User proceeds with registration via email verification page")]
        public void GivenUserProceedsWithRegistrationViaEmailVerificationPage()
        {
            _webdriver.Url = verificationLink;
        }

        [Given(@"User enters data")]
        public void GivenUserEntersData(Table table)
        {
            _webdriver.Url = registrationLink;

            dynamic data = table.CreateDynamicInstance();

            
            registrationFormEmailVerificationPage.title.Click();
            registrationFormEmailVerificationPage.gender.Click();
            registrationFormEmailVerificationPage.firstName.SendKeys(data.firstName);
            registrationFormEmailVerificationPage.lastName.SendKeys(data.lastName);
            registrationFormEmailVerificationPage.email.SendKeys(RegistrationFormEmailVerificationPage.GenerateEmailAdress());
            registrationFormEmailVerificationPage.phone.SendKeys(data.phone.ToString());
            registrationFormEmailVerificationPage.githubLink.SendKeys(RegistrationFormEmailVerificationPage.GenerateGithubLink());
            registrationFormEmailVerificationPage.login.SendKeys(RegistrationFormEmailVerificationPage.GenerateLogin());
            registrationFormEmailVerificationPage.password.SendKeys(data.password);
            registrationFormEmailVerificationPage.passwordConfirm.SendKeys(data.passwordConfirm);
            registrationFormEmailVerificationPage.checkBoxQA.Click();
            registrationFormEmailVerificationPage.checkBoxTermsAndConditions.Click();
            registrationFormEmailVerificationPage.checkBoxInformation.Click();
        }

        [Given(@"is transferred to verification site")]
        public void GivenIsTransferredToVerificationSite()
        {
            registrationFormEmailVerificationPage.zalozKontoButton.Click();
        }

        [When(@"User enters code '(.*)'")]
        public void WhenUserEntersCode(string number)
        {
            registrationFormEmailVerificationPage.codeInput.SendKeys(number);
        }

        [When(@"User clicks Nie otrzymałem/am kodu button")]
        public void WhenUserClicksNieOtrzymalemKoduButton()
        {
            registrationFormEmailVerificationPage.renewalSentButton.Click();
        }

        [When(@"User enters (.*)")]
        public void WhenUserEnters(string characters, Table table)
        {
            registrationFormEmailVerificationPage.codeInput.SendKeys(characters);
        }

        [Then(@"User sees '(.*)'")]
        public void ThenUserSees(string text)
        {
            Assert.AreEqual(true, registrationFormEmailVerificationPage.getErrorMessage(text).Displayed);
        }

        [Then(@"is not able to click '(.*)' button")]
        public void ThenIsNotAbleToClickButton(string buttonName)
        {
            basePage.buttonName = buttonName;
            Assert.That(basePage.buttonCommon.Enabled, Is.False);
        }
    }
}