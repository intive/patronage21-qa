Feature: REGISTRATION_FORM [/api/activate] Verification of email
	Endpoint should allow us to verify the email adress with correct code and activate account.

	# Link QA: https://tracker.intive.com/jira/browse/IP2-181
	# Link JS: https://tracker.intive.com/jira/browse/IP2-292
	# Link JS: https://tracker.intive.com/jira/browse/IP2-136

Background:
Given Endpoint is /api/activate

@ignore
# manual test
# https://tracker.intive.com/jira/browse/IP2-433
Scenario: REGISTRATION_FORM_[/api/activate]_[PUT]_1_IP2-292_Email_is_positively_verified
	Given Inactive User is in database
	When Request is sent with data to API
	| email          | activationCode |
	| ....@email.com | 12345678       |
	Then Verification is successful 
	And User is activated
	And response contains status '"Aktywacja udana"'

# https://tracker.intive.com/jira/browse/IP2-434
Scenario: REGISTRATION_FORM_[/api/activate]_[PUT]_2_IP2-292_Email_can_not_be_verified_with_invalid_code
	Given Inactive User is in database
	When Client enters 12345678 and the email
	And the request is sent to API
	Then Verification is not successful 
	And return Status is 409
	And response contains status '"Błędny kod"'
		
# https://tracker.intive.com/jira/browse/IP2-435
Scenario: REGISTRATION_FORM_[/api/activate]_[PUT]_3_IP2-292_User_does_not_exist
	When Client enters a code and not existing email
	And the request is sent to API
	Then Verification is not successful 
	And response contains status '"Użytkownik nie istnieje"'
	And return Status is 404

#https://tracker.intive.com/jira/browse/IP2-436
Scenario: REGISTRATION_FORM_[/api/activate]_[PUT]_4_IP2-292_User_can_not_be_activated_twice 
	Given User is activated
	When Client inserts previously used code and the email
	And the request is sent to API  
	Then Verification is not successful 
	And return Status is 409 
	And response contains status '"Użytkownik jest już aktywny"'

#https://tracker.intive.com/jira/browse/IP2-437
Scenario: REGISTRATION_FORM_[/api/activate]_[PUT]_5_IP2-292_Improper_code_will_not_activate_User
	Given Inactive User is in database
	When Client enters "improper code" and the email
	And the request is sent to API
	Then Verification is not successful 
	And return Status is 400
	And response contains status '"Niepoprawny kod aktywacyjny"'
	Examples:
	| improper code   | 
	| "12345"         | 
	| "123456789"     | 
	
#https://tracker.intive.com/jira/browse/IP2-436
Scenario: REGISTRATION_FORM_[/api/activate]_[PUT]_6_IP2-292_User_can_not_be_activated_with_incomplete_email 
	Given Inactive User is in database
	When Client enters code and incomplete email
	| code     | incomplete email    |
	| 12345678 | example476email.com |
	And the request is sent to API  
	Then Verification is not successful 
	And return Status is 400 
	And response contains status '"Niepoprawny email"'
	
