@ignore
Feature: REGISTRATION_FORM FormHandling
	
# link JS: https://tracker.intive.com/jira/browse/IP2-293
# link QA: https://tracker.intive.com/jira/browse/IP2-315

Background:
Given The user passed through the form correctly

#https://tracker.intive.com/jira/browse/IP2-710
Scenario: REGISTRATION_FORM_STEP_1_IP2_293_Verification_site_is_visible
Given The user fills the form by correct details
When The user clicks button 'Załóż konto' 
Then Response is successful
And The user is redirected to the site 'Weryfikacja'

#https://tracker.intive.com/jira/browse/IP2-711
Scenario: REGISTRATION_FORM_STEP_2_IP2_293_Verification_site_is_not_visible
Given The user fills the form by correct details
When The user clicks button 'Załóz konto'
Then Response is not successful
And contains error information 

#https://tracker.intive.com/jira/browse/IP2-712
Scenario: REGISTRATION_FORM_STEP_3_IP2_293_Verification_site_is_not_visible
Given The user fills the form by correct details
When The user clicks button 'Załóż konto'
Then Response is not successful
And contains unspecified error