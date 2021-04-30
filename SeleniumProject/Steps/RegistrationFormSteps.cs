using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject.Drivers;
using SeleniumProject.Pages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumProject.Steps
{
    [Binding]
    public class RegistrationFormSteps : DriverHelper
    {
        RegistrationFormPage registrationFormPage = new RegistrationFormPage();

        [Given(@"Users is on site about registration form")]
        public void GivenUsersIsOnSiteAboutRegistrationForm()
        {

        }

        [Given(@"User fills data correctly")]
        public void GivenUserFillsDataCorrectly(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            registrationFormPage.EnterDataIntoForm((string)data.firstName, (string)data.lastName, (string)data.email, (int)data.phone, (string)data.githubLink, (string)data.technologies, (string)data.login, (string)data.password, (string)data.passwordConfirm);
        }

        [Given(@"User doesn't fill data")]
        public void GivenUserDoesnTFillData()
        {
            registrationFormPage.EnterDataIntoForm("","","", null,"","","","","");
        }

        [Then(@"User can click on the button Załóż konto")]
        public void ThenUserShouldBeOnSiteAboutE_MailVerification()
        {
            Assert.That(registrationFormPage.ButtonCreateAccountIsActiveOrNot(), Is.True);
        }

        [Then(@"User can't click on the button Załóż konto")]
        public void ThenUserCanTClickOnTheButtonZalozKonto()
        {
            Assert.That(registrationFormPage.ButtonCreateAccountIsActiveOrNot(), Is.False);
        }
    }
}
