Feature: REGISTERED_SUCCESSFULLY_NOTIFICATION
	User wants to be able to 
	be ensured that his registration
	process is successfully finished
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-254
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-148

# https://tracker.intive.com/jira/browse/IP2-825
Scenario: SUCCESSFULLY_REGISTERED_NOTIFICATION_1_IP2-254_successfully_registered_notification_displayed_correctly
	When User clicks "Rejestracja"
	And User submits registration form correctly
	And User submits activation code form correctly
	Then User sees "Potwierdzenie rejestracji" screen
