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

        private By technologiesGroups = By.XPath("//*[text()='Grupy technologiczne']//parent::button");
        private By users = By.XPath("//*[text()='Użytkownicy']//parent::button");
        private By diary = By.XPath("//*[text()='Dzienniczek']//parent::button");
        private By calendar = By.XPath("//*[text()='Kalendarz']//parent::button");
        private By auditOfEvents = By.XPath("//*[text()='Audyt zdarzeń']//parent::button");

        private IWebElement technologiesGroupsModule => driver.FindElement(technologiesGroups);
        private IWebElement usersModule => driver.FindElement(users);
        private IWebElement diaryModule => driver.FindElement(diary);
        private IWebElement calendarModule => driver.FindElement(calendar);
        private IWebElement auditOfEventsModule => driver.FindElement(auditOfEvents);

        public void ClicksOnCalendar() => calendarModule.Click();

        public void FindCalendarModule() => driver.FindElement(calendar);

        public void FindTechnologiesGroupsModule() => driver.FindElement(technologiesGroups);

        public void FindUsersModule() => driver.FindElement(users);

        public void FindDiaryModule() => driver.FindElement(diary);

        public void FindAuditOfEventsModule() => driver.FindElement(auditOfEvents);

        public bool TechnologiesGroupsModuleIsActive() => technologiesGroupsModule.Enabled;

        public bool UsersModuleIsActive() => usersModule.Enabled;

        public bool DiaryModuleIsActive() => diaryModule.Enabled;
        
        public bool AuditOfEventsModuleIsActive() => auditOfEventsModule.Enabled;
    }
}