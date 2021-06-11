using OpenQA.Selenium;

namespace SeleniumProject.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By technologiesGroups = By.XPath("//*[text()='Grupy technologiczne']//parent::button");
        public By users = By.XPath("//*[text()='Użytkownicy']//parent::button");
        public By diary = By.XPath("//*[text()='Dzienniczek']//parent::button");
        public By calendar = By.XPath("//*[text()='Kalendarz']//parent::button");
        public By auditOfEvents = By.XPath("//*[text()='Audyt zdarzeń']//parent::button");
        private By patronageLogo = By.XPath(".//*[contains(text(),'Patron')]//parent::span");
        private By hamburgerMenu = By.XPath(".//*[@id='basic-button']//parent::button");
        private By itemsInHamburgerMenu = By.XPath(".//*[@role='menu']//parent::ul");
        private By firstItemInHamburgerMenu = By.XPath(".//li[contains(text(),'Strona główna')]");
        private By secondItemInHamburgerMenu = By.XPath(".//li[contains(text(),'Kalendarz')]");
        private By thirdItemInHamburgerMenu = By.XPath(".//li[contains(text(),'Rejestracja')]");

        private IWebElement technologiesGroupsModule => driver.FindElement(technologiesGroups);
        private IWebElement diaryModule => driver.FindElement(diary);
        public IWebElement calendarModule => driver.FindElement(calendar);
        private IWebElement auditOfEventsModule => driver.FindElement(auditOfEvents);
        private IWebElement usersModule => driver.FindElement(users);
        private IWebElement logoInHeader => driver.FindElement(patronageLogo);

        private IWebElement menuInHeader => driver.FindElement(hamburgerMenu);
        private IWebElement elementsInHamburgerMenu => driver.FindElement(itemsInHamburgerMenu);
        private IWebElement homePageFromMenu => driver.FindElement(firstItemInHamburgerMenu);
        private IWebElement calendarFromMenu => driver.FindElement(secondItemInHamburgerMenu);
        private IWebElement registrationFromMenu => driver.FindElement(thirdItemInHamburgerMenu);

        public bool ElementsInHamburgerMenuDisplayed() => elementsInHamburgerMenu.Displayed;

        public void ClicksOnHamburgerMenu() => menuInHeader.Click();

        public void ClicksOnCalendarModule() => calendarModule.Click();
        public void ClicksOnUsersModule() => usersModule.Click();

        public void ClicksOnLogo() => logoInHeader.Click();

        public void ClicksOnHomePage() => homePageFromMenu.Click();

        public void ClicksOnCalendar() => calendarFromMenu.Click();

        public void ClicksOnRegistration() => registrationFromMenu.Click();

        public bool TechnologiesGroupsModuleIsActive() => technologiesGroupsModule.Enabled;

        public bool DiaryModuleIsActive() => diaryModule.Enabled;

        public bool AuditOfEventsModuleIsActive() => auditOfEventsModule.Enabled;
    }
}