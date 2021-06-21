@ignore
Feature: VERIFY_EMAIL_SCREEN VerifyEmailCodePostRequest
	User needs to be able to send
	request to api to ask for 
	verifying his email
#Task in QA Team: https://tracker.intive.com/jira/browse/IP2-613
#Task in Android Team: https://tracker.intive.com/jira/browse/IP2-343

# zephyr link
@ignore
Scenario: VERIFY_EMAIL_SCREEN_1_IP2-343_resend_code_request_sent_correctly
	Given User is on "Weryfikacja adresu email" screen
	When User writes "12341234" to "Kod" field
	And User clicks "Zatwierdź kod"
	Then Request to api for verifying email by code "12341234" is sent