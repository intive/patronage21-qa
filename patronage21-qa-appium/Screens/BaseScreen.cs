using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;

namespace patronage21_qa_appium.Screens
{
    internal class BaseScreen
    {
        private static Dictionary<string, string> _homeXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Witaj w Patron-a-tive!']" },
            { "Opis", "//android.view.View[@text='Aplikacja Parton-a-tive pozwala na zarządzanie programem stażowym, jego użytkownikami oraz wydarzeniami']" },
            { "Grupy technologiczne", "//android.widget.ImageView[@text='Grupy technologiczne']" },
            { "Użytkownicy", "//android.widget.ImageView[@text='Użytkownicy']" },
            { "Dzienniczek", "//android.widget.ImageView[@text='Dzienniczek']" },
            { "Kalendarz", "//android.widget.ImageView[@text='Kalendarz']" },
            { "Audyt zdarzeń", "//android.widget.ImageView[@text='Audyt zdarzeń']" },
            { "Rejestracja", "//android.widget.ImageView[@text='Rejestracja']" },
            { "First element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[1]" },
            { "Last element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[last()]" },
        };

        private static Dictionary<string, string> _loginXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Logowanie']" },
            { "Login", "//android.widget.EditText[@text='Login']" },
            { "Hasło", "//android.widget.EditText[@text='Hasło']" },
            { "Zaloguj", "//android.widget.Button[@text='Zaloguj']" },
            { "Rejestracja", "//android.widget.Button[@text='Rejestracja']" },
            { "First element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[1]" },
            { "Last element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[last()]" },
        };

        public static Dictionary<string, string> _registerXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Zgłoś się do programu Patron-a-tive już dziś!']" },
            { "Opis", "//android.view.View[@text='Wystarczy, że wypełnisz poniższy formularz zgłoszeniowy.']" },
            { "Zwrot", "//android.view.View[@text='Wystarczy, że wypełnisz poniższy formularz zgłoszeniowy.']/following-sibling::android.view.View[position()=1]" },
            { "Pan", "//android.view.View[@text='Pan']" },
            { "Pani", "//android.view.View[@text='Pani']" },
            { "Imię", "//android.widget.EditText[@text='Imię *, Imię *']" },
            { "Nazwisko", "//android.widget.EditText[@text='Nazwisko *, Nazwisko *']" },
            { "Nazwisko_dezaktywacja", "//android.view.ViewGroup/android.view.View/android.widget.EditText" },
            { "Email", "//android.widget.EditText[@text='Email *, Email *']" },
            { "Numer telefonu", "//android.widget.EditText[@text='Numer telefonu *, Numer telefonu *']" },
            { "QA_checkbox", "//android.view.View[@text='QA']/preceding-sibling::android.widget.CheckBox[position()=1]" },
            { "Java_checkbox", "//android.view.View[@text='Java']/preceding-sibling::android.widget.CheckBox[position()=1]" },
            { "JavaScript_checkbox", "//android.view.View[@text='JavaScript']/preceding-sibling::android.widget.CheckBox[position()=1]" },
            { "Android_checkbox", "//android.view.View[@text='Mobile (Android)']/preceding-sibling::android.widget.CheckBox[position()=1]" },
            { "Login", "//android.widget.EditText[@text='Login *, Login *']" },
            { "Hasło", "//android.widget.EditText[@text='Hasło *, Hasło *']" },
            { "Potwierdź hasło", "//android.widget.EditText[@text='Potwierdź hasło *, Potwierdź hasło *']" },
            { "Github URL", "//android.widget.EditText[@text='Github URL, Github URL']" },
            { "Zgoda wymagana", "//android.view.View[@text='Zgoda wymagana']" },
            { "Zgoda wymagana_checkbox", "//android.view.View[@text='Zgoda wymagana']/preceding-sibling::android.widget.CheckBox[position()=1]" },
            { "Pierwsza zgoda", "//android.widget.CheckBox[position()=1]" },
            { "Druga zgoda", "//android.widget.CheckBox[position()=2]" },
            { "Załóż konto", "//android.widget.Button[@text='Załóż konto']" },
            { "First element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[1]" },
            { "Last element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[last()]" },
        };

        private static Dictionary<string, string> _activationXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Weryfikacja adresu email']" },
            { "Opis", "//android.view.View[@text='Weryfikacja adresu email']/following-sibling::android.view.View[position()=1]" },
            { "Kod", "//android.widget.EditText[@text='Kod *, Kod *']" },
            { "Zatwierdź kod", "//android.widget.Button[@text='Zatwierdź kod']" },
            { "Nie otrzymałem/am kodu", "//android.widget.Button[@text='Nie otrzymałem/am kodu']" },
        };

        private static Dictionary<string, string> _registerSubmitXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Twoja rejestracja przebiegła pomyślnie!']" },
            { "Opis", "//android.view.View[@text='Konto zostało utworzone, możesz korzystać z aplikacji']" },
            { "Zamknij", "//android.widget.Button[@text='Zamknij']" },
        };

        private static Dictionary<string, string> _usersXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Użytkownicy']" },
            { "Opis", "//android.view.View[@text='Użytkownicy']/following-sibling::android.view.View[position()=1]" },
            { "Szukaj użytkownika", "//android.widget.ImageView[@content-desc='Search Icon']/parent::*" },
            { "Wybrana grupa", "//android.widget.ImageView[@content-desc='Search Icon']/parent::*/following-sibling::android.widget.EditText" },
            { "Wybierz grupę", "//android.widget.ImageView[@content-desc='Search Icon']/parent::*/following-sibling::android.widget.EditText/following-sibling::*[position()=1]" },
            { "Liderzy nagłówek", "//android.view.View[@text='Liderzy']" },
            { "Liderzy licznik", "//android.view.View[@text='Liderzy']/following-sibling::android.view.View[position()=1]" },
            { "Liderzy lista", "//android.view.View[@text='Liderzy']/following-sibling::android.view.View[position()>1][following-sibling::android.view.View[@text='Uczestnicy']]" },
            { "Liderzy Ty użytkownik", "//android.view.View[@text='Liderzy']/following-sibling::android.view.View[position()>1][following-sibling::android.view.View[@text='Uczestnicy']][@text='Ty']/preceding-sibling::android.view.View[position()=1]]" },
            { "Liderzy lista bez widocznych uczestników", "//android.view.View[@text='Liderzy']/following-sibling::android.view.View[position()>1]" },
            { "Liderzy brak wyników", "//android.view.View[@text='Liderzy']/following-sibling::android.view.View[position()>1][following-sibling::android.view.View[@text='Uczestnicy']][@text='Brak wyników']" },
            { "Uczestnicy nagłówek", "//android.view.View[@text='Uczestnicy']" },
            { "Uczestnicy licznik", "//android.view.View[@text='Uczestnicy']/following-sibling::android.view.View[position()=1]" },
            { "Uczestnicy lista", "//android.view.View[@text='Uczestnicy']/following-sibling::android.view.View[position()>1]" },
            { "Uczestnicy Ty użytkownik", "//android.view.View[@text='Uczestnicy']/following-sibling::android.view.View[position()>1][@text='Ty']/preceding-sibling::android.view.View[position()=1]]" },
            { "Uczestnicy brak wyników", "//android.view.View[@text='Uczestnicy']/following-sibling::android.view.View[position()>1][@text='Brak wyników']" },
            { "Ty", "//android.view.View[@text='Ty']" },
            { "Ty użytkownik", "//android.view.View[@text='Ty']/preceding-sibling::android.view.View[position()=1]" },
            { "First element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[1]" },
            { "Last element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[last()]" },
            { "Grupy", "//android.view.View[@text='Wszystkie grupy']/following-sibling::android.view.View" },
            { "Wszystkie grupy", "//android.view.View[@text='Wszystkie grupy']" },
            { "QA", "//android.view.View[@text='QA']" },
            { "Java", "//android.view.View[@text='Java']" },
            { "JavaScript", "//android.view.View[@text='JavaScript']" },
            { "Mobile (Android)", "//android.view.View[contains(@text, 'Android')]" },
        };

        // To be changed, for now both owned account and other person account details are the same
        private static Dictionary<string, string> _userDetailsXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Użytkownicy']" },
            { "Opis", "//android.view.View[@text='Użytkownicy']/following-sibling::android.view.View[position()=1]" },
            { "Zdjęcie", "//android.widget.ImageView[@content-desc='Search Icon']" },
            { "Nazwa użytkownika", "//android.widget.ImageView[@content-desc='Zdjęcie profilowe']/following-sibling::android.view.View[position()=1]" },
            { "Bio nagłówek", "//android.view.View[@text='Bio']" },
            { "Bio", "//android.view.View[@text='Bio']/following-sibling::android.view.View[position()=1]" },
            { "Projekty nagłówek", "//android.view.View[@text='Projekty']" },
            { "Projekty licznik", "//android.view.View[@text='Projekty']/following-sibling::android.view.View[position()=1]" },
            { "Projekty lista", "//android.view.View[@text='Projekty']/following-sibling::android.view.View[position()>1][following-sibling::android.view.View[@text='Kontakt']]" },
            { "Kontakt nagłówek", "//android.view.View[@text='Kontakt']" },
            { "Wyślij wiadomość", "//android.widget.Button[@text='Wyślij wiadomość']" },
            { "Email", "//android.widget.Button[@text='Wyślij wiadomość']/preceding-sibling::android.view.View[position()=1]" },
            { "Zadzwoń", "//android.widget.Button[@text='Zadzwoń']" },
            { "Numer telefonu", "//android.widget.Button[@text='Zadzwoń']/preceding-sibling::android.view.View[position()=1]" },
            { "Otwórz link", "//android.widget.Button[@text='Otwórz link']" },
            { "Link", "//android.widget.Button[@text='Otwórz link']/preceding-sibling::android.view.View[position()=1]" },
            { "Edytuj profil", "//android.widget.Button[@text='Edytuj profil']" },
            { "Dezaktywuj profil", "//android.widget.Button[@text='Dezaktywuj profil']" },
            { "First element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[1]" },
            { "Last element", "//android.view.ViewGroup/android.view.View/android.widget.ScrollView/*[last()]" },
        };

        private static Dictionary<string, string> _deactivationXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Czy na pewno chcesz dezaktywować użytkownika?']" },
            { "Opis", "//android.view.View[@text='Operacji tej nie będzie można cofnąć.']" },
            { "Instrukcja", "//android.view.View[@text='Aby potwierdzić dezaktywację wprowadź nazwisko w pole poniżej.']" },
            { "Nazwisko", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/android.widget.EditText" },
            { "Dezaktywuj profil", "//android.widget.Button[@text='Dezaktywuj profil']" },
            { "Anuluj", "//android.widget.Button[@text='Anuluj']" },
            { "First element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[1]" },
            { "Last element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[last()]" },
        };

        private static Dictionary<string, string> _deactivationSubmitXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Pomyślnie zdezaktywowano konto']" },
            { "Opis", "//android.view.View[@text='Nastąpi przekierowanie do ekranu logowania']" },
            { "OK", "//android.widget.Button[@text='OK']" },
        };

        private static Dictionary<string, string> _editUserXpathDict = new()
        {
            { "Imię", "//android.widget.EditText[position()=1]" },
            { "Nazwisko", "//android.widget.EditText[position()=2]" },
            { "Email", "//android.widget.EditText[position()=3]" },
            { "Numer telefonu", "//android.widget.EditText[position()=4]" },
            { "Github", "//android.widget.EditText[position()=5]" },
            { "Bio", "//android.widget.EditText[position()=6]" },
        };

        private static Dictionary<string, string> _gradebookXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Dzienniczek']" },
            { "Opis", "//android.view.View[@text='Dzienniczek']/following-sibling::android.view.View[position()=1]" },
            { "First element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[1]" },
            { "Last element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[last()]" },
        };

        private static Dictionary<string, string> _calendarXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Kalendarz']" },
            { "Opis", "//android.view.View[@text='Kalendarz']/following-sibling::android.view.View[position()=1]" },
            { "First element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[1]" },
            { "Last element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[last()]" },
        };

        private static Dictionary<string, string> _eventsAuditXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Audyt zdarzeń']" },
            { "First element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[1]" },
            { "Last element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[last()]" },
        };

        private static Dictionary<string, string> _techGroupsXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Grupy technologiczne']" },
            { "Opis", "//android.view.View[@text='Grupy technologiczne']/following-sibling::android.view.View[position()=1]" },
            { "First element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[1]" },
            { "Last element", "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/*[last()]" },
        };

        private static Dictionary<string, string> _resendCodeXpathDict = new()
        {
            { "Nagłówek", "//android.view.View[@text='Weryfikacja adresu e-mail']" },
            { "Opis", "//android.view.View[@text='Wpisz ponownie swój adres e-mail']" },
            { "Email", "//android.widget.EditText[position()=1]" },
            { "Wyślij kod", "//android.widget.Button[@text='Wyślij kod']" },
        };

        public static Dictionary<string, Dictionary<string, string>> _screensXpathDict = new()
        {
            { "Home", _homeXpathDict },
            { "Logowanie", _loginXpathDict },
            { "Rejestracja", _registerXpathDict },
            { "Aktywacja", _activationXpathDict },
            { "Wyślij ponownie kod", _resendCodeXpathDict },
            { "Potwierdzenie rejestracji", _registerSubmitXpathDict },
            { "Użytkownicy", _usersXpathDict },
            { "Szczegóły użytkownika", _userDetailsXpathDict },
            { "Dezaktywacja", _deactivationXpathDict },
            { "Edycja użytkownika", _editUserXpathDict },
            { "Potwierdzenie dezaktywacji", _deactivationSubmitXpathDict },
            { "Dzienniczek", _gradebookXpathDict },
            { "Kalendarz", _calendarXpathDict },
            { "Audyt zdarzeń", _eventsAuditXpathDict },
            { "Grupy technologiczne", _techGroupsXpathDict },
        };

        public static void Swipe(IPerformsTouchActions driver, int startX, int startY, int endX, int endY, int duration)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(startX, startY)
            .MoveTo(endX, endY)
            .Wait(duration)
            .Release();

            touchAction.Perform();
        }

        public static void SwipeDown(AppiumDriver<AndroidElement> driver, string screenName)
        {
            var element = driver.FindElementByXPath(_screensXpathDict[screenName]["Last element"]);
            var x0 = driver.Manage().Window.Size.Width / 2;
            var y0 = element.Location.Y - 10;
            var y1 = 350;
            Swipe(driver, x0, y0, x0, y1, 100);
        }

        public static void SwipeUp(AppiumDriver<AndroidElement> driver, string screenName)
        {
            var element = driver.FindElementByXPath(_screensXpathDict[screenName]["First element"]);
            var x0 = driver.Manage().Window.Size.Width / 2;
            var y0 = element.Size.Height + element.Location.Y + 10;
            var y1 = driver.Manage().Window.Size.Height - 350;
            Swipe(driver, x0, y0, x0, y1, 100);
        }

        public virtual AndroidElement SearchForElement(AppiumDriver<AndroidElement> driver, string screenName, string searchFor)
        {
            var elements = driver.FindElementsByXPath(_screensXpathDict[screenName][searchFor]);
            if (elements.Count == 0)
            {
                SwipeDown(driver, screenName);
                return driver.FindElementByXPath(_screensXpathDict[screenName][searchFor]);
            }
            else
            {
                return elements[0];
            }
        }

        public virtual void Wait(AppiumDriver<AndroidElement> driver)
        {
            driver.FindElementByXPath("//*");
        }

        public virtual void ClickElement(AppiumDriver<AndroidElement> driver, string screenName, string elementName)
        {
            driver.FindElementByXPath(_screensXpathDict[screenName][elementName]).Click();
        }

        public virtual void WriteTextToField(AppiumDriver<AndroidElement> driver, string screenName, string text, string field)
        {
            driver.FindElementByXPath(_screensXpathDict[screenName][field]).SendKeys(text);
        }

        public virtual AndroidElement GetElement(AppiumDriver<AndroidElement> driver, string screenName, string elementName)
        {
            return driver.FindElementByXPath(_screensXpathDict[screenName][elementName]);
        }

        public static AndroidElement GetElementFromScreen(AppiumDriver<AndroidElement> driver, string elementName, string screenName)
        {
            return driver.FindElementByXPath(_screensXpathDict[screenName][elementName]);
        }

        public virtual IReadOnlyCollection<AndroidElement> GetElements(AppiumDriver<AndroidElement> driver, string screenName, string elementName)
        {
            return driver.FindElementsByXPath(_screensXpathDict[screenName][elementName]);
        }

        public virtual AndroidElement FindElementByText(AppiumDriver<AndroidElement> driver, string text)
        {
            return driver.FindElement(MobileBy.AndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).setAsVerticalList()" +
                ".scrollIntoView(new UiSelector().text(\"" + text + "\"))"));
        }

        public static void SwipeToBottom(AppiumDriver<AndroidElement> driver)
        {
            try
            {
                driver.FindElement(MobileBy.AndroidUIAutomator(
                        "new UiScrollable(new UiSelector().scrollable(true)).flingToEnd(4)"));
            }
            catch (InvalidSelectorException)
            {
                // ignore
            }
        }

        public static void SwipeToTop(AppiumDriver<AndroidElement> driver)
        {
            try
            {
                driver.FindElement(MobileBy.AndroidUIAutomator(
                        "new UiScrollable(new UiSelector().scrollable(true)).flingToBeginning(4)"));
            }
            catch (InvalidSelectorException)
            {
                // ignore
            }
        }
      
        public static AndroidElement GetElementFromScreen(AppiumDriver<AndroidElement> driver, string elementName, string screenName)
        {
            return driver.FindElementByXPath(_screensXpathDict[screenName][elementName]);
        }

        public static IReadOnlyCollection<AndroidElement> GetElementsFromScreen(AppiumDriver<AndroidElement> driver, string elementName, string screenName)
        {
            return driver.FindElementsByXPath(_screensXpathDict[screenName][elementName]);
        }
    }
}