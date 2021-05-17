Feature: IP2-293FormHandling
	
# link JS: https://tracker.intive.com/jira/browse/IP2-293
# link QA: https://tracker.intive.com/jira/browse/IP2-315

Background:
Given The user passed through the form correctly

#Link to Zephyr 1
Scenario: REGISTRATION_FORM_STEP_1_IP2_293_Verification_side_is_visible
Given The user fills the form by correct details
When The user clicks button 'execute' 
Then Response is successful
And The user is redirected to the side 'Weryfikacja'
And should get e-mail with werification code 

#Link to Zephyr 2 
Scenario: REGISTRATION_FORM_STEP_1_IP2_293_Verification_side_is_not_visible
Given The user fills the form by correct details
When The user clicks button 'execute'
Then Response is not successful
And contains error information 

#Link to Zephyr 3 
Scenario: REGISTRATION_FORM_STEP_1_IP2_293_Verification_side_is_not_visible
Given The user fills the form by correct details
When The user clicks button 'execute'
Then Response is not successful
And contains error page
