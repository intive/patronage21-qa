using System;
using TechTalk.SpecFlow;

namespace SeleniumProject.Features
{
    [Binding]
    public class UserDownloadSteps
    {
        [Given(@"User is on the (.*) page")]
        public void GivenUserIsOnThePage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes the user's name and surname in the (.*) field")]
        public void WhenUserWritesTheUserSNameAndSurnameInTheField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects (.*) and clicks (.*) button")]
        public void WhenUserSelectsAndClicksButton(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects the technological group in which this user is located and clicks (.*) button")]
        public void WhenUserSelectsTheTechnologicalGroupInWhichThisUserIsLocatedAndClicksButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"The user selects a technology group in which this user is not located and clicks (.*) button")]
        public void WhenTheUserSelectsATechnologyGroupInWhichThisUserIsNotLocatedAndClicksButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes the user's name in the (.*) field")]
        public void WhenUserWritesTheUserSNameInTheField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User writes the user's surname in the (.*) field")]
        public void WhenUserWritesTheUserSSurnameInTheField(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"User selects a specific technological group and clicks (.*) button")]
        public void WhenUserSelectsASpecificTechnologicalGroupAndClicksButton(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"A user with that name and surname is displayed")]
        public void ThenAUserWithThatNameAndSurnameIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User with this name and surname is not displayed")]
        public void ThenUserWithThisNameAndSurnameIsNotDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"A list of users with that name is displayed")]
        public void ThenAListOfUsersWithThatNameIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"A list of users with that surname is displayed")]
        public void ThenAListOfUsersWithThatSurnameIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Users with that name in this group are showing up")]
        public void ThenUsersWithThatNameInThisGroupAreShowingUp()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Users with that surname in this group are showing up")]
        public void ThenUsersWithThatSurnameInThisGroupAreShowingUp()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
