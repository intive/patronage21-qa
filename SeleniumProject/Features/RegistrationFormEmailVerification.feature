Feature: Verification of email address 
	User should be able to confirm his/hers email address and activate account with received code.

# QA: https://tracker.intive.com/jira/browse/IP2-166
# JS: https://tracker.intive.com/jira/browse/IP2-135
#FYI there will be other ticket related to this issue, please enclose link

Background:
Given User is on registration site


@ignore
# manual
# https://tracker.intive.com/jira/browse/IP2-297
Scenario: REGISTRATION_FORM_1_IP2-135_User_inserts_correct_code
	Given User has correct code
	When User enters the code
	And User clicks "Zatwierdź kod" button
	Then User sees "Twoja rejestracja przebiegła pomyślnie!"

@ignore
# manual
#https://tracker.intive.com/jira/browse/IP2-298
Scenario: REGISTRATION_FORM_2_IP2-135_User_should_be_able_to_retrive_code_on_his/hers_mailbox
	When User clicks "Nie otrzymałem/am kodu"
	Then User should receive code 

#https://tracker.intive.com/jira/browse/IP2-299
Scenario: REGISTRATION_FORM_3_IP2-135_User_shouldn't_be_able_to_confirm_email_adress_and_activate_account_with_invalid_code
	When User enters false code
	And User clicks "Zatwierdź kod" button
	Then User should be moved to "Wystąpił błąd" site.

#https://tracker.intive.com/jira/browse/IP2-300
Scenario: REGISTRATION_FORM_4_IP2-135_User_shouldn't_be_able_to_confirm_email_address_and_activate_account_with_improper_code 
(code_which_has_less_than_8_and_more_than_8_characters)
	When User enters improper code
	Then "Zatwierdz kod" button stays inactive

@ignore
# manual
#https://tracker.intive.com/jira/browse/IP2-301
Scenario: REGISTRATION_FORM_5_IP2-135_Valid_code_can_be_used_only_one_time
	Given User already used code
	And activated account
	When User fills in register form one more time
	And inserts different email address
	And is asked for the code
	And uses previously received code
	Then User should be moved to "Wystąpił błąd" site
	
@ignore
# manual 
#https://tracker.intive.com/jira/browse/IP2-302
Scenario: REGISTRATION_FORM_6_IP2-135_Generated_code_is_unique
	Given User1 has code 
	And User2 fills in the registration form
	When User2 click "Załóż konto"
	Then Code of User2 should be different from code of User1 