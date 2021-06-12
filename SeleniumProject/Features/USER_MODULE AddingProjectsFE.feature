@ignore
Feature: USER_MODULE Adding projects to the user account
        User can add maximum of 5 projects in which he participates 

#Task in QA: https://tracker.intive.com/jira/browse/IP2-828
#Task in Java: https://tracker.intive.com/jira/browse/IP2-677

Background: 
	Given User is in the User Module

#https://tracker.intive.com/jira/browse/IP2-859
Scenario Outline: USER_MODULE_1_IP2-677_User_can_add_a_maximum_of_5_projects_to_user_account
	When User clicks Edytuj profil
	And User clicks + 
	And User chooses project name '<name>' and role '<role>'
	And User clicks Zatwierdź
	Then Added projects are saved

Examples: 
| name      | role      |
| Projekt 1 | developer |
| Projekt 2 | developer |
| Projekt 3 | developer |
| Projekt 4 | developer |
| Projekt 5 | developer |


#https://tracker.intive.com/jira/browse/IP2-860
Scenario Outline: USER_MODULE_2_IP2-677_User_should_not_be_allowed_to_add_more_than_5_projects_to_user_account
	When User clicks Edytuj profil
	And User clicks +
	And User chooses project name '<name>' and role '<role>'
	And User clicks +
	Then Button + is inactive
	And user sees the message '<message>'

Examples: 
| name      | role      | message                                                                                |
| Projekt 1 | developer | maksymalny limit projektów, w których można uczestniczyć w tym samym czasie, wynosi: 5 |
| Projekt 2 | developer | maksymalny limit projektów, w których można uczestniczyć w tym samym czasie, wynosi: 5 |
| Projekt 3 | developer | maksymalny limit projektów, w których można uczestniczyć w tym samym czasie, wynosi: 5 |
| Projekt 4 | developer | maksymalny limit projektów, w których można uczestniczyć w tym samym czasie, wynosi: 5 |
| Projekt 5 | developer | maksymalny limit projektów, w których można uczestniczyć w tym samym czasie, wynosi: 5 |
