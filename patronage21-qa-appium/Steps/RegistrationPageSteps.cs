using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class RegistrationPageSteps
    {
        private readonly AppiumDriver<AndroidElement> _driver;
        private Dictionary<string, string[]> editTextElements = new Dictionary<string, string[]>()
        {
            { "name", new string[] { "Imię *, Imię *", "Pole wymagane, Imię *" } },
            { "surname", new string[] { "Nazwisko *, Nazwisko *", "Pole wymagane, Nazwisko *" } },
            { "email", new string[] { "Email *, Email *", "Pole wymagane, Email *" } },
            { "phone", new string[] { "Numer telefonu *, Numer telefonu *", "Pole wymagane, Numer telefonu *" } },
            { "login", new string[] { "Login *, Login *", "Pole wymagane, Login *" } },
            { "password", new string[] { "Hasło *, Hasło *", "Pole wymagane, Hasło *" } },
            { "password confirm", new string[] { "Potwierdź hasło *, Potwierdź hasło *", "Pole wymagane, Potwierdź hasło *" } },
            { "Github" , new string[] { "Github URL, Github URL", "Github URL, Github URL" } },
        };

        public RegistrationPageSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
        }

        [Given(@"User is on Registration page")]
        public void GivenUserIsOnRegistrationPage()
        {
            var loginPageRegistrationButton = _driver.FindElement(
                new ByAndroidUIAutomator(
                    "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                    ".scrollIntoView(new UiSelector().text(\"Rejestracja\"))"));
            loginPageRegistrationButton.Click();
        }

        [When(@"User completes ""(.*)"" ""(.*)"" with ""(.*)""")]
        public void WhenUserCompletesWith(string element, string way, string data)
        {
            if (element.Equals("technologies"))
            {
                for (int i = 0; i < int.Parse(data); i++)
                {
                    var checkBox = _driver.FindElement(
                                   new ByAndroidUIAutomator(
                                       "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                       ".scrollIntoView(new UiSelector().className(\"android.widget.CheckBox\")" +
                                       ".instance(" + i + "))"));
                    checkBox.Click();
                }
            }
            else if (element.Equals("consents"))
            {
                _driver.FindElement(
                                   new ByAndroidUIAutomator(
                                       "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                       ".flingToEnd()"));
                for (int i = 0; i < int.Parse(data); i++)
                {
                    var checkBox = _driver.FindElement(
                                   new ByAndroidUIAutomator(
                                       "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                       ".scrollIntoView(new UiSelector().className(\"android.widget.CheckBox\")" +
                                       ".instance(" + i + "))"));
                    checkBox.Click();
                }
            }
            else
            {
                var editText = _driver.FindElement(
                                new ByAndroidUIAutomator(
                                    "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                    ".scrollIntoView(new UiSelector().text(\"" + editTextElements[element][0] + "\"))"));
                editText.Click();
                editText = _driver.FindElement(
                              new ByAndroidUIAutomator(
                                  "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                  ".scrollIntoView(new UiSelector().text(\"" + editTextElements[element][1] + "\"))"));
                editText.SendKeys(data);
            }
        }

        [When(@"User completes form correctly")]
        public void WhenUserCompletesFormCorrectly(Table formData)
        {
            var elementEnumerator = formData.Rows[0].GetEnumerator();
            while (elementEnumerator.MoveNext())
            {
                var element = elementEnumerator.Current;
                var elementName = element.Key;
                var elementData = element.Value;
                var editText = _driver.FindElement(
                                          new ByAndroidUIAutomator(
                                              "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                              ".scrollIntoView(new UiSelector().text(\"" + editTextElements[elementName][0] + "\"))"));
                editText.Click();
                editText = _driver.FindElement(
                                          new ByAndroidUIAutomator(
                                              "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                              ".scrollIntoView(new UiSelector().text(\"" + editTextElements[elementName][1] + "\"))"));
                editText.SendKeys(elementData);
                _driver.HideKeyboard();

                if (elementName.Equals("surname"))
                {
                    editText = _driver.FindElement(
                                          new ByAndroidUIAutomator(
                                              "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                              ".scrollIntoView(new UiSelector().text(\"" + editTextElements["email"][0] + "\"))"));
                    editText.Click();
                    editText = _driver.FindElement(
                                              new ByAndroidUIAutomator(
                                                  "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                                  ".scrollIntoView(new UiSelector().text(\"" + editTextElements["email"][1] + "\"))"));
                    
                    var random = new Random();
                    const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var randomString = new string(Enumerable.Repeat(chars, 10)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    var randomEmail = randomString + "@example.com";
                    editText.SendKeys(randomEmail);
                    _driver.HideKeyboard();
                }
                else if (elementName.Equals("phone"))
                {
                    for (int i = 0; i < 1; i++)
                    {
                        var checkBox = _driver.FindElement(
                                       new ByAndroidUIAutomator(
                                           "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                           ".scrollIntoView(new UiSelector().className(\"android.widget.CheckBox\")" +
                                           ".instance(" + i + "))"));
                        checkBox.Click();
                    }
                    editText = _driver.FindElement(
                                         new ByAndroidUIAutomator(
                                             "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                             ".scrollIntoView(new UiSelector().text(\"" + editTextElements["email"][0] + "\"))"));
                    editText.Click();
                    editText = _driver.FindElement(
                                              new ByAndroidUIAutomator(
                                                  "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                                  ".scrollIntoView(new UiSelector().text(\"" + editTextElements["email"][1] + "\"))"));

                    var random = new Random();
                    const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    var randomString = new string(Enumerable.Repeat(chars, 10)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                    var randomLogin = randomString;
                    editText.SendKeys(randomLogin);
                    _driver.HideKeyboard();
                }
                else if (elementName.Equals("Github"))
                {
                    _driver.FindElement(
                                   new ByAndroidUIAutomator(
                                       "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                       ".flingToEnd()"));
                    for (int i = 0; i < 2; i++)
                    {
                        var checkBox = _driver.FindElement(
                                       new ByAndroidUIAutomator(
                                           "new UiScrollable(new UiSelector().scrollable(true).instance(0))" +
                                           ".scrollIntoView(new UiSelector().className(\"android.widget.CheckBox\")" +
                                           ".instance(" + i + "))"));
                        checkBox.Click();
                    }
                }
            }
        }

        [When(@"User signs up")]
        public void WhenUserSignsUp(Table formData)
        {
            //ScenarioContext.Current.Add()
        }

        [When(@"User signs up again with the same ""(.*)""")]
        public void WhenUserSignsUpAgainWithTheSame(string element, Table formData)
        {
            // ScenarioContext.Current.Get()
        }

        [Then(@"User sees ""(.*)"" page"), Scope(Tag = "registration")]
        public void ThenUserSeesPage(string page)
        {
            //Assert.Pass();
        }

        [Then(@"User ""(.*)"" sign up")]
        public void ThenUserSignUp(string ability)
        {
           // Assert.Pass();
        }

        [Then(@"User is informed if ""(.*)"" is ""(.*)""")]
        public void ThenUserIsInformedIfIs(string element, string valid)
        {
            Assert.Pass();
        }
    }
}