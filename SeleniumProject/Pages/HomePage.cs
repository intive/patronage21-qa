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

        private By technologiesGroups = By.XPath(".//*[contains(text(),'Grupy technologiczne')]");
        private By users = By.XPath(".//*[contains(text(),'Użytkownicy')]");
        private By diary = By.XPath(".//*[contains(text(),'Dzienniczek')]");
        private By calendar = By.XPath(".//*[contains(text(),'Kalendarz')]");
        private By auditOfEvents = By.XPath(".//*[contains(text(),'Kalendarz')]");

        private IWebElement calendarModule => driver.FindElement(calendar);

        public void ClicksOnCalendar() => calendarModule.Click();

        public void FindCalendarModule() => driver.FindElement(calendar);

        public void FindTechnologiesGroupsModule() => driver.FindElement(technologiesGroups);

        public void FindUsersModule() => driver.FindElement(users);

        public void FindDiaryModule() => driver.FindElement(diary);

        public void FindAuditOfEventsModule() => driver.FindElement(auditOfEvents);

        public bool TechnologiesGroupsModuleIsInactive() => driver.FindElement(technologiesGroups).Enabled;

        public bool UsersModuleIsInactive() => driver.FindElement(users).Enabled;

        public bool DiaryModuleIsInactive() => driver.FindElement(diary).Enabled;

        public bool AuditOfEventsModuleIsInactive() => driver.FindElement(auditOfEvents).Enabled;
    }
}