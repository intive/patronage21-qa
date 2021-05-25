using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace patronage21_qa_appium.Screens
{
    internal class UsersScreen : BaseScreen
    {
        private static readonly string _screenName = "Użytkownicy";
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

        public void SelectGroup(AppiumDriver<AndroidElement> driver, string groupName)
        {
            ClickElement(driver, "Wybierz grupę");
            ClickElement(driver, groupName);
        }

        public AndroidElement SearchForElement(AppiumDriver<AndroidElement> driver, string searchFor)
        {
            return base.SearchForElement(driver, _screenName, searchFor);
        }

        public IReadOnlyCollection<AndroidElement> GetLidersList(AppiumDriver<AndroidElement> driver)
        {
            var participantsHeader = GetElements(driver, "Uczestnicy nagłówek");
            if (participantsHeader.Count == 0)
            {
                return GetElements(driver, "Liderzy lista bez widocznych uczestników");
            }
            return GetElements(driver, "Liderzy lista");
        }

        public IReadOnlyCollection<AndroidElement> GetParticipantsList(AppiumDriver<AndroidElement> driver)
        {
            SearchForElement(driver, "Uczestnicy nagłówek");
            return GetElements(driver, "Uczestnicy lista");
        }
    }
}