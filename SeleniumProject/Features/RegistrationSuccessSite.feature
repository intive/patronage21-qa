Feature: Registration SuccessSite
	User receives information about successfull registration.

#link QA: https://tracker.intive.com/jira/browse/IP2-305 and https://tracker.intive.com/jira/browse/IP2-175
#link JS: https://tracker.intive.com/jira/browse/IP2-288 and https://tracker.intive.com/jira/browse/IP2-138

Background: 
Given Activated User is redirected to Success Site

#https://tracker.intive.com/jira/browse/IP2-512
Scenario: REGISTRATION_FORM_1_IP2-288_User_is_informed_about_successfull_registration_and_can_go_back_to_main_site
	Given User sees the registration success message on site 
	When User clicks "Strona główna"
	Then User should be transferred to main site
