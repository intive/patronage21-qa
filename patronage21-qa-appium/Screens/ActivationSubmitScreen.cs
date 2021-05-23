using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace patronage21_qa_appium.Screens
{
    internal class ActivationSubmitScreen : BaseScreen
    {
        private static string _screenName = "Aktywacja";
        public static Dictionary<string, string> _screenXpath = _screensXpathDict[_screenName];

        private static Dictionary<string, string> _xpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Twoja rejestracja przebiegła pomyślnie!']" },
            { "Opis", "//android.view.View[@text='Konto zostało utworzone, możesz korzystać z aplikacji']" },
            { "Zamknij", "//android.widget.Button[@text='Zamknij']" },
        };

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
    }
}