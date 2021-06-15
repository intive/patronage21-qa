using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Screens
{
    internal class EditUserScreen : BaseScreen
    {
        private static readonly string _screenName = "Edycja użytkownika";
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

        public void FillForm(AppiumDriver<AndroidElement> driver, Table table)
        {
            SwipeToBottom(driver);
            WriteTextToField(driver, table.Rows[0][0], "Imię");
            WriteTextToField(driver, table.Rows[0][1], "Nazwisko");
            WriteTextToField(driver, table.Rows[0][2], "Email");
            WriteTextToField(driver, table.Rows[0][3], "Numer telefonu");
            WriteTextToField(driver, table.Rows[0][4], "Github");
            WriteTextToField(driver, table.Rows[0][5], "Bio");
        }
    }
}