Feature: REGISTER_FAILED_NOTIFICATION
	User wants to be notified that 
	his registration process has 
	not successfully finished
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-262
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-147

# https://tracker.intive.com/jira/browse/IP2-1009
Scenario: REGISTER_FAILED_NOTIFICATION_1_IP2-147_register_failed_wrong_code_provided
	When User clicks "Rejestracja"
	And User submits registration form correctly
	And User submits activation code form with wrong code
	Then User sees "Rejestracja nieudana" screen