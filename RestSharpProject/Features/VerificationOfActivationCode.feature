﻿Feature: Verification of activation code
	Endpoint should allow us to verify the email adress with correct code and activate account.

	# Link QA: https://tracker.intive.com/jira/browse/IP2-181
	# Link JS: https://tracker.intive.com/jira/browse/IP2-292
	# Link JS: https://tracker.intive.com/jira/browse/IP2-136

Background:
Given Endpoint is /api/activate

@ignore
# manual test
# https://tracker.intive.com/jira/browse/IP2-433
Scenario: REGISTRATION_FORM_1_IP2-292_Email_is_positively_verified
	Given Inactive User is in database
	When Request is sent with data to API
	| email          | activationCode |
	| ....@email.com | 12345678       |
	Then Verification is successful 
	And User is activated
	And response contains status '"Aktywacja udana"'


# https://tracker.intive.com/jira/browse/IP2-434
Scenario: REGISTRATION_FORM_2_IP2-292_Email_can_not_be_verified_with_invalid_code
	Given Inactive User is in database
	When Client enters false code and the email
	And the request is sent to API
	Then Verification is not successful 
	And return Status is 409
	And response contains status '"Błędny kod"'

# https://tracker.intive.com/jira/browse/IP2-435
Scenario: REGISTRATION_FORM_3_IP2-292_User_does_not_exist
	When Client enters a code and not existing email
	And the request is sent to API
	Then Verification is not successful 
	And response contains status '"Użytkownik nie istnieje"'
	And return Status is 404

#https://tracker.intive.com/jira/browse/IP2-436
Scenario: REGISTRATION_FORM_4_IP2-292_User_can_not_be_activated_twice 
	Given User is activated
	When Client enters previously used code and the email
	And the request is sent to API  
	Then Verification is not successful 
	And return Status is 409 
	And response contains status '"Użytkownik jest już aktywny"'

#https://tracker.intive.com/jira/browse/IP2-437
Scenario Outline: REGISTRATION_FORM_5_IP2-292_Improper_code_will_not_activate_User
	Given Inactive User is in database
	When Client enters <improper code> and the email
	And the request is sent to API
	Then Verification is not successful 
	And return Status is 400
	And response contains <errorMessage>
	Examples:
	| improper code   | errorMessage				  |
	| "12345"         | Niepoprawny kod aktywacyjny   |
	| "123456789"     | Niepoprawny kod aktywacyjny   |
	
#https://tracker.intive.com/jira/browse/IP2-436
Scenario: REGISTRATION_FORM_6_IP2-292_User_can_not_be_activated_with_incomplete_email 
	Given Inactive User is in database
	When Client enters code and incomplete email
	| code     | incomplete email    |
	| 12345678 | example476email.com |
	And the request is sent to API  
	Then Verification is not successful 
	And return Status is 400 
	And response contains status '"Niepoprawny email"'
	
