using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserEditingSteps
    {
        private readonly IWebDriver _webdriver;

        By bio = By.XPath(".//*[contains(@class, 'MuiInputBase-input MuiInput-input MuiInputBase-inputMultiline MuiInput-inputMultiline')]");
        By Zatwierdź = By.XPath(".//*[contains(text(),'Zatwierdź')]");

        public UserEditingSteps(IWebDriver driver)
        {
           _webdriver = driver;
          
        }

        [Given(@"User clicks the Edytuj profil button")]
        public void GivenUserClicksTheButton()
        {
            By edytujProfil = By.XPath(".//*[contains(text(),'Edytuj profil')]");
            _webdriver.FindElement(edytujProfil).Click();
        }

        [Given(@"User clicks on the bio field")]
        public void GivenUserClicksOnTheField()
        {
           
            _webdriver.FindElement(bio).Click();

        }

        [When(@"User is writing his description")]
        public void WhenUserIsWritingHisDescription()
        {
            _webdriver.FindElement(bio).SendKeys("description");
        }

        [Then(@"User clicks Zatwierdź button")]
        public void ThenUserClicksButton()
        {
            _webdriver.FindElement(Zatwierdź).Click();
        }

        
    }
}