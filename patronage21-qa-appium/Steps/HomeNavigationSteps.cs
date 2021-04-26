using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class HomeNavigationSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private Dictionary<string, string> buttons = new Dictionary<string, string>()
        {
            { "Grupy technologiczne", "Miniaturka modułu grup technologicznych"},
            { "Użytkownicy", "Miniaturka modułu użytkowników"},
            { "Dzienniczek", "Miniaturka modułu dzienniczka"},
            { "Kalendarz", "Miniaturka modułu kalendarza"},
            { "Audyt zdarzeń", "Miniaturka modułu audytu zdarzeń"},
            { "Rejestracja", "Miniaturka modułu rejestracji"},
        };

        public HomeNavigationSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"User is on Home page")]
        public void GivenUserIsOnHomePage()
        {
        }

        [When(@"User clicks on ""(.*)"" button")]
        public void WhenUserClickskOnButton(string buttonId)
        {
            if (buttonId.Equals("Back"))
            {
                _driver.Navigate().Back();
            }
            else
            {
                var button = _driver.FindElementByAccessibilityId(buttons[buttonId]);
                button.Click();
            }
        }

        [Then(@"User sees ""(.*)"" page")]
        public void ThenUserSeesPage(string pageTitle)
        {
            if (pageTitle.Equals("Home"))
            {
                pageTitle = "Witaj w Patron-a-tive!";
            } else if (pageTitle.Equals("Rejestracja"))
            {
                pageTitle = "Logowanie";
            }
            var xpath = "//android.view.View[@text='" + pageTitle + "']";
            var pageElement = _driver.FindElementByXPath(xpath);
            Assert.IsTrue(pageElement.Displayed);
        }
    }
}
