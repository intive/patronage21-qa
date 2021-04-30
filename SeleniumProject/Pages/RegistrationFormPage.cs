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
        IWebElement txtLastName => WebDriver.FindElement(By.XPath(".//*[@name='lastName']"));
        IWebElement txtEmail => WebDriver.FindElement(By.XPath(".//*[@name='email']"));
        IWebElement txtPhone => WebDriver.FindElement(By.XPath(".//*[@name='phone']"));
        IWebElement txtGithubLink => WebDriver.FindElement(By.XPath(".//*[@name='githubLink']"));
        IWebElement txtLogin => WebDriver.FindElement(By.XPath(".//*[@name='login']"));
        IWebElement txtPassword => WebDriver.FindElement(By.XPath(".//*[@name='password']"));
        IWebElement txtPasswordConfirm => WebDriver.FindElement(By.XPath(".//*[@name='passwordConfirm']"));
        IWebElement buttonCreateAccount => WebDriver.FindElement(By.XPath(".//*[@type='submit']"));

        public void EnterDataIntoForm(string firstName, string lastName, string email, Nullable<int> phone, string githubLink, string technology, string login, string password, string passwordConfirm)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(lastName);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(phone.ToString());
            txtGithubLink.SendKeys(githubLink);
            if (technology != "")
            {
                WebDriver.FindElement(By.XPath(".//*[@value='" + technology + "']")).Click();
            }            
            txtLogin.SendKeys(login);
            txtPassword.SendKeys(password);
            txtPasswordConfirm.SendKeys(passwordConfirm);
            WebDriver.FindElement(By.XPath("//*[contains(text(),'Lorem')]")).Click();
        }

        public bool ButtonCreateAccountIsActiveOrNot()
        {
            if (buttonCreateAccount.Enabled)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
