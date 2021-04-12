Feature: Form module - sign up
	User signs up to Patronage by form.
	#Task in JS Board: https://tracker.intive.com/jira/browse/IP2-98 and https://tracker.intive.com/jira/browse/IP2-243
	#Task in QA Board: https://tracker.intive.com/jira/browse/IP2-180

Background:
	Given User is on registration page

#zephyr link
Scenario: 1_Form_module - Form with required data
	Given User fills required data
	When User clicks on button 'Załóż konto'
	Then User should be on site about e-mail verification

#zephyr link
Scenario: 2_Form_module - Empty form
	Given User doesn't fill data
	Then User couldn't click o button 'Załóż konto'

#zephyr link
Scenario: 3_Form_module - Form with required data but 'Adres e-mail' is incorrect
	Given User fills 'Adres e-mail' without special keys for emails
	When User clicks on button 'Załóż konto'
	Then User should see that field 'Adres-email' is inccorect

#zephyr link 
Scenario: 4_Form_module - Form with required data but 'Telefon telefonu' is incorrect
	Given User fills 'Telefon komórkowy' using letters
	When User clicks on button 'Załóż konto'
	Then User should see that field 'Telefon komórkowy' is inccorect

#zephyr link
Scenario: 5_Form_module - Form filled with unchecked fields: 'JavaScript,Java,QA,Mobile'
	Given User doesn't check fields about technology groups
	When User clicks on button 'Załóż konto'
	Then User should see error message about unchecked technology groups
	
#zephyr link 
Scenario: 6_Form_module - Form filled with checked all fields: 'JavaScript,Java,QA,Mobile'
	Given User fills required data but all fields about technology grups are checked
	When User clicks on button 'Załóż konto'
	Then User should see error message about checked to many technology groups

#zephyr link 
Scenario: 7_Form_module - Form with checked three fields: 'JavaScript,Java,QA,Mobile'
	Given User checks three technology groups
	When User clicks on button 'Załóż konto'
	Then User should be on site about e-mail verification 

#zephyr link 
Scenario: 8_Form_module - Form with incorrect field 'Powtórz hasło'
	Given User repeats incorrect password in field 'Powtórz hasło'
	When User clicks on button 'Załóż konto'
	Then User should see error message above field 'Powtórz hasło'
	
#zephyr link 
Scenario: 9_Form_module - Form with incorrect password which is too short
	Given User fills password field using seven characters
	When User clicks on button 'Załóż konto'
	Then User should see message above field 'Hasło' about password is too short

#zephyr link 
Scenario: 10_Form_module - Form with incorrect password which doesn't have one uppercase
	Given User fills passowrd field without minimum one uppercase
	When User clicks on button 'Załóż konto'
	Then User should see message above field 'Hasło' about missing one uppercase

Scenario: 11_Form_module - Form with incorrect password wchich doesn't have one special key
	Given user fills password field without minimum one special key
	When User clicks on button 'Załóż konto'
	Then User should see message above field 'Hasło' about missing one special key