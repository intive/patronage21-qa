using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using RestSharp;
using TechTalk.SpecFlow;

namespace patronage21_qa_appium.Steps
{
    [Binding]
    public class UsersScreenTechGroupsFromApiSteps
    {
        private string _url;
        private RestClient _client;
        private RestRequest _requestGet;
        private List<string> _groups;

        private readonly AppiumDriver<AndroidElement> _driver;

        public UsersScreenTechGroupsFromApiSteps(AppiumDriver<AndroidElement> driver)
        {
            _driver = driver;
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _url = "http://64z31.mocklab.io";
            _client = new RestClient(_url);
            _requestGet = new RestRequest("/api/groups/technologies", Method.GET);
            _groups = JsonConvert.DeserializeObject<List<string>>(_client.Execute(_requestGet).Content);
        }

        [Given(@"User is on ""(.*)"" screen")]
        public void GivenUserIsOnScreen(string p0)
        {
            _driver.FindElementByXPath("//android.widget.ImageView[@content-desc='Miniaturka modułu użytkowników']").Click();
        }

        [When(@"User clicks ""(.*)""")]
        public void WhenUserClicks(string p0)
        {
            var elementXpath = "//android.widget.FrameLayout/android.view.ViewGroup/android.view.View/android.view.View[3]";
            var element = _driver.FindElementByXPath(elementXpath);
            element.Click();
        }

        [Then(@"User sees correct tech groups")]
        public void ThenUserSeesCorrectTechGroups()
        {
            var displayedGroupsXpath = "//android.widget.ScrollView/android.view.View";
            var displayedGroups = _driver.FindElementsByXPath(displayedGroupsXpath);
            for (var i = 0; i < _groups.Count; i++)
            {
                var elementXpath = "//android.view.View[@text='" + _groups[i] + "']";
                var element = _driver.FindElementsByXPath(elementXpath);
                Assert.AreEqual(1, element.Count);
            }
            Assert.AreEqual(_groups.Count, displayedGroups.Count);
        }
    }
}