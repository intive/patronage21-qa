Feature: LOGIN_SCREEN
	User wants to be able to log 
	in to his account
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-476
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-245
	
# zephyr link
Scenario: LOGIN_SCREEN_1_IP2-245_login_screen_displayed_correctly
	Then User sees "Logowanie" screen
	
# zephyr link
Scenario: LOGIN_SCREEN_2_IP2-245_navigate_to_register_form_and_back
	When User clicks "Rejestracja"
	And User clicks "Back" button
	Then User sees "Logowanie" screen
