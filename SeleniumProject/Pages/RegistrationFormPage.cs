using OpenQA.Selenium;
using SeleniumProject.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    public class RegistrationFormPage : DriverHelper
    {
        IWebElement txtFirstName => WebDriver.FindElement(By.XPath(".//*[@name='firstName']"));

        public void EnterFirstName(string firstName)
        {
            txtFirstName.SendKeys(firstName);
        }

    }
}
