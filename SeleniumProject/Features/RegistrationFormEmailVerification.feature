Feature: Registration Form email verification 
	User should be able to confirm his/hers email address and activate account with received code.

# QA: https://tracker.intive.com/jira/browse/IP2-166
# JS: https://tracker.intive.com/jira/browse/IP2-135
# JS: https://tracker.intive.com/jira/browse/IP2-295

Background:
Given User proceeds with registration via email verification page

@ignore
# manual
# https://tracker.intive.com/jira/browse/IP2-297
Scenario: REGISTRATION_FORM_1_IP2-135_User_inserts_correct_code
	Given User has correct code
	When User enters the code
	And User clicks 'Zatwierdź kod' button
	Then User sees 'Twoja rejestracja przebiegła pomyślnie!'

@ignore
# manual
#https://tracker.intive.com/jira/browse/IP2-298
Scenario: REGISTRATION_FORM_2_IP2-135_User_should_be_able_to_retrieve_code_on_mailbox
	When User clicks 'Nie otrzymałem/am kodu'
	Then User receives code 

#https://tracker.intive.com/jira/browse/IP2-299
Scenario: REGISTRATION_FORM_3_IP2-135_False_code_should_not_allow_User_to_be_verified_and_activated
	Given User enters data
	| firstName | lastName | email             | phone       | githubLink             | login        | password         | passwordConfirm  |
	| Jan       | Nowak    | example@email.com | 123456789   | github.com/exampleLink | exampleLogin | examplePassword6@ | examplePassword6@ |
	And is transferred to verification site 
	When User enters code '00000000'
	And User clicks "Zatwierdź kod" 
	Then User sees 'Błędny kod'
	

#https://tracker.intive.com/jira/browse/IP2-300
Scenario: REGISTRATION_FORM_4_IP2-135_Too_short_code_should_not_allow_User_to_be_verified_and_activated 
	When User enters code '1234'
	Then User sees 'Kod jest za krótki'
	And is not able to click 'Zatwierdź kod' button
	
@ignore
# manual
#https://tracker.intive.com/jira/browse/IP2-301
Scenario: REGISTRATION_FORM_5_IP2-135_User_can_be_activated_only_once
	Given User already used code
	And activated account
	When User tries to activate again with the same code
	Then User sees 'Użytkownik jest już aktywny'
	
@ignore
# manual 
#https://tracker.intive.com/jira/browse/IP2-302
Scenario: REGISTRATION_FORM_6_IP2-135_Generated_code_is_unique
	Given User1 has code 
	And User2 fills in the registration form
	When User2 click 'Załóż konto'
	Then Code of User2 should be different from code of User1 

#https://tracker.intive.com/jira/browse/IP2-518
Scenario: REGISTRATION_FORM_7_IP2-135_Retrieving_of_the_code_should_be_possible
	Given User enters data
	| firstName | lastName | email             | phone       | githubLink             | login        | password         | passwordConfirm  |
	| Jan       | Nowak    | example@email.com | 123456789   | github.com/exampleLink | exampleLogin | examplePassword6@ | examplePassword6@ |
	And is transferred to verification site
	When User clicks Nie otrzymałem/am kodu button
	Then User sees 'Kod aktywacyjny został wysłany pomyślnie'

#https://tracker.intive.com/jira/browse/IP2-520
Scenario: REGISTRATION_FORM_8_IP2-135_Only_numbers_can_be_inserted_as_code
	When User enters 'code with characters' 
	| code with characters |
	| 'aaaaaa'             |
	| '123a455'            |
	Then is not able to click 'Zatwierdź kod' button

