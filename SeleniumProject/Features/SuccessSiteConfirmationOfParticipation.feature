Feature: Confirmation of participation
	User receives information about successfull registration.

#link QA: https://tracker.intive.com/jira/browse/IP2-305 and https://tracker.intive.com/jira/browse/IP2-175
#link JS: https://tracker.intive.com/jira/browse/IP2-288 and https://tracker.intive.com/jira/browse/IP2-138


#link_1 do Zephyr
Scenario: REGISTRATION_FORM_1_IP2-288_User_is_informed_about_successfull_registration_and_can_go_back_to_main_site
	Given User user sees the registration success message
	When User clicks "Strona główna"
	Then User should be trasfered to main side