Feature: Verification of email address 
	User should be able to confirm his/hers email address and activate account with received code.

https://tracker.intive.com/jira/browse/IP2-135
#FYI there will be other ticket related to this issue, please enclose link

Background:
Given User is on registration site


@ignore
# https://tracker.intive.com/jira/browse/IP2-297
Scenario: 1_Form module - User inserts correct code
	Given User has correct code
	When User enters the code
	And User clicks "Zatwierdź kod" button
	Then User sees "Twoja rejestracja przebiegła pomyślnie!"

@ignore
#https://tracker.intive.com/jira/browse/IP2-298
Scenario: 2_Form module - User should be able to retrive code on his/hers mailbox
	When User clicks "Nie otrzymałem/am kodu"
	Then User should receive code 

#https://tracker.intive.com/jira/browse/IP2-299
Scenario: 3_Form module - User shouldn't be able to confirm email adress and activate account with invalid code
	When User enters false code
	And User clicks "Zatwierdź kod" button
	Then User should be moved to "Wystąpił błąd" site.

#https://tracker.intive.com/jira/browse/IP2-300
Scenario: 4_Form module - User shouldn't be able to confirm email address and activate account with improper code 
(code which has less than 8 and more than 8 characters)
	When User enters improper code
	Then "Zatwierdz kod" button stays inactive

@ignore
#https://tracker.intive.com/jira/browse/IP2-301
Scenario: 5_Form module - Valid code can be used only one time
	Given User already used code
	And activated account
	When User fills in register form one more time
	And inserts different email address
	And is asked for the code
	And uses previously received code
	Then User should be moved to "Wystąpił błąd" site
	
@ignore
#https://tracker.intive.com/jira/browse/IP2-302
Scenario: 6_Form module - Generated code is unique
	Given User1 has code 
	And User2 fills in the registration form
	When User2 click "Załóż konto"
	Then Code of User2 should be different from code of User1 