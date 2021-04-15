Feature: Form module - sign up
	User signs up to Patronage by form.
	#Task in JS Board: https://tracker.intive.com/jira/browse/IP2-98 and https://tracker.intive.com/jira/browse/IP2-243
	#Task in QA Board: https://tracker.intive.com/jira/browse/IP2-180

Background:
	Given User is on registration page

#zephyr link
Scenario: 1_Form_module - Form with required data
	Given User fills required data
	When User clicks on the button Załóż konto
	Then User should be on site about e-mail verification

#zephyr link
Scenario: 2_Form_module - Empty form
	Given User doesn't fill data
	Then User couldn't click on the button Załóż konto

#zephyr link
Scenario: 3_Form_module - Form without chosen field 'Tytuł'
	Given User doesn't choose Tytuł
	When User fills others required data
	Then The button should be inactive

#zephyr link
Scenario: 4_Form_module - Form with required data but 'Adres e-mail' is incorrect
	Given User fills Adres e-mail without special keys for emails
	When User clicks on the button Załóż konto
	Then User should see that field Adres-email is incorrect

#zephyr link 
Scenario: 5_Form_module - Form with required data but 'Telefon komórkowy' is incorrect
	Given User fills Telefon komórkowy using letters
	When User clicks on the button Załóż konto
	Then User should see that field Telefon komórkowy is inccorect

#zephyr link
Scenario: 6_Form_module - Form filled with unchecked fields: 'JavaScript,Java,QA,Mobile'
	Given User fills required data
	And User doesn't check fields about technology groups
	When User clicks on the button Załóż konto
	Then User should see error message about unchecked technology groups
	
#zephyr link 
Scenario: 7_Form_module - Form filled with checked all fields: 'JavaScript,Java,QA,Mobile'
	Given User fills required data 
	And User checks all fields about technology grups
	When User clicks on the button Załóż konto
	Then User should see error message about checked too many technology groups

#zephyr link 
Scenario: 8_Form_module - Form with checked three fields: 'JavaScript,Java,QA,Mobile'
	Given User fills required data 
	And User checks three technology groups
	When User clicks on the button Załóż konto
	Then User should be on site about e-mail verification 

#zephyr link 
Scenario: 9_Form_module - Form with incorrect field 'Powtórz hasło'
	Given User fills required data 
	And User repeats password incorrect in field Powtórz hasło
	When User clicks on the button Załóż konto
	Then User should see error message about field Powtórz hasło
	
#zephyr link 
Scenario: 10_Form_module - Form with incorrect password which is too short
	Given User fills required data 
	And User fills too short password
	When User clicks on the button Załóż konto
	Then User should see message about password is too short

#zephyr link 
Scenario: 11_Form_module - Form with incorrect password which doesn't have one uppercase
	Given User fills passowrd field without minimum one uppercase
	When User clicks on the button Załóż konto
	Then User should see message about missing one uppercase

#zephyr link
Scenario: 12_Form_module - Form with incorrect password which doesn't have one special key
	Given User fills password field without minimum one special key
	When User clicks on the button Załóż konto
	Then User should see message about missing one special key

#zephyr link
Scenario: 13_Form_module - Form without checked field 'Regulamin'
	Given User fills required data 
	When Users doesn't check field Regulamin
	Then The button should be inactive

#zephyr link
Scenario: 14_Form_module - Form with incorrect field 'Github link'
	Given 
	When 
	Then 

#zephyr link
Scenario: 15_Form_module - Form with too short 'Login'
	Given 
	When 
	Then 

#zephyr link
Scenario: 16_Form_module - Form with too long 'Login'
	Given 
	When 
	Then 