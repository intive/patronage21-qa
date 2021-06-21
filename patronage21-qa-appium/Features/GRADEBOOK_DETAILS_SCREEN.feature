@ignore
Feature: GRADEBOOK_DETAILS_SCREEN
	User wants to see details about 
	own and other patricipants
	grades
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-289
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-233

# zephyr link
Scenario: GRADEBOOK_DETAILS_SCREEN_1_IP2-233_screen_displayed_correctly
	Given User is on "Dzienniczek" screen
	When User selects first user from list
	Then User sees user "Szczeółowe oceny" screen
