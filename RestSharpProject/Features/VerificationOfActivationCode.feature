Feature: Verification of activation code
	Endpoint should allow us to verify the email adress with correct code and activate account.

	# Link QA: https://tracker.intive.com/jira/browse/IP2-181
	# Link JS: https://tracker.intive.com/jira/browse/IP2-292
	# Link JS: https://tracker.intive.com/jira/browse/IP2-136

Background:
Given Endpoint is set

@ignore
#manual test
# Link do Testu_1 w Zephyr
Scenario: REGISTRATION_FORM_1_IP2-292_Email_is_positively_verified
	Given User is in database
	And his status is inactive
	When Client enters the code and User ID
	And the request is sent to API
	Then Verification is successful, 
	And return Status is 200
	And User is activated
	And JSON  body contains status 'Aktywacja udana'


# Link do Testu_2 w Zephyr
Scenario: REGISTRATION_FORM_2_IP2-292_Email_cannot_be_verified_with_invalid_code
	Given User is in database
	And his status is inactive
	When Client enters false code and the User ID
	And the request is sent to API
	Then Verification is not successful 
	And return Status is 409
	And JSON  body contains status 'Bledny kod'

# Link do Testu_3 w Zephyr
Scenario: REGISTRATION_FORM_3_IP2-292_User_cannot_be_verified
	When Client enters a code and not existing User ID
	And the request is sent to API
	Then Verification is not successful 
	And JSON  body contains status 'Uzytkownik nie istnieje'
	And return Status is 404

#link do testu 4 w Zephyr
Scenario: REGISTRATION_FORM_4_IP2-292_User_cannot_be_activated_twice 
	Given User is activated
	When Client enters previously used code and the User ID
	And the request is sent to API  
	Then Verification is not successful 
	And return Status is 409 
	And JSON  body contains status 'Uzytkownik jest juz aktywny'

#link do testu 5 w Zephyr
Scenario: REGISTRATION_FORM_5_IP2-292_Email_cannot_be_verified_with_improper_code_(too_short_or_too_long_or_with_wrong_charakters)
	Given User is in database
	And his status is inactive
	When Client enters improper code and the User ID
	And the request is sent to API
	Then Verification is not successful 
	And return Status is 400
	And JSON  body contains status 'Nieudana rejestracja'
	
