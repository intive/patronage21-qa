using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace patronage21_qa_appium.Screens
{
    internal class LoginScreen : BaseScreen
    {
        private static readonly string _screenName = "Logowanie";
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

        public static void SubmitLoginForm(AppiumDriver<AndroidElement> driver, string login, string password)
        {
            driver.FindElementByXPath(_screenXpath["Login"]).SendKeys(login);
            driver.FindElementByXPath(_screenXpath["Hasło"]).SendKeys(password);
            driver.FindElementByXPath(_screenXpath["Zaloguj"]).Click();
        }
    }
}