@ignore
Feature: GRADEBOOK_SCREEN
	User wants to see other
	participants and his own grades
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-285
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-232

Background: 
	Given User is on "Dzienniczek" screen

# https://tracker.intive.com/jira/browse/IP2-1025
Scenario: GRADEBOOK_SCREEN_1_IP2-232_screen_displayed_correctly
	Then User sees "Dzienniczek" screen
	
# https://tracker.intive.com/jira/browse/IP2-1026
Scenario: GRADEBOOK_SCREEN_2_IP2-232_navigate_to_screen_and_back
	When User clicks "Dodaj kolumnę"
	And User clicks "Back" button
	When User clicks "Uczestnicy lista"
	And User clicks "Back" button
	When User clicks "Moje konto"
	And User clicks "Back" button
	Then User is on "Dzienniczek" screen
