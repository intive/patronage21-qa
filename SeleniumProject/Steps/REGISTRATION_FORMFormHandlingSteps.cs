using OpenQA.Selenium;
using SeleniumProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class REGISTRATION_FORMFormHandlingSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly RegistrationFormPage registrationFormPage;
        Random rand = new Random();

        public REGISTRATION_FORMFormHandlingSteps(IWebDriver driver)
        {
            _webdriver = driver;
            registrationFormPage = new RegistrationFormPage(_webdriver);

        }
        [Given(@"The user is on the registration page")]

        public void GivenTheUserIsOnTheRegistrationPage()
        {
            _webdriver.Url = _webdriver.Url + "rejestracja";
        }
        [Given(@"The user fills the form by correct details")]
        public void GivenTheUserFillsTheFormByCorrectDetails()
        {
            registrationFormPage.ChooseUserTitle();
            registrationFormPage.RegistrationFormWithData("Jan", "Nowak", "jan.kowalki@gmail.com", 123456789, "github.com/examppleSuser12", "login" + $"{rand.Next(0, 100000)}", "Example@06", "Example@06");
            registrationFormPage.checkBoxJavaScript.Click();
            registrationFormPage.firstTermsAndConditions.Click();
            registrationFormPage.secondTermsAndConditions.Click();

        }

        [When(@"The user clicks button '(.*)'")]
        public void WhenTheUserClicksButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Response is successful")]
        public void ThenResponseIsSuccessful()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The user is redirected to the site '(.*)'")]
        public void ThenTheUserIsRedirectedToTheSite(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
