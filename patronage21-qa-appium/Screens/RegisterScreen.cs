using System.Collections.Generic;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace patronage21_qa_appium.Screens
{
    internal class RegisterScreen : BaseScreen
    {
        public static Dictionary<string, string> _fieldsText = new()
        {
            { "Imię", "Imię *, Imię *" },
            { "Nazwisko", "Nazwisko *, Nazwisko *" },
            { "Email", "Email *, Email *" },
            { "Numer telefonu", "Numer telefonu *, Numer telefonu *" },
            { "Login", "Login *, Login *" },
            { "Hasło", "Hasło *, Hasło *" },
            { "Potwierdź hasło", "Potwierdź hasło *, Potwierdź hasło *" },
            { "Github URL", "Github URL, Github URL" },
            { "Załóż konto", "Załóż konto" },
        };

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
            Wait(driver);
            if (title.Equals("Pani"))
            {
                ClickElement(driver, "Zwrot");
                FindElementByText(driver, title).Click();
            }
            FindElementByText(driver, _fieldsText["Imię"]).SendKeys(first_name);
            FindElementByText(driver, _fieldsText["Nazwisko"]).SendKeys(last_name);
            FindElementByText(driver, _fieldsText["Email"]).SendKeys(email);
            FindElementByText(driver, _fieldsText["Numer telefonu"]).SendKeys(phone);
            FindElementByText(driver, "QA");
            if (qa)
            {
                ClickElement(driver, "QA_checkbox");
            }
            if (android)
            {
                ClickElement(driver, "Android_checkbox");
            }
            if (javascript)
            {
                ClickElement(driver, "JavaScript_checkbox");
            }
            if (java)
            {
                ClickElement(driver, "Java_checkbox");
            }
            FindElementByText(driver, _fieldsText["Login"]).SendKeys(login);
            FindElementByText(driver, _fieldsText["Hasło"]).SendKeys(password);
            FindElementByText(driver, _fieldsText["Potwierdź hasło"]).SendKeys(confirmPassword);
            FindElementByText(driver, _fieldsText["Github URL"]).SendKeys(github);
            BaseScreen.SwipeToBottom(driver);
            if (first_regulations)
            {
                ClickElement(driver, "Pierwsza zgoda");
            }
            if (second_regulations)
            {
                ClickElement(driver, "Druga zgoda");
            }
            if (submit)
            {
                SearchForElement(driver, "Załóż konto").Click();
            }
        }

        public void SubmitRegisterFormWithFieldSetTo(AppiumDriver<AndroidElement> driver, string field, string value)
        {
            Dictionary<string, string> fieldsValues = new()
            {
                { "Imię", "Jan" },
                { "Nazwisko", "Kowalski" },
                { "Email", "test@test.test" },
                { "Numer telefonu", "123456789" },
                { "Login", "JanKowalski" },
                { "Hasło", "Password1!" },
                { "Potwierdź hasło", "Password1!" },
                { "Github URL", "https://www.github.com/JanKowalski" },
            };
            if (value.Equals("[Empty]")) { value = ""; }
            fieldsValues[field] = value;

            Wait(driver);
            FindElementByText(driver, _fieldsText["Imię"]).SendKeys(fieldsValues["Imię"]);
            FindElementByText(driver, _fieldsText["Nazwisko"]).SendKeys(fieldsValues["Nazwisko"]);
            FindElementByText(driver, _fieldsText["Email"]).SendKeys(fieldsValues["Email"]);
            FindElementByText(driver, _fieldsText["Numer telefonu"]).SendKeys(fieldsValues["Numer telefonu"]);
            FindElementByText(driver, "QA");
            ClickElement(driver, "QA_checkbox");
            Wait(driver);
            FindElementByText(driver, _fieldsText["Login"]).SendKeys(fieldsValues["Login"]);
            FindElementByText(driver, _fieldsText["Hasło"]).SendKeys(fieldsValues["Hasło"]);
            FindElementByText(driver, _fieldsText["Potwierdź hasło"]).SendKeys(fieldsValues["Potwierdź hasło"]);
            FindElementByText(driver, _fieldsText["Github URL"]).SendKeys(fieldsValues["Github URL"]);
            BaseScreen.SwipeToBottom(driver);
            ClickElement(driver, "Zgoda wymagana_checkbox");
            ClickElement(driver, "Zgoda wymagana_checkbox");
        }
    }
}