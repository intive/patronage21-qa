using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class DeactivationScreenSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;

        private Dictionary<string, string> _xpathDict = new Dictionary<string, string>()
        {
            { "Rejestracja_module", "//android.widget.ImageView[@text='Rejestracja']"},
            { "Dezaktywacja_button", "//android.widget.Button[@text='Dezaktywuj profil']"},
            { "Dezaktywuj profil", "//android.widget.Button[@text='Dezaktywuj profil']"},
            { "Dezaktywacja", "//android.view.View[@text='Czy na pewno chcesz dezaktywować użytkownika?']"},
            { "Logowanie", "//android.view.View[@text='Logowanie']"},
            { "Rejestracja_button", "//android.widget.Button[@text='Rejestracja']"},
            { "Zaloguj", "//android.widget.Button[@text='Zaloguj']"},
            { "Użytkownicy", "//android.widget.ImageView[@text='Użytkownicy']"},
            { "Ty", "//android.view.View[@text='Ty']"},
            { "Arek Kowalski", "//android.view.View[@text='Arek Kowalski']"},
            { "Imię", "//android.widget.EditText[@text='Imię *, Imię *']"},
            { "Nazwisko", "//android.widget.EditText[@text='Nazwisko *, Nazwisko *']"},
            { "Nazwisko_dezaktywacja", "//android.view.ViewGroup/android.view.View/android.widget.EditText"},
            { "Email", "//android.widget.EditText[@text='Email *, Email *']"},
            { "Numer telefonu", "//android.widget.EditText[@text='Numer telefonu *, Numer telefonu *']"},
            { "QA_checkbox", "//android.view.View[@text='QA']/preceding-sibling::android.widget.CheckBox[position()=1]"},
            { "Login", "//android.widget.EditText[@text='Login *, Login *']"},
            { "Hasło", "//android.widget.EditText[@text='Hasło *, Hasło *']"},
            { "Potwierdź hasło", "//android.widget.EditText[@text='Potwierdź hasło *, Potwierdź hasło *']"},
            { "Github URL", "//android.widget.EditText[@text='Github URL, Github URL']"},
            { "Zgoda wymagana", "//android.view.View[@text='Zgoda wymagana']"},
            { "Zgoda wymagana_checkbox", "//android.view.View[@text='Zgoda wymagana']/preceding-sibling::android.widget.CheckBox[position()=1]"},
            { "Załóż konto", "//android.widget.Button[@text='Załóż konto']"},
            { "Wyślij wiadomość", "//android.widget.Button[@text='Wyślij wiadomość']"},
            { "Kod", "//android.widget.EditText[@text='Kod *, Kod *']"},
            { "Zatwierdź kod", "//android.widget.Button[@text='Zatwierdź kod']"},
            { "Zamknij", "//android.widget.Button[@text='Zamknij']"},
        };

        public static void Swipe(IPerformsTouchActions driver, int startX, int startY, int endX, int endY, int duration)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(startX, startY)
            .MoveTo(endX, endY)
            .Release()
            .Wait(duration);

            touchAction.Perform();
        }

        public DeactivationScreenSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [BeforeScenario]
        public void Setup()
        {
            // to be developed
            // reset database
            // or use unique data for every scenario
            _driver.LaunchApp();
        }
        [Given(@"User is not logged in")]
        public void GivenUserIsNotLoggedIn()
        {
            // to be changed
            // uncomment when login/register screen will be first screen seen by user
            // var header = _driver.FindElementsByXPath(_xpathDict["Logowanie"]);
            // Assert.IsNotEmpty(header);
        }

        [When(@"User regisers as ""(.*)"" with surname ""(.*)""")]
        public void WhenUserRegisersAsWithSurname(string p0, string p1)
        {
            _driver.FindElementByXPath(_xpathDict["Rejestracja_module"]).Click();
            // to be changed
            // login/register screen will be first screen seen by user, so navigating to it will not be necessary,
            // previous lines will then have to be removed
            _driver.FindElementByXPath(_xpathDict["Rejestracja_button"]).Click();
            _driver.FindElementByXPath(_xpathDict["Imię"]).SendKeys("test");
            _driver.FindElementByXPath(_xpathDict["Nazwisko"]).SendKeys(p1);
            _driver.FindElementByXPath(_xpathDict["Email"]).SendKeys("test@email.com");
            _driver.FindElementByXPath(_xpathDict["Numer telefonu"]).SendKeys("123456789");
            Swipe(_driver, 100, 1800, 100, 100, 1000);
            _driver.HideKeyboard();
            _driver.FindElementByXPath(_xpathDict["QA_checkbox"]).Click();
            _driver.FindElementByXPath(_xpathDict["Login"]).SendKeys(p0);
            _driver.FindElementByXPath(_xpathDict["Hasło"]).SendKeys("Deactivate1!!");
            _driver.FindElementByXPath(_xpathDict["Potwierdź hasło"]).SendKeys("Deactivate1!!");
            Swipe(_driver, 100, 2000, 100, 100, 1000);
            _driver.HideKeyboard();
            Swipe(_driver, 100, 1800, 100, 100, 1000);
            _driver.FindElementByXPath(_xpathDict["Zgoda wymagana"]).Click();
            _driver.FindElementByXPath(_xpathDict["Zgoda wymagana_checkbox"]).Click();
            _driver.FindElementByXPath(_xpathDict["Zgoda wymagana_checkbox"]).Click();
            _driver.FindElementByXPath(_xpathDict["Załóż konto"]).Click();
            // to be changed
            // connect with database and activate user
            // or use universal code (idea for testing purposes) (every 8-digit string works for now)
            // or change all of this tests to manual
            _driver.FindElementByXPath(_xpathDict["Kod"]).SendKeys("11111111");
            _driver.FindElementByXPath(_xpathDict["Zatwierdź kod"]).Click();
            _driver.FindElementByXPath(_xpathDict["Zamknij"]).Click();
        }
        
        [When(@"User navigates to ""(.*)"" screen")]
        public void WhenUserNavigatesToScreen(string p0)
        {
            // to be changed, in future it should be easier to navigate by topbar, now it is done by Users module
            _driver.FindElementByXPath(_xpathDict["Użytkownicy"]).Click();
            // _driver.FindElementByXPath(_xpathDict["Ty"]).Click();
            // code in previous line will replace next line in future (for now data is mocked, it does not contain any user labeled with "Ty")
            _driver.FindElementByXPath(_xpathDict["Arek Kowalski"]).Click();
            Swipe(_driver, 700, 1800, 700, 100, 1000);
            _driver.FindElementByXPath(_xpathDict[p0 + "_button"]).Click();
        }
        
        [When(@"User writes ""(.*)"" to ""(.*)"" field")]
        public void WhenUserWritesToField(string input, string field)
        {
            _driver.FindElementByXPath(_xpathDict[field + "_dezaktywacja"]).SendKeys(input);
        }
        
        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string button)
        {
            _driver.FindElementByXPath(_xpathDict[button]).Click();
        }
        
        [When(@"User writes ""(.*)"" characters to ""(.*)"" field")]
        public void WhenUserWritesCharactersToField(int amount, string field)
        {
            string input = new('a', amount);
            _driver.FindElementByXPath(_xpathDict[field + "_dezaktywacja"]).SendKeys(input);
        }
        
        [Then(@"User sees ""(.*)"" screen")]
        public void ThenUserSeesScreen(string p0)
        {
            var header = _driver.FindElementsByXPath(_xpathDict[p0]);
            Assert.IsNotEmpty(header);
        }
        
        [Then(@"User with username ""(.*)"" profile is deactivated")]
        public void ThenUserWithUsernameProfileIsDeactivated(string username)
        {
            // to be developed, send request to api to check if user is deactivated
        }
        
        [Then(@"User is not logged in")]
        public void ThenUserIsNotLoggedIn()
        {
            // to be changed, uncomment when user deactivation redirect is developed
            /*
            _driver.FindElementByXPath(_xpathDict["Rejestracja_module"]).Click();
            _driver.FindElementByXPath(_xpathDict["Rejestracja_button"]).Click();
            // to be changed
            // login/register screen will be first screen seen by user, so navigating to it will not be necessary,
            // previous lines will then have to be removed
            var header = _driver.FindElementsByXPath(_xpathDict["Logowanie"]);
            Assert.IsNotEmpty(header);
            */
        }
        
        [Then(@"User sees ""(.*)"" characters in ""(.*)"" field")]
        public void ThenUserSeesCharactersInField(int amount, string field)
        {
            string text = _driver.FindElementByXPath(_xpathDict[field]).Text;
            Assert.AreEqual(amount, text.Length);
        }
    }
}
