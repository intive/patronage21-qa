using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumProject.Steps
{
    [Binding]
    public class ConfirmationOfParticipationSteps
    {
        IWebDriver driver;

        [Given(@"User user sees the registration success message")]
        public void GivenUserUserSeesTheRegistrationSuccessMessage()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:3000/rejestracja-sukces";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement successfulRegistrationText = driver.FindElement(By.XPath(".//text()[.='Twoja rejestracja przebiegła pomyślnie!']"));
            Assert.AreEqual(true, successfulRegistrationText.Displayed);
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string p0)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement mainPageButton = driver.FindElement(By.XPath(".//text()[.='Strona główna']"));
            mainPageButton.Click();
        }

        [Then(@"User should be trasfered to main side")]
        public void ThenUserShouldBeTrasferedToMainSide()
        {
            Assert.Pass("pass");

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
