using System;
using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace patronage21_qa_appium.Screens
{
    internal class EventsAuditScreen : BaseScreen
    {
        private static readonly string _screenName = "Audyt zdarzeń";
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

        public DateTime ParseDateTime(string dateTimeString)
        {
            // Changes strings like "18.06.2021 04:04" to DateTime object
            DateTime output;
            var subs = dateTimeString.Split(" ");
            var dateSubs = subs[0].Split(".");
            var timeSubs = subs[1].Split(":");
            output = new(int.Parse(dateSubs[2]), int.Parse(dateSubs[1]), int.Parse(dateSubs[0]), int.Parse(timeSubs[0]), int.Parse(timeSubs[1]), 0);
            return output;
            /* outdated for now
            // Changes strings like "12/4/07, 8:03 PM" to DateTime object 
            DateTime output;
            var subs = dateTimeString.Split(", ");
            var dateSubs = subs[0].Split("/");
            var timeSubs = subs[1].Split(" ");
            var timeOfDay = timeSubs[1];
            var time = timeSubs[0].Split(":");
            if (timeOfDay == "PM")
            {
                output = new(int.Parse(dateSubs[2]), int.Parse(dateSubs[1]), int.Parse(dateSubs[0]), int.Parse(time[0]) + 12, int.Parse(time[1]), 0);
            }
            else
            {
                output = new(int.Parse(dateSubs[2]), int.Parse(dateSubs[1]), int.Parse(dateSubs[0]), int.Parse(time[0]), int.Parse(time[1]), 0);
            }
            return output;
            */
        }
    }
}