using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    [Scope(Feature = "Verification of email address")]
    public class VerificationOfEmailAddressSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly VerificationOfEmailAddressPage verificationOfEmailAddressPage;

        public VerificationOfEmailAddressSteps(IWebDriver driver)
        {
            _webdriver = driver;
            verificationOfEmailAddressPage = new VerificationOfEmailAddressPage(_webdriver);
        }

        [Given(@"User proceeds with registration via email verification page")]
        public void GivenUserProceedsWithRegistrationViaEmailVerificationPage()
        {
            _webdriver.Url = _webdriver.Url + "weryfikacja";
        }        
        
        [Given(@"User has correct code")]
        public void GivenUserHasCorrectCode()
        {
            Assert.Ignore("manual test");
        }        
        
        [Given(@"User already used code")]
        public void GivenUserAlreadyUsedCode()
        {
            Assert.Ignore("manual test");
        }
        
        [Given(@"activated account")]
        public void GivenActivatedAccount()
        {
            Assert.Ignore("manual test");
        }
        
        [Given(@"User(.*) has code")]
        public void GivenUserHasCode(int p0)
        {
            Assert.Ignore("manual test");
        }
        
        [Given(@"User(.*) fills in the registration form")]
        public void GivenUserFillsInTheRegistrationForm(int p0)
        {
            Assert.Ignore("manual test");
        }
        
        [When(@"User enters the code")]
        public void WhenUserEntersTheCode()
        {
            Assert.Ignore("manual test");
        }

        [When(@"User clicks Nie otrzymałem/am kodu")]
        public void WhenUserClicksNieOtrzymalemAmKodu()
        {
            Assert.Ignore("manual test");
        }

        [When(@"User clicks Zatwierdź kod button")]
        public void WhenUserClicksZatwierdzKodButton()
        {
            Assert.Ignore("manual test");
            IWebElement confirmationButton = _webdriver.FindElement(By.XPath("//*[text()[contains(.,'Zatwierdź kod')]]"));
        }

        [When(@"User enters code (.*)")]
        public void WhenUserEntersCode(int p0)
        {
            IWebElement codePlaceHolder = _webdriver.FindElement(By.XPath("//*[@id='outlined-adornment-password']"));
            codePlaceHolder.SendKeys(int p0);
        }
        
        [When(@"User tries to activate again with the same code")]
        public void WhenUserTriesToActivateAgainWithTheSameCode()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User(.*) click ""(.*)""")]
        public void WhenUserClick(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User enters code '(.*)'")]
        public void WhenUserEntersCode(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User enters (.*)")]
        public void WhenUserEnters(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User sees Twoja rejestracja przebiegła pomyślnie!")]
        public void ThenUserSeesTwojaRejestracjaPrzebieglaPomyslnie()
        {
            Assert.Ignore("manual test");
        }

        [Then(@"User receives code")]
        public void ThenUserReceivesCode()
        {
            Assert.Ignore("manual test");
        }

        [Then(@"User sees Wprowadzony kod jest niepoprawny")]
        public void ThenUserSeesWprowadzonyKodJestNiepoprawny()
        {
            IWebElement wrongCode =_webdriver.FindElement(By.XPath())
        }


        [Then(@"is not able to click '(.*)' button")]
        public void ThenIsNotAbleToClickButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Code of User(.*) should be different from code of User(.*)")]
        public void ThenCodeOfUserShouldBeDifferentFromCodeOfUser(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User should see message about sending new code")]
        public void ThenUserShouldSeeMessageAboutSendingNewCode()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
