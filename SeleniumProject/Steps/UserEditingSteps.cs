using OpenQA.Selenium;
using SeleniumProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserEditingSteps
    {
        private readonly IWebDriver _webdriver;
        private readonly UserPage userpage;
        private readonly NavigationPage navigationPage;
        private readonly HomePage homePage;
        private IWebDriver webdriver;

        public UserEditingSteps(IWebDriver driver)
        {
            _webdriver = webdriver;
            userpage = new UserPage(_webdriver);
            navigationPage = new NavigationPage(_webdriver);
            homePage = new HomePage(_webdriver);
        }

        [Given(@"User is on the users page")]
        public void GivenUserIsOnTheUsersPage()
        {
            navigationPage.NavigateToHomePage();
            homePage.ClicksOnUsersModule();
        }

        [Given(@"User clicks a field with his user data")]
        public void GivenUserClicksAFieldWithHisUserData()
        {
            userpage.TomekKowalski.Click();
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton()
        {
            UserProfilePage.EdytujProfil.Click();
        }

        [When(@"User clicks on the ""(.*)"" field")]
        public void WhenUserClicksOnTheField()
        {
         
        }

        [When(@"User is writing his description")]
        public void WhenUserIsWritingHisDescription(string text)
        {
            UserProfilePage.bio.SendKeys(text);
        }

        [Then(@"User clicks ""(.*)"" button")]
        public void ThenUserClicksButton()
        {
            UserProfilePage.Zatwierdź.Click();
        }
        [Then(@"The message ""(.*)"" is displayed")]
        public void ThenTheMessageIsDisplayed()
        {
            UserProfilePage.daneZostałyPomyślnieZaktualizowane.Displayed();
        }

-----------------------------------------------------------------------
        [When(@"User enters project in the ""(.*)"" field")]
        public void WhenUserEntersProjectInTheField(string project)
        {
            
        }

        [When(@"User enters role in the ""(.*)"" field")]
        public void WhenUserEntersRoleInTheField(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"User clicks ""(.*)"" button and the project is saved")]
        public void ThenUserClicksButtonAndTheProjectIsSaved(string p0)
        {
            UserProfilePage.Zatwierdź.Click();
        }
        -------------------------------------------------------------------------------
                [When(@"User clicks on the ""(.*)"" field")]
        public void WhenUserClicksOnTheField()
        {
            UserProfilePage.adresEmail.Click();
        }

        [When(@"User writes a valid email address")]
        public void WhenUserWritesAValidEmailAddress(string email)
        {
            UserProfilePage.adresEmail.SendKeys(email);
        }

        [Then(@"User clicks ""(.*)"" button and the email address is saved")]
        public void ThenUserClicksButtonAndTheEmailAddressIsSaved()
        {
            UserProfilePage.Zatwierdź.Click();
        }
        [Then(@"The message ""(.*)"" is displayed")]
        public void ThenTheMessageIsDisplayed()
        {
            UserProfilePage.daneZostałyPomyślnieZaktualizowane.Displayed();
        }


        [When(@"User clicks on the ""(.*)"" field")]
        public void WhenUSerClicksOnTheField()
        {
            UserProfilePage.adresEmail.Click();
        }

        [When(@"User writes invalid email address")]
        public void WhenUserWritesInvalidEmailAddress(string invalidEmail)
        {
            UserProfilePage.adresEmail.SendKeys(invalidEmail);
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton()
        {
            UserProfilePage.Zatwierdź.Click();
        }

        [Then(@"The message ""(.*)"" appears")]
        public void ThenTheMessageAppears()
        {
            UserProfilePage.nieprawidłoweDane.Displayed();
        }
        [When(@"User clicks on the ""(.*)"" field")]
        public void WhenUserClicksOnTheField()
        {
            UserProfilePage.numerTelefonu.Click();
        }

        [When(@"User writes a valid phone number")]
        public void WhenUserWritesAValidPhoneNumber(string phoneNumber)
        {
            UserProfilePage.numerTelefonu.SendKeys(phoneNumber);
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton()
        {
            UserProfilePage.Zatwierdź.Click();
        }

        [Then(@"The message ""(.*)"" is displayed")]
        public void ThenTheMessageIsDisplayed()
        {
            UserProfilePage.daneZostałyPomyślnieZaktualizowane.Displayed();
        }
        [When(@"User clicks on the ""(.*)"" field")]
        public void WhenUserClicksOnTheField()
        {
            UserProfilePage.numerTelefonu.Click();
        }

        [When(@"User enters an incorrect '(.*)'")]
        public void WhenUserEntersAnIncorrect(int digits)
        {
            UserProfilePage.numerTelefonu.SendKeys(digits);
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton()
        {
            UserProfilePage.Zatwierdź.Click();
        }

        [Then(@"The message ""(.*)"" appears")]
        public void ThenTheMessageAppears()
        {
            UserProfilePage.nieprawidłoweDane.Displayed();
        }
        [When(@"User clicks on the ""(.*)"" field")]
        public void WhenUserClicksOnTheField()
        {
            
        }

        [When(@"User writes a valid github link")]
        public void WhenUserWritesAValidGithubLink(string link)
        {
            UserProfilePage.gitHubLink.SendKeys(link);
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton()
        {
            UserProfilePage.Zatwierdź.Click();
        }

        [Then(@"The message ""(.*)"" is displayed")]
        public void ThenTheMessageIsDisplayed()
        {
            UserProfilePage.daneZostałyPomyślnieZaktualizowane.Displayed();
        }

        [When(@"User writes an incorrect link")]
        public void WhenUserWritesAnIncorrectLink(string invalidLink)
        {
            UserProfilePage.gitHubLink.SendKeys(invalidLink);
        }

        [When(@"User clicks ""(.*)"" button")]
        public void WhenUserClicksButton(string p0)
        {
            UserProfilePage.Zatwierdź.Click();
        }

        [Then(@"The message ""(.*)"" appears")]
        public void ThenTheMessageAppears()
        {
            UserProfilePage.nieprawidłoweDane.Displayed();
        }


    }
}
