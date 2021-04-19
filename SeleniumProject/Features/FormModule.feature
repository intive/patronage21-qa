Feature: Form module - sign up
	User signs up to Patronage by form.
	#Task in JS Board: https://tracker.intive.com/jira/browse/IP2-98 and https://tracker.intive.com/jira/browse/IP2-243
	#Task in QA Board: https://tracker.intive.com/jira/browse/IP2-180

Background:
	Given User is on registration page

#zephyr link
Scenario: FORM_MODULE_1_IP2_180_form_with_required_data
	Given User fills required data
	When User clicks on the button Załóż konto
	Then User should be on site about e-mail verification

#zephyr link
Scenario: FORM_MODULE_2_IP2_180_empty_form
	Given User doesn't fill data
	Then User couldn't click on the button Załóż konto

#zephyr link
Scenario: FORM_MODULE_3_IP2_180_form_without_chosen_field_'Tytuł'
	Given User doesn't choose Tytuł
	When User fills others required data
	Then The button should be inactive

#zephyr link
Scenario: FORM_MODULE_4_IP2_180_form_with_required_data_and_'Adres e-mail'_is_incorrect
	Given User fills Adres e-mail without special keys for emails
	When User clicks on the button Załóż konto
	Then User should see that field Adres-email is incorrect

#zephyr link 
Scenario: FORM_MODULE_5_IP2_180_form with_required_data_and_'Telefon komórkowy'_is_incorrect
	Given User fills Telefon komórkowy using letters
	When User clicks on the button Załóż konto
	Then User should see that field Telefon komórkowy is incorrect

#zephyr link 
Scenario: FORM_MODULE_6_IP2_180_form_with_required_data_with_too_short_'Telefon komórkowy'
	Given User fills too short phone number
	When User clicks on the button Załóż konto
	Then User should see error message about too short phone number

#zephyr link
Scenario: FORM_MODULE_7_IP2_180_form_filled_with_unchecked_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills required data
	And User doesn't check fields about technology groups
	When User clicks on the button Załóż konto
	Then User should see error message about unchecked technology groups
	
#zephyr link 
Scenario: FORM_MODULE_8_IP2_180_form_filled_with_checked_all_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills required data 
	And User checks all fields about technology grups
	When User clicks on the button Załóż konto
	Then User should see error message about checked too many technology groups

#zephyr link 
Scenario: FORM_MODULE_9_IP2_180_form_with_checked_three_fields:_'JavaScript,Java,QA,Mobile'
	Given User fills required data 
	And User checks three technology groups
	When User clicks on the button Załóż konto
	Then User should be on site about e-mail verification 

#zephyr link 
Scenario: FORM_MODULE_10_IP2_180_form_with_incorrect_field_'Powtórz hasło'
	Given User fills required data 
	And User repeats password incorrect in field Powtórz hasło
	When User clicks on the button Załóż konto
	Then User should see error message about field Powtórz hasło
	
#zephyr link 
Scenario: FORM_MODULE_11_IP2_180_form_with_incorrect_password_which_is_too_short
	Given User fills required data 
	And User fills too short password
	When User clicks on the button Załóż konto
	Then User should see message about password is too short

#zephyr link 
Scenario: FORM_MODULE_12_IP2_180_form_with_incorrect_password_which_doesn't_have_one_uppercase
	Given User fills password field without minimum one uppercase
	When User clicks on the button Załóż konto
	Then User should see message about missing one uppercase

#zephyr link
Scenario: FORM_MODULE_13_IP2_180_form_with_incorrect_password_which_doesn't_have_one_special_key
	Given User fills password field without minimum one special key
	When User clicks on the button Załóż konto
	Then User should see message about missing one special key

#zephyr link
Scenario: FORM_MODULE_14_IP2_180_form_without_checked_field_'Regulamin'
	Given User fills required data 
	When Users doesn't check field Regulamin
	Then The button should be inactive

#zephyr link
Scenario: FORM_MODULE_15_IP2_180_form_with_incorrect_field_'Github link'
	Given User fills field with random letters
	When User clicks on the button Załóż konto
	Then User should see error message about incorrect Github link

#zephyr link
Scenario: FORM_MODULE_16_IP2_180_form_with_too_short_'Login'
	Given User fills too short login
	When User clicks on the button Załóż konto
	Then User should see error message about incorrect Login

#zephyr link
Scenario: FORM_MODULE_17_IP2_180_form_with_too_long_'Login'
	Given User fills too long login
	When User clicks on the button Załóż konto
	Then User should see error message about incorrect Login