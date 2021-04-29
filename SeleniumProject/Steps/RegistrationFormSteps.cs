using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Drivers;
using SeleniumProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class RegistrationFormSteps
    {
        RegistrationFormPage registrationFormPage = new RegistrationFormPage();

        [Given(@"User fills data correctly")]
        public void GivenUserFillsDataCorrectly()
        {
            registrationFormPage.EnterFirstName("Jan");
        }
        
        [When(@"User clicks on the Załóż konto button")]
        public void WhenUserClicksOnTheZalozKontoButton()
        {

        }
        
        [Then(@"User should be on site about e-mail verification")]
        public void ThenUserShouldBeOnSiteAboutE_MailVerification()
        {

        }
    }
}
