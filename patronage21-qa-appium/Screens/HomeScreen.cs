using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using patronage21_qa_appium.Screens;

namespace patronage21_qa_appium.Screens
{
    internal class HomeScreen : BaseScreen
    {
        private static readonly string _screenName = "Home";
        public static Dictionary<string, string> _screenXpath = _screensXpathDict[_screenName];

        public void ClickElement(AppiumDriver<AndroidElement> driver, string elementName)
        {
            base.ClickElement(driver, _screenName, elementName);
        }

        public AndroidElement GetElement(AppiumDriver<AndroidElement> driver, string elementName)
        {
            return base.GetElement(driver, _screenName, elementName);
        }

        public IReadOnlyCollection<AndroidElement> GetElements(AppiumDriver<AndroidElement> driver, string elementName)
        {
            return base.GetElements(driver, _screenName, elementName);
        }

        public void NavigateToDeactivationScreenThroughUsersScreen(AppiumDriver<AndroidElement> driver)
        {
            ClickElement(driver, "Użytkownicy");
        }

        public void NavigateToDeactivationScreenThroughMyAccount()
        {
            // To be developed
        }
    }
}