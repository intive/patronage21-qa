Feature: IP2-293FormHandling
	
# link JS: https://tracker.intive.com/jira/browse/IP2-293
# link QA: https://tracker.intive.com/jira/browse/IP2-315

Background:
Given The user passed through the form correctly

#https://tracker.intive.com/jira/browse/IP2-710
Scenario: FORM_HANDLING_STEP_1_IP2_293_Verification_site_is_visible
Given The user fills the form by correct details
When The user clicks button 'załóż konto' 
Then The user is redirected to the site 'Weryfikacja'

#https://tracker.intive.com/jira/browse/IP2-711
Scenario: FORM_HANDLING_STEP_1_IP2_293_Verification_site_is_not_visible
Given The user fills the form by correct details
When The user clicks button 'załóz konto'
Then contains error information  

#https://tracker.intive.com/jira/browse/IP2-712
Scenario: FORM_HANDLING_STEP_1_IP2_293_Verification_site_is_not_visible
Given The user fills the form by correct details
When The user clicks button 'załóż konto'
Then contains error page