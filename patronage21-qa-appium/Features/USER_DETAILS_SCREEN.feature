Feature: USER_DETAILS_SCREEN
	User wants to be able to 
	view informations about
	himself and other users
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-269
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-153

# https://tracker.intive.com/jira/browse/IP2-803
Scenario Outline: USER_DETAILS_SCREEN_1_IP2-153_user_details_screen_displayed_correctly
	Given User registers as "[unique]"
	When User navigates to "<profile>" profile
	Then User sees "Szczegóły użytkownika" screen
	And "Szczegóły użytkownika" screen is displayed correctly for "<profile>" profile

Examples: 
	| profile   |
	| owned     |
	| not owned |
	
# https://tracker.intive.com/jira/browse/IP2-804
Scenario: USER_DETAILS_SCREEN_2_IP2-153_navigate_to_other_screen_and_back
	Given User registers as "[unique]"
	When User navigates to "owned" profile
	And User clicks "Edytuj profil"
	And User clicks "Back" button
	And User clicks "Dezaktywuj profil"
	And User clicks "Back" button
	Then User sees "Szczegóły użytkownika" screen

@ignore
# https://tracker.intive.com/jira/browse/IP2-805
Scenario Outline: USER_DETAILS_SCREEN_3_IP2-153_contact_buttons_works
	Given User registers as "[unique]"
	When User navigates to "not owned" profile
	And User clicks "<button>"
	Then User is redirected to "<redirection>"

Examples: 
	| button           | redirection    |
	| Wyślij wiadomość | Email app      |
	| Zadzwoń          | Phone call app |
	| Otwórz link      | Web browser    |