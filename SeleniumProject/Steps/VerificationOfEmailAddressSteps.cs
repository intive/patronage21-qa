using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumProject.Steps
{
    [Binding]
    public class VerificationOfEmailAddressSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly VerificationOfEmailAddressPage verificationOfEmailAddressPage;
        private readonly BasePage basePage;

        public VerificationOfEmailAddressSteps(IWebDriver driver)
        {
            _webdriver = driver;
            verificationOfEmailAddressPage = new VerificationOfEmailAddressPage(_webdriver);
            basePage = new BasePage(_webdriver);
        }

        [Given(@"User proceeds with registration via email verification page")]
        public void GivenUserProceedsWithRegistrationViaEmailVerificationPage()
        {
            _webdriver.Url = _webdriver.Url + "weryfikacja";
        }

        [Given(@"User enters data")]
        public void GivenUserEntersData(Table table)
        {
            _webdriver.Url = "http://localhost:3000/rejestracja";

            dynamic data = table.CreateDynamicInstance();

            verificationOfEmailAddressPage.firstName.SendKeys(data.firstName);
            verificationOfEmailAddressPage.lastName.SendKeys(data.lastName);
            verificationOfEmailAddressPage.email.SendKeys(VerificationOfEmailAddressPage.GenerateEmailAdress());
            verificationOfEmailAddressPage.phone.SendKeys(data.phone.ToString());
            verificationOfEmailAddressPage.githubLink.SendKeys(VerificationOfEmailAddressPage.GenerateGithubLink());
            verificationOfEmailAddressPage.login.SendKeys(VerificationOfEmailAddressPage.GenerateLogin());
            verificationOfEmailAddressPage.password.SendKeys(data.password);
            verificationOfEmailAddressPage.passwordConfirm.SendKeys(data.passwordConfirm);
            verificationOfEmailAddressPage.checkBoxQA.Click();
            verificationOfEmailAddressPage.checkBoxTermsAndConditions.Click();
            verificationOfEmailAddressPage.checkBoxInformation.Click();
        }

        [Given(@"is transferred to verification site")]
        public void GivenIsTransferredToVerificationSite()
        {
            verificationOfEmailAddressPage.zalozKontoButton.Click();
        }

        [When(@"User enters code '(.*)'")]
        public void WhenUserEntersCode(string p0)
        {
            verificationOfEmailAddressPage.codeInput.SendKeys(p0);
        }

        [When(@"User clicks Nie otrzymałem/am kodu button")]
        public void WhenUserClicksNieOtrzymalemKoduButton()
        {
            verificationOfEmailAddressPage.renewalSentButton.Click();
        }

        [When(@"User enters (.*)")]
        public void WhenUserEnters(string p0, Table table)
        {
            verificationOfEmailAddressPage.codeInput.SendKeys(p0);
        }

        [Then(@"User sees '(.*)'")]
        public void ThenUserSees(string p0)
        {
            Assert.AreEqual(true, verificationOfEmailAddressPage.getErrorMessage(p0).Displayed);
        }

        [Then(@"is not able to click '(.*)' button")]
        public void ThenIsNotAbleToClickButton(string buttonName)
        {
            basePage.buttonName = buttonName;
            Assert.That(basePage.buttonCommon.Enabled, Is.False);
        }
    }
}