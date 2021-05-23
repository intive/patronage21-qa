using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;

namespace patronage21_qa_appium.Screens
{
    internal class RegisterScreen : BaseScreen
    {
        private static readonly string _screenName = "Rejestracja";
        public static Dictionary<string, string> _screenXpath = _screensXpathDict[_screenName];

        public void ClickElement(AppiumDriver<AndroidElement> driver, string elementName)
        {
            base.ClickElement(driver, _screenName, elementName);
        }

        public void WriteTextToField(AppiumDriver<AndroidElement> driver, string text, string field)
        {
            base.WriteTextToField(driver, _screenName, text, field);
        }

        public AndroidElement GetElement(AppiumDriver<AndroidElement> driver, string elementName)
        {
            return base.GetElement(driver, _screenName, elementName);
        }

        public IReadOnlyCollection<AndroidElement> GetElements(AppiumDriver<AndroidElement> driver, string elementName)
        {
            return base.GetElements(driver, _screenName, elementName);
        }

        public AndroidElement SearchForElement(AppiumDriver<AndroidElement> driver, string searchFor)
        {
            return base.SearchForElement(driver, _screenName, searchFor);
        }

        public void SubmitRegisterForm(AppiumDriver<AndroidElement> driver, string title = "Pan", string first_name = "", string last_name = "", string email = "", string phone = "",
            bool qa = false, bool android = false, bool javascript = false, bool java = false, string login = "", string password = "", string confirmPassword = "", string github = "",
            bool first_regulations = false, bool second_regulations = false, bool submit = false)
        {
            SearchForElement(driver, "Zwrot").Click();
            SearchForElement(driver, title).Click();
            SearchForElement(driver, "Imię").SendKeys(first_name);
            SearchForElement(driver, "Nazwisko").SendKeys(last_name);
            SearchForElement(driver, "Email").SendKeys(email);
            SearchForElement(driver, "Numer telefonu").SendKeys(phone);
            if (qa)
            {
                SearchForElement(driver, "QA_checkbox").Click();
            }
            if (android)
            {
                SearchForElement(driver, "Android_checkbox").Click();
            }
            if (javascript)
            {
                SearchForElement(driver, "Javascript_checkbox").Click();
            }
            if (java)
            {
                SearchForElement(driver, "Java_checkbox").Click();
            }
            SearchForElement(driver, "Login").SendKeys(login);
            SearchForElement(driver, "Hasło").SendKeys(password);
            SearchForElement(driver, "Potwierdź hasło").SendKeys(confirmPassword);
            SearchForElement(driver, "Github URL").SendKeys(github);
            if (first_regulations)
            {
                SearchForElement(driver, "Zgoda wymagana");
                driver.FindElementByXPath("(" + _screenXpath["Zgoda wymagana_checkbox"] + ")[1]").Click();
            }
            if (second_regulations)
            {
                SearchForElement(driver, "Zgoda wymagana");
                driver.FindElementByXPath("(" + _screenXpath["Zgoda wymagana_checkbox"] + ")[last()]").Click();
            }
            if (submit)
            {
                SearchForElement(driver, "Załóż konto").Click();
            }
        }
    }
}