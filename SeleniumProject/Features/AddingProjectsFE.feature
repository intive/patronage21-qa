Feature: Adding projects to the user account
        User can add maximum of 5 projects in which he participates 

#Task in QA: https://tracker.intive.com/jira/browse/IP2-828
#Task in Java: https://tracker.intive.com/jira/browse/IP2-677

Background: 
	Given User is in the User Module

# Link to Zephyr
Scenario: USER_MODULE_1_IP2-677_User_can_add_a_maximum_of_5_projects_to_user_account
	When User clicks on "Edytuj profil" 
	And User clicks on "+" 
	And User enters project name '<name>' and role '<role>'
	And User clicks on "Zatwierdź" 
	Then Added projects are saved


# Link to Zephyr
Scenario: USER_MODULE_2_IP2-677_User_should_not_be_allowed_to_add_more_than_5_projects_to_user_account
	When User clicks on "Edytuj profil" 
	And User clicks on "+" 
	And User enters project name '<name>' and role '<role>'
	And User clicks on "+"
	Then Button "+" is inactive
	And user sees the message that limit is equal 5
