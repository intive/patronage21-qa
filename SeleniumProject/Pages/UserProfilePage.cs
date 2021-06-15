using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
{
    class UserProfilePage
    {
        private IWebDriver driver;
        public string envUrl = TestContext.Parameters["javaUsersPage"];

        public UserProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            if (string.IsNullOrEmpty(envUrl))
                envUrl = "http://localhost:3000/";

        }

        public By TomekKowalskiXPath = By.XPath("//*[text()='Tomek Kowalski']//parent::div");
        public IWebElement TomekKowalski => driver.FindElement(TomekKowalskiXPath);

        public By EdytujProfilXPath = By.XPath("//*[text()[contains(.,'Edytuj profil')]]");
        public IWebElement EdytujProfil => driver.FindElement(EdytujProfilXPath);

        public By bioXPath = By.XPath("//*[(text()='bio')]//parent::div");
        public IWebElement bio => driver.FindElement(bioXPath);

        public By ZatwierdźXPath = By.XPath("//*[text()[contains(.,'Zatwierdź')]]");
        public IWebElement Zatwierdź => driver.FindElement(ZatwierdźXPath);

        public By projektXPath = By.XPath("//*[(text()='projekt')]//parent::div");
        public IWebElement projekt => driver.FindElement(projektXPath);

        public By rolaXPath = By.XPath("//*[(text()='rola')]//parent::div");
        public IWebElement rola => driver.FindElement(rolaXPath);


        public By nieprawidłoweDaneXPath = By.XPath("//*[(text()='Nieprawidłowe dane')]//parent::div");

        public IWebElement nieprawidłoweDane => driver.FindElement(nieprawidłoweDaneXPath);

        public By daneZostałyPomyślnieZaktualizowaneXPath = By.XPath("//*[(text()='Dane zostały pomyślnie zaktualizowane')]//parent::div");

        public IWebElement daneZostałyPomyślnieZaktualizowane => driver.FindElement(daneZostałyPomyślnieZaktualizowaneXPath);

        public By numerTelefonuXPath = By.XPath("");

        public IWebElement numerTelefonu => driver.FindElement(numerTelefonuXPath);

        public By gitHubLinkXPath = By.XPath("");
        public IWebElement gitHubLink => driver.FindElement(numerTelefonuXPath);


        public By adresEmailXPath = By.XPath("");
        public IWebElement adresEmail => driver.FindElement(adresEmailXPath);

        plus



