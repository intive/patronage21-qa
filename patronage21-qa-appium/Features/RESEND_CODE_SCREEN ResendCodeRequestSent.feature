@ignore
Feature: RESEND_CODE_SCREEN ResendCodeRequestSent
	User needs to be able to ask for 
	resending his activation code
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-607
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-345

# https://tracker.intive.com/jira/browse/IP2-1011
@ignore
Scenario: RESEND_CODE_SCREEN_1_IP2-345_resend_code_request_sent_correctly
	Given User is on "Wyślij ponownie kod" screen
	When User clicks "Nie otrzymałem/am kodu"
	Then Request to api for resending code is sent
