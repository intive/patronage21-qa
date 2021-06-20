using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace patronage21_qa_appium.Drivers
{
    internal class AndroidDriver
    {
        public static AppiumDriver<AndroidElement> Init()
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability("platformName", "Android");
            driverOption.AddAdditionalCapability("deviceName", "Android 30");
            driverOption.AddAdditionalCapability("appPackage", "com.intive.patronative");
            driverOption.AddAdditionalCapability("appActivity", "ui.activity.NavActivity");
            driverOption.AddAdditionalCapability("skipDeviceInitialization", true);
            driverOption.AddAdditionalCapability("skipServerInstallation", true);

            var driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }
    }
}